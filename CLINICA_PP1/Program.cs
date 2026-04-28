using System;

namespace ClinicaPrivada
{
    class Program
    {
        static Clinica clinica = new Clinica();

        static void Main(string[] args)
        {
            CarregarExemplos();

            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("  SISTEMA DA CLINICA PRIVADA   ");
                Console.WriteLine("================================");
                Console.WriteLine("1. Registar Paciente");
                Console.WriteLine("2. Registar Medico");
                Console.WriteLine("3. Agendar Consulta");
                Console.WriteLine("4. Ver Pacientes");
                Console.WriteLine("5. Ver Medicos");
                Console.WriteLine("6. Ver Consultas");
                Console.WriteLine("0. Sair");
                Console.WriteLine("================================");
                Console.Write("Opcao: ");
                string opcao = Console.ReadLine();

                if      (opcao == "1") RegistarPaciente();
                else if (opcao == "2") RegistarMedico();
                else if (opcao == "3") AgendarConsulta();
                else if (opcao == "4") { clinica.MostrarPacientes();  Pausa(); }
                else if (opcao == "5") { clinica.MostrarMedicos();    Pausa(); }
                else if (opcao == "6") { clinica.MostrarConsultas();  Pausa(); }
                else if (opcao == "0") continuar = false;
                else { Console.WriteLine("Opcao invalida!"); Pausa(); }
            }

            Console.WriteLine("Ate logo!");
        }

        static void RegistarPaciente()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTAR PACIENTE ===");
            Console.Write("Nome: ");          string nome = Console.ReadLine();
            Console.Write("Idade: ");         int idade   = int.Parse(Console.ReadLine());
            Console.Write("Sexo (M/F): ");    char sexo   = char.Parse(Console.ReadLine().ToUpper());
            Console.Write("Nº Processo: ");   int num     = int.Parse(Console.ReadLine());

            clinica.AdicionarPaciente(new Paciente(nome, idade, sexo, num));
            Pausa();
        }

        static void RegistarMedico()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTAR MEDICO ===");
            Console.WriteLine("1. Medico Geral");
            Console.WriteLine("2. Medico Especialista");
            Console.Write("Tipo: ");          string tipo = Console.ReadLine();
            Console.Write("Nome: ");          string nome = Console.ReadLine();
            Console.Write("Idade: ");         int idade   = int.Parse(Console.ReadLine());
            Console.Write("Sexo (M/F): ");    char sexo   = char.Parse(Console.ReadLine().ToUpper());
            Console.Write("Nº de Ordem: ");   string ord  = Console.ReadLine();

            if (tipo == "1")
            {
                Console.Write("Custo da consulta: ");
                double custo = double.Parse(Console.ReadLine());
                clinica.AdicionarMedico(new MedicoGeral(nome, idade, sexo, ord, custo));
            }
            else if (tipo == "2")
            {
                Console.Write("Especialidade: ");      string esp   = Console.ReadLine();
                Console.Write("Custo base: ");         double cb    = double.Parse(Console.ReadLine());
                Console.Write("Taxa especialidade: "); double taxa  = double.Parse(Console.ReadLine());
                clinica.AdicionarMedico(new MedicoEspecialista(nome, idade, sexo, esp, ord, cb, taxa));
            }
            Pausa();
        }

        static void AgendarConsulta()
        {
            Console.Clear();
            Console.WriteLine("=== AGENDAR CONSULTA ===");

            if (clinica.Pacientes.Count == 0 || clinica.Medicos.Count == 0)
            {
                Console.WriteLine("Precisa de ter pacientes e medicos registados primeiro!");
                Pausa();
                return;
            }

            Console.WriteLine("\nPacientes:");
            for (int i = 0; i < clinica.Pacientes.Count; i++)
                Console.WriteLine($"  {i + 1}. {clinica.Pacientes[i].Nome}");
            Console.Write("Escolha o nº do paciente: ");
            int ip = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("\nMedicos:");
            for (int i = 0; i < clinica.Medicos.Count; i++)
                Console.WriteLine($"  {i + 1}. {clinica.Medicos[i].Nome} ({clinica.Medicos[i].Especialidade}) - {clinica.Medicos[i].CalcCusto()}€");
            Console.Write("Escolha o nº do medico: ");
            int im = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Data (ex: 20/05/2026): "); string data = Console.ReadLine();
            Console.Write("Hora (ex: 09:30): ");       string hora = Console.ReadLine();

            clinica.AgendarConsulta(clinica.Pacientes[ip], clinica.Medicos[im], data, hora);
            Pausa();
        }

        static void Pausa()
        {
            Console.WriteLine("\nCarregue ENTER para continuar...");
            Console.ReadLine();
        }

        static void CarregarExemplos()
        {
            clinica.AdicionarPaciente(new Paciente("Ana Silva",  25, 'F', 1001));
            clinica.AdicionarPaciente(new Paciente("Joao Costa", 40, 'M', 1002));

            clinica.AdicionarMedico(new MedicoGeral("Dr. Pedro Lopes",      45, 'M', "OM-111", 30.0));
            clinica.AdicionarMedico(new MedicoEspecialista("Dra. Carla Neves", 38, 'F', "Cardiologia", "OM-222", 50.0, 20.0));

            clinica.AgendarConsulta(clinica.Pacientes[0], clinica.Medicos[0], "28/04/2026", "09:00");
            clinica.AgendarConsulta(clinica.Pacientes[1], clinica.Medicos[1], "28/04/2026", "10:30");
        }
    }
}

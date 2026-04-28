using System;
using System.Collections.Generic;

namespace ClinicaPrivada
{
    public class Clinica
    {
        public List<Paciente> Pacientes { get; set; } = new List<Paciente>();
        public List<Medico>   Medicos   { get; set; } = new List<Medico>();
        public List<Consulta> Consultas { get; set; } = new List<Consulta>();

        public void AdicionarPaciente(Paciente p)
        {
            Pacientes.Add(p);
            Console.WriteLine($"Paciente registado: {p.Nome}");
        }

        public void AdicionarMedico(Medico m)
        {
            Medicos.Add(m);
            Console.WriteLine($"Médico registado: {m.Nome}");
        }

        public void AgendarConsulta(Paciente paciente, Medico medico, string data, string hora)
        {
            Consulta c = new Consulta(paciente, medico, data, hora);
            Consultas.Add(c);
            Console.WriteLine($"Consulta agendada! Custo: {c.Custo}€");
        }

        public void MostrarPacientes()
        {
            Console.WriteLine("\n===== PACIENTES =====");
            for (int i = 0; i < Pacientes.Count; i++)
                Console.WriteLine($"{i + 1}. {Pacientes[i]}");
        }

        public void MostrarMedicos()
        {
            Console.WriteLine("\n===== MÉDICOS =====");
            for (int i = 0; i < Medicos.Count; i++)
                Console.WriteLine($"{i + 1}. {Medicos[i]}");
        }

        public void MostrarConsultas()
        {
            Console.WriteLine("\n===== CONSULTAS =====");
            for (int i = 0; i < Consultas.Count; i++)
                Console.WriteLine($"{i + 1}. {Consultas[i]}");
        }
    }
}

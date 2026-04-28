using System;

namespace ClinicaPrivada
{
    public class Consulta
    {
        public Paciente Paciente { get; set; }
        public Medico   Medico   { get; set; }
        public string   Data     { get; set; }
        public string   Hora     { get; set; }
        public double   Custo    { get; set; }

        public Consulta(Paciente paciente, Medico medico, string data, string hora)
        {
            Paciente = paciente;
            Medico   = medico;
            Data     = data;
            Hora     = hora;
            Custo    = medico.CalcCusto(); // calculado automaticamente
        }

        public override string ToString()
        {
            return $"Data: {Data} às {Hora} | Paciente: {Paciente.Nome} | Médico: {Medico.Nome} ({Medico.Especialidade}) | Custo: {Custo}€";
        }
    }
}

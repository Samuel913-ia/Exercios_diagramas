using System;

namespace ClinicaPrivada
{
    public class Paciente : Pessoa
    {
        // Propriedade própria do Paciente
        public int NumProcesso { get; set; }

        public Paciente(string nome, int idade, char sexo, int numProcesso) : base(nome, idade, sexo)
        {
            NumProcesso = numProcesso;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Nº Processo: {NumProcesso}";
        }
    }
}

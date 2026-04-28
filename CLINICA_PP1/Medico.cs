using System;

namespace ClinicaPrivada
{
    public abstract class Medico : Pessoa
    {
        // Propriedades próprias do Médico
        public string Especialidade { get; set; }
        public string NumOrdem      { get; set; }

        public Medico(string nome, int idade, char sexo, string especialidade, string numOrdem) : base(nome, idade, sexo)
        {
            Especialidade = especialidade;
            NumOrdem      = numOrdem;
        }

        // Método abstrato - cada subclasse implementa o seu próprio cálculo
        public abstract double CalcCusto();

        public override string ToString()
        {
            return base.ToString() + $" | Especialidade: {Especialidade} | Ordem: {NumOrdem}";
        }
    }


    // ── Médico Geral ──────────────────────────────────────────
    public class MedicoGeral : Medico
    {
        public double CustoConsulta { get; set; }

        public MedicoGeral(string nome, int idade, char sexo, string numOrdem, double custoConsulta) : base(nome, idade, sexo, "Clinica Geral", numOrdem)
        {
            CustoConsulta = custoConsulta;
        }

        public override double CalcCusto()
        {
            return CustoConsulta;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Tipo: Geral | Custo: {CustoConsulta}€";
        }
    }


    // ── Médico Especialista ───────────────────────────────────
    public class MedicoEspecialista : Medico
    {
        public double CustoBase         { get; set; }
        public double TaxaEspecialidade { get; set; }

        public MedicoEspecialista(string nome, int idade, char sexo, string especialidade, string numOrdem, double custoBase, double taxaEspecialidade) : base(nome, idade, sexo, especialidade, numOrdem)
        {
            CustoBase         = custoBase;
            TaxaEspecialidade = taxaEspecialidade;
        }

        public override double CalcCusto()
        {
            return CustoBase + TaxaEspecialidade;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Tipo: Especialista | Custo: {CalcCusto()}€";
        }
    }
}

using System;

namespace ClinicaPrivada
{
    public abstract class Pessoa
    {
        // Propriedades automáticas - muito mais simples!
        public string Nome  { get; set; }
        public int    Idade { get; set; }
        public char   Sexo  { get; set; }

        public Pessoa(string nome, int idade, char sexo)
        {
            Nome  = nome;
            Idade = idade;
            Sexo  = sexo;
        }

        public override string ToString()
        {
            return $"Nome: {Nome} | Idade: {Idade} | Sexo: {Sexo}";
        }
    }
}

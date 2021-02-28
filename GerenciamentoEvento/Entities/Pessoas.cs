using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoEvento.Entities
{
    class Pessoas
    {
        public string Nome { get;private set; }
        public string Sobrenome { get;private set; }
        public string Sala { get; set; }

        public int Etapa { get; set; } = 1;
        public string EspacoCafe { get; set; }
        public Pessoas() 
        {
            
        }
        public Pessoas(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Ficará na sala: " + Sala);
            sb.AppendLine("No espaço: " + EspacoCafe);
            return sb.ToString();
        }
    }
}

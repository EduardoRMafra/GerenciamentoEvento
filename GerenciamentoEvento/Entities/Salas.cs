using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoEvento.Entities
{
    class Salas
    {
        public string NomeSala { get;set; }
        public int Lotacao { get; set; }
        public List<Pessoas> PessoasS { get; set; } = new List<Pessoas>();

        public Salas()
        {

        }
        public Salas(string nomeSala, int lotacao)
        {
            NomeSala = nomeSala;
            Lotacao = lotacao;
        }

        public void AddPessoasSala(Pessoas pessoas)
        {
            PessoasS.Add(pessoas);
        }
    }
}

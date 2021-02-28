using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoEvento.Entities
{
    class EspacosDeCafe
    {
        public string NomeDoEspaco { get; set; }
        public int Lotacao { get; set; }
        public int Etapa { get; set; }


        public List<Pessoas> PessoasC { get; set; } = new List<Pessoas>();

        public EspacosDeCafe()
        {

        }
        public EspacosDeCafe(string nomeDoEspaco, int lotacao)
        {
            NomeDoEspaco = nomeDoEspaco;
            Lotacao = lotacao;
        }

        public void AddPessoasCafe(Pessoas pessoas)
        {
            PessoasC.Add(pessoas);
        }
    }
}

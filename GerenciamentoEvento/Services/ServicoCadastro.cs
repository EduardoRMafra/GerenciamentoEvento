using System;
using System.Collections.Generic;
using System.Text;
using GerenciamentoEvento.Entities;

namespace GerenciamentoEvento.Services
{
    class ServicoCadastro
    {
        public List<Pessoas> Pessoa { get;private set; } = new List<Pessoas>();
        public List<Salas> Sala1 { get;private set; } = new List<Salas>();
        public List<Salas> Sala2 { get;private set; } = new List<Salas>();
        public List<EspacosDeCafe> Cafe1 { get;private set; } = new List<EspacosDeCafe>();
        public List<EspacosDeCafe> Cafe2 { get;private set; } = new List<EspacosDeCafe>();
        public int Etapas { get; set; } = 1;

        public int PessoasPorSala(int pessoas, int salas)
        {
            double lotacao = (double)pessoas / salas;
            lotacao = Math.Ceiling(lotacao);
            return (int)lotacao;
        }

        public void AddPessoa(Pessoas pessoa)
        {
            Pessoa.Add(pessoa);
        }
        public void AddSala1(Salas sala)
        {
            Sala1.Add(sala);
        }
        public void AddSala2(Salas sala)
        {
            Sala2.Add(sala);
        }
        public void AddEspacaoCafe1(EspacosDeCafe cafe)
        {
            Cafe1.Add(cafe);
        }
        public void AddEspacaoCafe2(EspacosDeCafe cafe)
        {
            Cafe2.Add(cafe);
        }


    }
}

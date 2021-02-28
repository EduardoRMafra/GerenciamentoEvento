using System;
using System.Collections;
using GerenciamentoEvento.Entities;
using GerenciamentoEvento.Services;

namespace GerenciamentoEvento
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicoCadastro Cadastro = new ServicoCadastro();

            string NomeSala;
            int Navegacao;

            Console.Write("Digite o numero de pessoas que deseja cadastrar: ");
            int pessoas = int.Parse(Console.ReadLine());

            for (int i = 1; i <= pessoas; i++)
            {
                Console.Write($"Digite o nome da {i}ª pessoa: ");
                string Nome = Console.ReadLine();
                Console.Write($"Digite o sobrenome da {i}ª pessoa: ");
                string Sobrenome = Console.ReadLine();

                Pessoas p = new Pessoas(Nome, Sobrenome);
                Cadastro.AddPessoa(p);
            }

            Console.Write("Digite o numero de salas que deseja cadastrar: ");
            int salas = int.Parse(Console.ReadLine());

            for (int etapa = 1; etapa <= 2; etapa++)
            {
                int k = 0;
                int t;
                for (int i = 0; i < salas; i++)
                {
                    Salas sala = new Salas();
                    if (etapa == 1)  
                    {
                        Console.Write($"Digite o nome da {i + 1}ª sala: ");
                        NomeSala = Console.ReadLine();

                        for (int j = 0; j < Cadastro.PessoasPorSala(pessoas, salas); j++)
                        {
                            if (k < Cadastro.Pessoa.Count)
                            {
                                Cadastro.Pessoa[k].Sala = NomeSala;
                                sala.AddPessoasSala(Cadastro.Pessoa[k]);
                                k++;
                            }
                        }
                        int lotacao = sala.PessoasS.Count;
                        sala.NomeSala = NomeSala;
                        sala.Lotacao = lotacao;

                        Cadastro.AddSala1(sala);
                    }
                    else
                    {

                        double troca;
                        if (Cadastro.PessoasPorSala(pessoas, salas) % 2.0 != 0)
                        {
                            troca = Math.Ceiling(Cadastro.PessoasPorSala(pessoas, salas) / 2.0);
                        }
                        else
                        {
                            troca = Cadastro.PessoasPorSala(pessoas, salas) / 2.0;
                        }

                        for (int s = 0; s < salas; s++)
                        {
                            t = s + 1;
                            if (t >= Cadastro.Sala1.Count)
                            {
                                t = 0;
                            }
                            for (int p = 0; p < Cadastro.PessoasPorSala(pessoas,salas); p++)
                            {
                                if(p < troca)
                                {
                                    sala.AddPessoasSala(Cadastro.Sala1[s].PessoasS[p]);
                                }
                                else if(p < Cadastro.Sala1[t].PessoasS.Count)
                                {
                                    sala.AddPessoasSala(Cadastro.Sala1[t].PessoasS[p]);
                                }
                            }

                            int lotacao = sala.PessoasS.Count;
                            sala.NomeSala = Cadastro.Sala1[s].PessoasS[0].Sala;
                            sala.Lotacao = lotacao;

                            if (!Cadastro.Sala2.Contains(sala))
                            {
                                Cadastro.AddSala2(sala);
                            }
                        }
                    }
                }
            }

            for (int etapa = 1; etapa <= 2; etapa++)
            {
                double troca = Cadastro.Sala1.Count % 2.0;
                if (troca != 0)
                {
                    troca = Math.Ceiling(Cadastro.Sala1.Count / 2.0);
                }
                else
                {
                    troca = Cadastro.Sala1.Count / 2.0;
                }

                for (int espaco = 1; espaco <= 2; espaco++)
                {
                    int e = espaco - 1;
                    EspacosDeCafe Espaco = new EspacosDeCafe();
                    if (etapa == 1)
                    {
                        Console.Write($"Digite o nome da {espaco}ª area do café: ");
                        string Nome = Console.ReadLine();
                        for (int sala = 0; sala < Cadastro.Sala1.Count; sala++)
                        {
                            for (int p = 0; p < Cadastro.Sala1[sala].PessoasS.Count; p++)
                            {
                                if (espaco == 1 && sala < troca)
                                {
                                    Cadastro.Sala1[sala].PessoasS[p].EspacoCafe = Nome;
                                    Espaco.AddPessoasCafe(Cadastro.Sala1[sala].PessoasS[p]);
                                }
                                else if (espaco == 2 && sala >= troca)
                                {
                                    Cadastro.Sala1[sala].PessoasS[p].EspacoCafe = Nome;
                                    Espaco.AddPessoasCafe(Cadastro.Sala1[sala].PessoasS[p]);
                                }
                            }
                        }
                        int lotacao = Espaco.PessoasC.Count;
                        Espaco.NomeDoEspaco = Nome;
                        Espaco.Lotacao = lotacao;
                        Espaco.Etapa = etapa;
                        Cadastro.AddEspacaoCafe1(Espaco);

                    }
                    else
                    {
                        for (int sala = 0; sala < Cadastro.Sala2.Count; sala++)
                        {
                            for (int p = 0; p < Cadastro.Sala2[sala].PessoasS.Count; p++)
                            {
                                if (espaco == 1 && sala < troca)
                                {
                                    Espaco.AddPessoasCafe(Cadastro.Sala2[sala].PessoasS[p]);
                                }
                                else if (espaco == 2 && sala >= troca && Cadastro.Sala2[sala].PessoasS[p] != null)
                                {
                                    Espaco.AddPessoasCafe(Cadastro.Sala2[sala].PessoasS[p]);
                                }
                            }
                        }
                        int lotacao = Espaco.PessoasC.Count;
                        Espaco.NomeDoEspaco = Cadastro.Cafe1[e].NomeDoEspaco;
                        Espaco.Lotacao = lotacao;
                        Espaco.Etapa = etapa;
                        Cadastro.AddEspacaoCafe2(Espaco);
                    }
                    
                }
            }

            Console.WriteLine();
            Console.WriteLine("Digite o numero correspondente para fazer a ação: ");
            Console.WriteLine("Pressione 1 Para verificar uma pessoa específica.");
            Console.WriteLine("Pressione 2 Para verificar uma sala específica.");
            Console.WriteLine("Pressione 3 Para verificar uma espaço de café específica.");
            Console.WriteLine("Pressione 0 Para verificar sair do programa.");
            Navegacao = int.Parse(Console.ReadLine());

            while (Navegacao != 0)
            {
                switch (Navegacao)
                {
                    case 1:
                        Console.WriteLine("Lista Pessoas: ");
                        Console.WriteLine();
                        foreach(Pessoas pes in Cadastro.Pessoa)
                        {
                            Console.WriteLine(pes.Nome + " " + pes.Sobrenome);
                        }

                        Console.Write("Digite o nome: ");
                        string primeiro = Console.ReadLine();
                        Console.Write("Digite o sobrenome: ");
                        string segundo = Console.ReadLine();
                        Console.WriteLine();
                        for (int i = 0; i < Cadastro.Sala1.Count; i++)
                        {
                           for (int j = 0; j < Cadastro.Sala1[i].PessoasS.Count; j++)
                           {
                               if (Cadastro.Sala1[i].PessoasS[j].Nome == primeiro && Cadastro.Sala1[i].PessoasS[j].Sobrenome == segundo)
                               {
                                   Console.WriteLine(" Etapa 1: \n" + Cadastro.Sala1[i].PessoasS[j] +"\n Etapa 2: \n" + Cadastro.Sala2[i].PessoasS[j]);
                               }
                           }
                         }
                        break;

                    case 2:
                        Console.WriteLine("Lista Salas: ");
                        Console.WriteLine();
                        foreach(Salas s1 in Cadastro.Sala1)
                        {
                            Console.WriteLine(s1.NomeSala);
                        }

                        Console.Write("Digite o nome da sala: ");
                        string sala = Console.ReadLine();
                        Console.WriteLine();

                        for (int i = 0; i < Cadastro.Sala1.Count; i++)
                        {
                            if(Cadastro.Sala1[i].NomeSala == sala)
                            {

                                Console.WriteLine("Etapa 1:");

                                for (int j = 0; j < Cadastro.Sala1[i].PessoasS.Count; j++)
                                {
                                        Console.WriteLine(Cadastro.Sala1[i].PessoasS[j].Nome + " " + Cadastro.Sala1[i].PessoasS[j].Sobrenome);
                                }

                                Console.WriteLine("Etapa 2:");

                                for (int j = 0; j < Cadastro.Sala1[i].PessoasS.Count; j++)
                                {
                                    Console.WriteLine(Cadastro.Sala2[i].PessoasS[j].Nome + " " + Cadastro.Sala2[i].PessoasS[j].Sobrenome);
                                }
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Lista espaço do café: ");
                        Console.WriteLine();
                        foreach (EspacosDeCafe c in Cadastro.Cafe1)
                        {
                            Console.WriteLine(c.NomeDoEspaco);
                        }

                        Console.Write("Digite o nome do espaço de café: ");
                        string espaco = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine("Etapa 1:");
                        foreach (EspacosDeCafe e1 in Cadastro.Cafe1)
                        {
                            if (e1.NomeDoEspaco == espaco)
                            {
                                e1.Etapa = 1;
                                foreach (Pessoas pes in e1.PessoasC)
                                {
                                    Console.WriteLine(pes.Nome + " " + pes.Sobrenome);
                                }
                            }
                        }

                        Console.WriteLine("Etapa 2:");
                        foreach (EspacosDeCafe e2 in Cadastro.Cafe2)
                        {
                            if (e2.NomeDoEspaco == espaco)
                            {
                                e2.Etapa = 2;
                                foreach (Pessoas pes in e2.PessoasC)
                                {
                                    Console.WriteLine(pes.Nome + " " + pes.Sobrenome);
                                }
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Valor invalido");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Digite o numero correspondente para fazer a ação: ");
                Console.WriteLine("Pressione 1 Para verificar uma pessoa específica.");
                Console.WriteLine("Pressione 2 Para verificar uma sala específica.");
                Console.WriteLine("Pressione 3 Para verificar uma espaço de café específica.");
                Console.WriteLine("Pressione 0 Para verificar sair do programa.");
                Navegacao = int.Parse(Console.ReadLine());
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace _04.ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            // GetFatorial(5);
            // GetFatorial(4);
            // GetFatorial(3);
            // GetFatorial(2);
            // GetFatorial(1);
            // GetFatorial(0);

            //RelatorioClientes.ImprimirListagemClientes();

            //MenuCaixaEletronico menu = new MenuCaixaEletronico();
            //menu.Executar();

            // var contasEspeciais = GetContasEspeciais();
            //
            // foreach (var conta in contasEspeciais)
            // {
            //     Console.WriteLine(conta.ToString());
            // }

            var resultado = ExisteContaComMaisDe50000();
            Console.WriteLine(resultado);
        }


        private static IList<Conta> GetContasEspeciais()
        {
            IList<Cliente> clientes = GetClientes();
            IList<Conta> contasEspeciais = new Collection<Conta>();

            foreach (var cliente in clientes)
            {
                foreach (var conta in cliente.Contas)
                {
                    if (conta.Saldo > 5000)
                        contasEspeciais.Add(conta);
                }
            }

            return contasEspeciais;
        }

        private static bool ExisteContaComMaisDe50000()
        {
            IList<Cliente> clientes = GetClientes();

            //TAREFA: RETORNAR VERDADEIRO OU FALSO
            //INDICANDO SE EXISTE CONTA COM MAIS DE 50 MIL DE SALDO

            foreach (var cliente in clientes)
            {
                foreach (var conta in cliente.Contas)
                {
                    if (conta.Saldo > 50000)
                        return true;
                }
            }
            
            return false;
        }

        private static IList<Cliente> GetClientes()
        {
            IList<Cliente> clientes = new List<Cliente>();
            IList<Conta> contas1 = new List<Conta>
            {
                new Conta(1000m, 2, 0.025m),
                new Conta(30000m, 4, 0.045m),
                new Conta(50000m, 6, 0.045m)
            };

            clientes.Add(new Cliente("José", "da Silva", contas1));

            IList<Conta> contas2 = new List<Conta>
            {
                new Conta(400m, 2, 0.025m),
                new Conta(3000m, 4, 0.045m),
                new Conta(75000m, 6, 0.045m)
            };
            clientes.Add(new Cliente("Maria", "de Souza", contas2));
            return clientes;
        }

        private static int GetFatorial(int numero)
        {
            //FATORIAL DE 5 = 5 x 4 x 3 x 2 x 1  = 120
            //FATORIAL DE 4 = 4 x 3 x 2 x 1      = 24
            //FATORIAL DE 3 = 3 x 2 x 1          = 6
            //FATORIAL DE 2 = 2 x 1              = 2 
            //FATORIAL DE 1                      = 1
            //FATORIAL DE 0                      = 1 

            int fatorial = 1;

            for (int fator = numero; fator >= 1; fator--)
            {
                fatorial = fatorial * fator;
            }
            
            System.Console.WriteLine($"fatorial de {numero} é {fatorial}");

            return fatorial;
        }
    }

    class Conta
    {
        public Conta(decimal saldo, int periodo, decimal juros)
        {
            Periodo = periodo;
            Saldo = saldo;
            Juros = juros;
        }
        public decimal Saldo { get; set; }
        public decimal Juros { get; set; }
        public int Periodo { get; set; }
    }

    class Cliente
    {
        public Cliente(string nome, string sobrenome, IList<Conta> contas)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Contas = contas;
        }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public IList<Conta> Contas { get; set; }
    }
}

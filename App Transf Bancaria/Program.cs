using System;
using System.Collections.Generic;

namespace App_Transf_Bancaria
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string menuUsuario = Menu();

            while (menuUsuario.ToUpper() != "X")
            {
                switch (menuUsuario)
                {
                    case "1":
                        ListaDeContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferencia();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "L":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                menuUsuario = Menu();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.WriteLine("Pressione qualquer tecla para sair da Aplicação");
            Console.ReadKey();
        }

        private static void Transferencia()
        {
            Console.Write("Qual o indice da conta origem ? ");
            int indice = int.Parse(Console.ReadLine());

            Console.Write("Qual o indice da conta do destinatario ? ");
            int indiceDest = int.Parse(Console.ReadLine());

            Console.Write("Valor da transferencia ");
            double transferencia = double.Parse(Console.ReadLine());

            listaContas[indice].Transferencia(transferencia, listaContas[indiceDest]);

        }
        private static void Sacar()
        {
            Console.WriteLine("Saque");
            Console.WriteLine("Digite o Indice da Conta");
            int nConta = int.Parse(Console.ReadLine());

            Console.Write("Valor para Saque : ");
            double saq = double.Parse(Console.ReadLine());

            listaContas[nConta].Sacar(saq);
           
        }
        private static void Depositar()
        {
            Console.WriteLine("Deposito");
            Console.WriteLine("Digite o Indice da Conta");
            int nConta = int.Parse(Console.ReadLine());

            Console.Write("Valor para Deposito : ");
            double saq = double.Parse(Console.ReadLine());

            listaContas[nConta].Depositar(saq);

        }
        private static void InserirConta()
        {
            Console.WriteLine("Digite 1 para pessoa Fisica ou 2 para pessoa Juridica");
            int tipoC = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente : ");
            string nomeTitular = Console.ReadLine();

            Console.Write("ID da Conta : ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do saldo inicial : ");
            double saldo = double.Parse(Console.ReadLine());

            Console.Write("Valor do Credito Especial : ");
            double credito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta((TipoConta)tipoC, nomeTitular, id, saldo, credito);

            listaContas.Add(novaConta);
        }


        private static void ListaDeContas()
        {
            Console.WriteLine("Lista de Contas");
            Console.WriteLine();
            
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Ainda não existe nenhuma conta cadastrada");
                return;
            }

            for(int i =0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.WriteLine($"{i} {conta} " );
            }


        }
        public static string Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Que operação deseja realizar ?");
            Console.WriteLine();
            Console.WriteLine("1 - Lista de Contas");
            Console.WriteLine("2 - Inserir uma nova Conta");
            Console.WriteLine("3 - Realizar Trasnferencia Bancaria");
            Console.WriteLine("4 - Saque");
            Console.WriteLine("5 - Deposito");
            Console.WriteLine("L - Limpar tela ");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string menuUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return menuUsuario;
        }
    }
}

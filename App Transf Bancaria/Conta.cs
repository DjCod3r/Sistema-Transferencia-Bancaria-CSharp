using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Transf_Bancaria
{
    class Conta
    {
        private TipoConta TipoConta { get; set; }
        private string NOME { get; set; }
        public int ID { get;private set; }
        private double SALDO { get; set; }
        private double CREDITO { get; set; }

        public Conta(TipoConta tipoConta, string nome, int id, double saldo, double credito)
        {
            TipoConta = tipoConta;
            NOME = nome;
            ID = id;
            SALDO = saldo;
            CREDITO = credito;
        }


        public bool Sacar(double valorSaque)
        {
            if(SALDO - valorSaque < (CREDITO * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            SALDO -= valorSaque;
            Console.WriteLine($"Titular da Conta: {NOME} , Saldo atual: {SALDO}");

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            SALDO += valorDeposito;
            Console.WriteLine($"Titular da Conta: {NOME} , Saldo atual: {SALDO}");
        }

        public void Transferencia(double valorTransferencia, Conta destinatario)
        {
            if (Sacar(valorTransferencia))
            {
                destinatario.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            return $"Conta: {ID} , Titular: {NOME}, Saldo: {SALDO}, Creditos: {CREDITO} ";
        }
        
       
    }
}

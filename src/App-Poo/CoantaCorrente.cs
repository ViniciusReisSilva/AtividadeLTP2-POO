using System;

namespace App_Poo
{
    public class ContaCorrente : ContaBancaria
    {        
        public double Limite { get; set; }

        public ContaCorrente(string numeroDaConta, 
                             string numeroDaAgencia,
                             double saldo,
                             double limite) 
                             : base (numeroDaConta, numeroDaAgencia, saldo)
        {
            Limite = limite;
        }

        public override void ImprimirSaldo()
        {
            base.ImprimirSaldo();
            Console.WriteLine($"Limite...........: {Limite:C}");
            Console.WriteLine($"Saldo+Limite.....: {Limite+Saldo:C}");
        }

        public override void Depositar(double valorDeposito)
        {
            if (Limite < 0 && Saldo == 0)
            {
                // Escrever a lógica do depositar pra Contas que tem limite.
            }
            base.Depositar(valorDeposito);
        }

        public override double Sacar(double valorSaque)
        {
            if (valorSaque > (Saldo+Limite))
            {
                Console.WriteLine($"Saldo insuficiente para o saque.\n\nSaque não realizado. Valor do saque:{valorSaque:c}");
                return 0.00;
            }
            else
            {
                if (valorSaque > Saldo)
                {                    
                    Limite = Saldo - valorSaque;
                    Saldo = 0.00;
                }
                else
                {
                    Saldo -= valorSaque;
                }

                return valorSaque;
            }   
        }
    }
}
using System;

namespace App_Poo
{
    public class ContaInvestimento : ContaCorrente
    {        
        public double Rendimento { get; set; }

        public ContaInvestimento(string numeroDaConta, 
                             string numeroDaAgencia,
                             double saldo,
                             double limite) 
                             : base (numeroDaConta, numeroDaAgencia, saldo, limite)
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
            Rendimento = (100.0 / valorDeposito ) * 10;

            valorDeposito = valorDeposito + Rendimento;

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
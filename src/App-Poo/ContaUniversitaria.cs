using System;

namespace App_Poo
{
    public class ContaUniversitaria : ContaCorrente
    {   
        private static double Percentual(double value, double total)
            {
                return (100.0 / total ) * value;
            }
        public ContaUniversitaria(string numeroDaConta, 
                                  string numeroDaAgencia,
                                  double saldo,
                                  double limite) 
                                  : base (numeroDaConta, numeroDaAgencia, saldo, limite)
       {
           if (limite > 1000)
            Console.WriteLine("Limite não permitido para o tipo de conta.");
       }
        public override void Depositar(double valorDeposito)
        {
            if (valorDeposito > 1000)
            {
                Console.WriteLine("Limite não permitido para o tipo de conta.");
            }
            else
            {
            base.Depositar(valorDeposito);
            }
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
                if ((100.0 / (Saldo+Limite) ) * valorSaque > 90)
                {                    
                    Console.WriteLine("Não é possivel sacar mais que 90% do valor disponivel");
                    return 0.00;
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
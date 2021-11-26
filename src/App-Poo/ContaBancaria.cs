using System;

namespace App_Poo
{
    public abstract class ContaBancaria
    {
        public string NumeroDaConta { get; private set; }
        public string NumeroDaAgencia { get; private set; }
        public double Saldo { get; protected set; }

        public ContaBancaria(string numeroDaConta, 
                             string numeroDaAgencia,
                             double saldo)
        {
            NumeroDaConta = numeroDaConta;
            NumeroDaAgencia = numeroDaAgencia;
            Saldo = saldo;            
        }

        public virtual void Depositar(double valorDeposito) 
        {
            Saldo += valorDeposito;
        }

        public virtual double Sacar(double valorSaque)
        {
            if (valorSaque > Saldo)
            {
                Console.WriteLine($"Saldo insuficiente para o saque.\n\nSaque não realizado. Valor do saque:{valorSaque:c}");
                return 0.00;
            }
            else
            {
                Saldo -= valorSaque;
                return valorSaque;
            }            
        }

        public virtual void Transferir(ContaBancaria contaDestino, double valor)
        {
            double vlr = Sacar(valor);
            
            if (vlr > 0)
            {
                contaDestino.Depositar(valor);
                Console.WriteLine($"Transferência realizada com sucesso.");
                Console.WriteLine($"Conta de Origem.: {this.NumeroDaConta} Agência da Conta de Origem: {this.NumeroDaAgencia}.");
                Console.WriteLine($"Conta de Destino: {contaDestino.NumeroDaConta} Agência da Conta de Origem: {contaDestino.NumeroDaAgencia}.");
                Console.WriteLine($"Valor Transferência: {valor:c}");
            }
            else 
            {
                Console.WriteLine($"Não foi possível realizar a transferência.");
            }
        }

        public virtual void Transferir(ContaBancaria contaDestino)
        {
            Transferir(contaDestino, Saldo);
        }

        public virtual void ImprimirSaldo()
        {
            Console.WriteLine("");
            Console.WriteLine($"{this.GetType()}");
            Console.WriteLine($"Numero da conta..: {NumeroDaConta}");
            Console.WriteLine($"Numero da agência: {NumeroDaAgencia}");
            Console.WriteLine($"Saldo............: {Saldo:C}");
        }
    }
}
using System;

namespace App_Poo
{
    class Program
    {
        static void Main(string[] args)
        {
            var contaDoSillas = new ContaUniversitaria("8888", "10101", 1000000, 1000);

            contaDoSillas.Sacar(900900);

            contaDoSillas.ImprimirSaldo();

            var contadoLucyano = new ContaInvestimento("2222", "121212", 0, 10000.00);

            contadoLucyano.Depositar(100);

            contadoLucyano.ImprimirSaldo();
            
        }
    }
}

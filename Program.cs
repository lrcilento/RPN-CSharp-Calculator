using System;

namespace RPN_CSharp_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool more = true;
            Console.WriteLine("Sintaxe:");
            Console.WriteLine("Adição: + | Subtração: - | Multiplicação: * | Divisão: / | Potencialização: ^ | Fatorial (até 10): !");
            Console.WriteLine("Parenteses não são necessários, mas são aceitos. Números não-inteiros são representados com '.' ou ','.\n");
            while (more)
            {
                Console.WriteLine("Favor inserir a equação a ser resolvida: ");
                string equation = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Deseja ver a RPN (notação polonesa reversa)? (s/N)");
                string writeRPN = Console.ReadLine();
                Console.WriteLine();
                if (writeRPN.Contains("s") || writeRPN.Contains("S") || writeRPN.Contains("y") || writeRPN.Contains("Y"))
                {
                    Console.WriteLine("RPN: " + Calculator.rpn(equation));
                    Console.WriteLine();
                }
                Console.WriteLine("Resultado: " + Calculator.calculate(Calculator.rpn(equation)));
                Console.WriteLine();
                Console.WriteLine("Deseja continuar? (s/N)\n");
                string cont = Console.ReadLine();
                Console.WriteLine();
                if (!cont.Contains("s") && !cont.Contains("S") && !cont.Contains("y") && !cont.Contains("Y"))
                {
                    more = false;
                }
            }
            Console.ReadKey();
        }
    }
}

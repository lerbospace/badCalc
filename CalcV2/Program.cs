using System;
using System.Collections.Generic;

namespace CalcV2
{
    class program
    {
        public static void Main(String[] args)
        {
            Calculator calc  = new Calculator();
            string consoleInput = Console.ReadLine();
            calc.Calculate(consoleInput);
        }
    }
}
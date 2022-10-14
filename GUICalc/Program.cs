using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace CalcV2
{
    internal class Power
    {
        public double Do(float a, float b)
        {
            return Math.Pow(a, b);
        }
    }
    internal class Divide
    {
        public float Do(float a, float b)
        {
            return a / b;
        }
    }
    internal class Multiply
    {
        public float Do(float a, float b)
        {
            return a * b;
        }
    }

    internal class Add
    {
        public float Do(float a, float b)
        {
            return a + b;
        }
    }

    internal class Minus
    {
        public float Do(float a, float b)
        {
            return a - b;
        }
    }
    
    class program
    {
        public static void Main(String[] args)
        {
            Calculator calc = new Calculator();
            Console.WriteLine("Enter equations into the calcualtor by typing then pressing enter");
            Console.WriteLine("follows standard order of operations");
            Console.WriteLine("valid symbols are plus(+), minus(-), multiple(*), divide(/) and exponents($)");
            Console.WriteLine("Brackets are not supported");
            Console.WriteLine("Enter q/Q to quit the program");
            for (; ; )
            {
                Console.Write("> ");
                string consoleInput = Console.ReadLine();
                if (consoleInput.ToLower().Contains('q'))
                {
                    Console.WriteLine("Exiting program");
                    Environment.Exit(0);
                }
                string result = calc.Calculate(consoleInput);
                Console.WriteLine(result);
            }
        }
    }
}
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
    internal class Calculator
    {
        Add add;
        Minus minus;
        Multiply multiply;
        Divide divide;
        Power power;
        public Calculator()
        {
            add = new Add();
            minus = new Minus();
            multiply = new Multiply();
            divide = new Divide();
            power = new Power();
        }
        public string Calculate(string ConsoleInput)
        {
            ConsoleInput = ConsoleInput.Replace('=', ' ');
            List<string> splitInput = Regex.Split(ConsoleInput, @"\s*([=+-/*$])\s*").ToList();
            splitInput.RemoveAll(inputindex => string.IsNullOrWhiteSpace(inputindex));

            splitInput = SimplifyPM(splitInput);
            splitInput = SimplifyConsecutiveSign(splitInput);

            string result = EvaluateInput(splitInput);
            return result;
        }

        private string EvaluateInput(List<string> input)
        {
            try
            {
                input = ExpOrder(input);
                input = MDOrder(input);
                input = PMOrder(input);


                if (input.Count != 0)
                {
                    float.Parse(input[0]);
                    return input[0];
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error in input");
                return ex.Message;
            }
            return "Invalid input";

        }
        private List<string> ExpOrder(List<string> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == "$")
                {
                    input[i] = (power.Do(float.Parse(input[i - 1]), float.Parse(input[i + 1]))).ToString();
                    input.RemoveAt(i - 1);
                    input.RemoveAt(i);
                    if (input.Count != 1)
                    {
                        i = 0;
                    }
                }
            }
            return input;
        }

        private List<string> MDOrder(List<string> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                switch (input[i])
                {
                    case "*":
                        input[i] = (multiply.Do(float.Parse(input[i - 1]), float.Parse(input[i + 1]))).ToString();
                        input.RemoveAt(i - 1);
                        input.RemoveAt(i);
                        if (input.Count != 1)
                        {
                            i = 0;
                        }
                        break;
                    case "/":
                        input[i] = (divide.Do(float.Parse(input[i - 1]), float.Parse(input[i + 1]))).ToString();
                        input.RemoveAt(i - 1);
                        input.RemoveAt(i);
                        if (input.Count != 1)
                        {
                            i = 0;
                        }
                        break;
                }


            }
            return input;
        }

        private List<string> PMOrder(List<string> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                switch (input[i])
                {
                    case "+":
                        input[i] = (add.Do(float.Parse(input[i - 1]), float.Parse(input[i + 1]))).ToString();
                        input.RemoveAt(i - 1);
                        input.RemoveAt(i);
                        if (input.Count != 1)
                        {
                            i = 0;
                        }
                        break;
                    case "-":
                        input[i] = (minus.Do(float.Parse(input[i - 1]), float.Parse(input[i + 1]))).ToString();
                        input.RemoveAt(i - 1);
                        input.RemoveAt(i);
                        if (input.Count != 1)
                        {
                            i = 0;
                        }
                        break;
                }

            }
            return input;
        }

        private List<string> SimplifyConsecutiveSign(List<string> input)
        {
            string[] check = { "+", "-", "*", "/", "^" };

            for (int i = 1; i < input.Count; i++)
            {

                if (check.Contains(input[i - 1]) && input[i] == "-")
                {
                    int.TryParse(input[i + 1], out int n);
                    input[i + 1] = (n * -1).ToString();
                    input.RemoveAt(i);
                }

                if (check.Contains(input[i - 1]) && input[i] == "+")
                {
                    int.TryParse(input[i + 1], out int n);
                    input[i + 1] = (n * 1).ToString();
                    input.RemoveAt(i);
                }
            }
            return input;
        }
        private List<string> SimplifyPM(List<string> input)
        {

            string[] checkpm = { "+", "-" };


            for (int i = 1; i < input.Count; i++)
            {

                if (checkpm.Contains(input[i - 1]) && input[i] == "+")
                {
                    input.RemoveAt(i);
                    i--;

                }

                if (checkpm.Contains(input[i - 1]) && input[i] == "-")
                {
                    if (input[i - 1] == "-" && input[i] == "-")
                    {
                        input[i] = "+";
                        input.RemoveAt(i - 1);
                        i--;

                    }

                    else if (input[i - 1] == "+" && input[i] == "-")
                    {
                        input.RemoveAt(i - 1);
                        i--;
                    }
                }

            }


            if (input.Count != 0)
            {

                if (input[0] == "-")
                {
                    int.TryParse(input[1], out int n);
                    input[1] = (n * -1).ToString();
                    input.RemoveAt(0);

                }
                if (input[0] == "+")
                {
                    int.TryParse(input[1], out int n);
                    input[1] = (n * 1).ToString();
                    input.RemoveAt(0);
                    int.Parse(input[0]);
                }

            }

            return input;
        }
    }
    class program
    {
        public static void Main(String[] args)
        {
            Calculator calc  = new Calculator();
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
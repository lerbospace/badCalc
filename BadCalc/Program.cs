using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;

namespace BadCalc
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
    internal class UI
    {

        Add add;
        Minus minus;
        Multiply multiply;
        Divide divide;
        Power power;

        public UI()
        {
            add = new Add();
            minus = new Minus();
            multiply = new Multiply();
            divide = new Divide();
            power = new Power();
        }



      


        public void Run()
        {
           
            Console.WriteLine("Enter equations into the calcualtor by typing then pressing enter");
            Console.WriteLine("Does not follow order of operations");
            Console.WriteLine("valid symbols are plus(+), minus(-), multiple(*), divide(/) and exponents($)");
            Console.WriteLine("Enter q/Q to quit the program");
            string[] check = { "+","-", "*", "/", "$" };
            
            for (int j = 10; j > 1; j++)
            {

                Console.Write("> ");
                string input = Console.ReadLine();

                input = input.Replace('=',' ');

                if (input.ToLower().Contains("q"))
                {
                    Environment.Exit(0);
                }


                List<string> splitInput = (Regex.Split(input, @"\s*([-+/*$])\s*")).ToList();
                splitInput.RemoveAll(inputindex => string.IsNullOrWhiteSpace(inputindex));


                for (int i = 1; i < splitInput.Count; i++)
                {
                    if (check.Contains(splitInput[i - 1]) && splitInput[i] == "-")
                    {
                        int.TryParse(splitInput[i + 1], out int n);
                        splitInput[i + 1] = (n * -1).ToString();
                        splitInput.RemoveAt(i);
                    }

                    if (check.Contains(splitInput[i - 1]) && splitInput[i] == "+")
                    {
                        int.TryParse(splitInput[i + 1], out int n);
                        splitInput[i + 1] = (n * 1).ToString();
                        splitInput.RemoveAt(i);
                    }



                }

              
                try
                {

                    if (splitInput.Count != 0)
                    {


                        if (splitInput[0] == "-")
                        {
                            int.TryParse(splitInput[1], out int n);
                            splitInput[1] = (n * -1).ToString();
                            splitInput.RemoveAt(0);

                        }
                        if (splitInput[0] == "+")
                        {
                            int.TryParse(splitInput[1], out int n);
                            splitInput[1] = (n * 1).ToString();
                            splitInput.RemoveAt(0);
                            int.Parse(splitInput[0]);
                        }
                        if (splitInput[splitInput.Count - 1] == "=")
                        {
                            splitInput.RemoveAt(splitInput.Count - 1);
                        }
                       
                        int.Parse(splitInput[0]);
                    }

                    for (int i = 0; i < splitInput.Count; i++)
                    {
                        switch (splitInput[i])
                        {
                            case "+":
                                splitInput[i] = (add.Do(float.Parse(splitInput[i - 1]), float.Parse(splitInput[i + 1]))).ToString();
                                splitInput.RemoveAt(i - 1);
                                splitInput.RemoveAt(i);
                                if (splitInput.Count != 1)
                                {
                                    i = 0;
                                }

                                break;
                            case "-":
                                splitInput[i] = (minus.Do(float.Parse(splitInput[i - 1]), float.Parse(splitInput[i + 1]))).ToString();
                                splitInput.RemoveAt(i - 1);
                                splitInput.RemoveAt(i);
                                if (splitInput.Count != 1)
                                {
                                    i = 0;
                                }

                                break;
                            case "*":
                                splitInput[i] = (multiply.Do(float.Parse(splitInput[i - 1]), float.Parse(splitInput[i + 1]))).ToString();
                                splitInput.RemoveAt(i - 1);
                                splitInput.RemoveAt(i);
                                if (splitInput.Count != 1)
                                {
                                    i = 0;
                                }

                                break;
                            case "/":
                                splitInput[i] = (divide.Do(float.Parse(splitInput[i - 1]), float.Parse(splitInput[i + 1]))).ToString();
                                splitInput.RemoveAt(i - 1);
                                splitInput.RemoveAt(i);
                                if (splitInput.Count != 1)
                                {
                                    i = 0;
                                }

                                break;
                            case "$":
                                splitInput[i] = (power.Do(float.Parse(splitInput[i - 1]), float.Parse(splitInput[i + 1]))).ToString();
                                splitInput.RemoveAt(i - 1);
                                splitInput.RemoveAt(i);
                                if (splitInput.Count != 1)
                                {
                                    i = 0;
                                }

                                break;

                        }
                    }

                }

                catch (Exception e)
                {
                    Console.WriteLine("Invalid input");
                    splitInput[0] = " ";
                }
                if (splitInput.Count != 0)
                {
                    Console.WriteLine("> {0}", splitInput[0]);
                }


            }
        }
    }
    public class program
    {
        public static void Main(String[] args)
        {
            UI ui = new UI();
            ui.Run();

        }
    }
}

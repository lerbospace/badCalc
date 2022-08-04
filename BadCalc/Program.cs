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



        public List<string> expOrder(List<string> splitInput)
        {
            for (int i = 0; i < splitInput.Count; i++)
            {
                if (splitInput[i] == "^")
                {
                    splitInput[i] = (power.Do(float.Parse(splitInput[i - 1]), float.Parse(splitInput[i + 1]))).ToString();
                    splitInput.RemoveAt(i - 1);
                    splitInput.RemoveAt(i);
                    if (splitInput.Count != 1)
                    {
                        i = 0;
                    }
                }
            }
            return splitInput;
        }

        public List<string> MDOrder(List<string> splitInput)
        {
            for (int i = 0; i < splitInput.Count; i++)
            {
                switch (splitInput[i])
                {
                    case "*":
                        float a = float.Parse(splitInput[i - 1]);
                        float b = float.Parse(splitInput[i + 1]);
                        float c = multiply.Do(a, b);
                        string d = c.ToString();
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
                }


            }
            return splitInput;
        }

        public List<string> PMOrder(List<string> splitInput)
        {
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
                }

            }
            return splitInput;
        }


        public string DoMath(string input)
        {


            List<string> splitInput = Regex.Split(input, @"\s*([-+/*^])\s*").ToList();
            splitInput.RemoveAll(inputindex => string.IsNullOrWhiteSpace(inputindex));

            string[] check = { "+", "-", "*", "/", "^" };
            string[] checkpm = { "+", "-" };
            for (int i = 1; i < splitInput.Count; i++)
            {

                if (checkpm.Contains(splitInput[i - 1]) && splitInput[i] == "+")
                {
                    splitInput.RemoveAt(i);
                    i--;
                }
                if (checkpm.Contains(splitInput[i - 1]) && splitInput[i] == "-")
                {
                    if (splitInput[i - 1] == "+")
                    {
                        splitInput.RemoveAt(i - 1);
                        i--;
                    }
                    else if (splitInput[i - 1] == "-")
                    {
                        splitInput[i] = "+";
                        splitInput.RemoveAt(i - 1);
                        i--;
                    }

                }
            }

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



            }


            // try
            //{

            splitInput = expOrder(splitInput);
            splitInput = MDOrder(splitInput);
            splitInput = PMOrder(splitInput);

            if (splitInput.Count != 0)
            {
                float.Parse(splitInput[0]);
            }





            /*  }

              catch (Exception e)
              {
                  Console.WriteLine("Do math error");
                  splitInput[0] = " ";
              }*/
            if (splitInput.Count != 0)
            {
                return splitInput[0];
            }
            return null;

        }


        string BracketRecurse(List<string> input, int start)
        {

            int end = input.Count;
            for (int i = start; i < end; i++)
            {
                if (input[i] == "(")
                {
                    BracketRecurse(input, i + 1);
                    end = input.Count;
                }
                if (input[i] == ")")
                {
                    end = i;
                }
            }

            if (input[start - 1] != "(")
            {
                input[start - 1] = String.Concat(input[start - 1], input[start]);
                input.RemoveAt(start);
                start--;
            }
            if (input[start + 1] != ")")
            {
                input[start] = String.Concat(input[start], input[start + 1]);
                input.RemoveAt(start + 1);

            }
            input[start + 1] = DoMath(input[start]);

            input.RemoveAt(start - 1);
            // Console.WriteLine(input[start+1]);
            input.RemoveAt(start - 1);

            return input[start - 1];
        }


        public List<string> BracketRecurseNoMath(List<string> input, int start, int top)
        {
            int end = input.Count;
            for (int i = start; i < end; i++)
            {
                if (input[i] == "(")
                {
                    BracketRecurseNoMath(input, i + 1, top + 1);
                }
                if (input[i] == ")")
                {
                    end = i;
                }
            }
            if (top == 0)
            {
                input.Insert(end + 1, ")");
            }

            return input;
        }

        public void Run()
        {

            Console.WriteLine("Enter equations into the calcualtor by typing then pressing enter");
            Console.WriteLine("Does not follow order of operations");
            Console.WriteLine("valid symbols are plus(+), minus(-), multiple(*), divide(/) and exponents(^)");
            Console.WriteLine("Enter q/Q to quit the program");


            for (int j = 10; j > 1; j++)
            {

                Console.Write("> ");
                string input = Console.ReadLine();



                if (input.ToLower().Contains("q"))
                {
                    Environment.Exit(0);
                }



                List<string> splitInputBracket = (Regex.Split(input, @"\s*([()])\s*")).ToList();
                splitInputBracket.RemoveAll(inputindex => string.IsNullOrWhiteSpace(inputindex));
                char[] check = { '+', '-', '*', '/', '^' };
                if (splitInputBracket[splitInputBracket.Count - 1][splitInputBracket[splitInputBracket.Count - 1].Length - 1] == '=')
                {
                    //to implement variables
                }

                for (int i = 1; i < splitInputBracket.Count - 1; i++)
                {
                    
                    if (splitInputBracket[i] == "(" && !check.Contains(splitInputBracket[i - 1][splitInputBracket[i - 1].Length - 1]) && splitInputBracket[i - 1] != "(")
                    {
                        splitInputBracket[i - 1] = String.Concat(String.Format("{0}", splitInputBracket[i - 1]), "*");
                        List<string> temp = splitInputBracket.ToList();
                        for (int ch = splitInputBracket[i - 1].Length - 2; ch > 0; ch--)
                        {
                            if (check.Contains(splitInputBracket[i - 1][ch]))
                            {
                                string temp0 = splitInputBracket[i - 1].Substring(0, ch+1);
                                string temp1 = splitInputBracket[i - 1].Substring(ch+1);
                                splitInputBracket[i - 1] = temp0;
                                splitInputBracket.Insert(i, temp1);
                                splitInputBracket.Insert(i, "(");
                                
                            }
                            //splitInputBracket.Insert(i - 1, "(");



                        }
                        if (temp != splitInputBracket)
                        {
                            splitInputBracket = BracketRecurseNoMath(splitInputBracket, i + 1, 0);
                        }
                    }

                    if (splitInputBracket[i] == ")" && !check.Contains(splitInputBracket[i + 1][0]) && splitInputBracket[i + 1] != ")")
                    {
                        splitInputBracket[i + 1] = String.Concat(String.Format("{0}", splitInputBracket[i + 1]), "*");
                        splitInputBracket.Insert(i + 1, ")");
                        splitInputBracket = BracketRecurseNoMath(splitInputBracket, i + 1, 0);

                    }
                }


                // try
                //{

                for (int i = 0; i < splitInputBracket.Count; i++)
                {
                    if (splitInputBracket[i] == "(")
                    {
                        splitInputBracket[i] = BracketRecurse(splitInputBracket, i + 1);

                        if (i != 0)
                        {
                            splitInputBracket[i - 1] = String.Concat(splitInputBracket[i - 1], splitInputBracket[i]);
                            splitInputBracket.RemoveAt(i);
                            i--;

                        }
                        if (i != splitInputBracket.Count - 1)
                        {
                            splitInputBracket[i] = String.Concat(splitInputBracket[i], splitInputBracket[i + 1]);
                            splitInputBracket.RemoveAt(i + 1);
                        }



                    }
                }
                if (splitInputBracket.Count != 0)
                {
                    splitInputBracket[0] = DoMath(splitInputBracket[0]);
                }
                /*}
                 /catch (Exception ex)
                 /{
                     if (splitInputBracket.Count != 0)
                     {
                         Console.WriteLine("Invalid input");
                     }
                 }*/

                if (splitInputBracket.Count != 0)
                {
                    Console.WriteLine(splitInputBracket[0]);
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
    

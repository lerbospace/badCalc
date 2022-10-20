using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GUICalc
{
    internal class Calculator
    {

        //Global checks
        string[] opperand = new string[] { "+", "-", "*", "/", "^" };
        string[] bracket = new string[] { "(", ")" };

        public Calculator()
        {

        }
        public string Calculate(string ConsoleInput)
        {
            //PreParse
            ConsoleInput = ConsoleInput.Replace('=', ' ');
            List<string> splitInput = Regex.Split(ConsoleInput, @"\s*([-+/*^()])\s*").ToList();
            splitInput.RemoveAll(inputindex => string.IsNullOrWhiteSpace(inputindex));

            
            if (splitInput.Contains("(") | splitInput.Contains(")"))
            {
                splitInput = EvaluateBrackets(splitInput);
            }

            string result = EvaluateInput(splitInput);
            return result;
        }

        private List<string> EvaluateBrackets(List<string> splitInput)
        {
            //Pre procces
            splitInput = SimplifyPM(splitInput);
            splitInput = SimplifyConsecutiveSign(splitInput);
            splitInput = SimplifyImplicetMult(splitInput);
            List<List<string>> splitBracket = SplitBrackets(splitInput);
            splitInput = ParseBrackets(splitBracket);
            return splitInput;


            //ParseBrackets(splitInput);
        }

        private List<string> SimplifyImplicetMult(List<string> implicetInput)
        {
            for(int i = 0; i < implicetInput.Count-1; i++)
            {
                if (!opperand.Contains(implicetInput[i]) & !bracket.Contains(implicetInput[i])  & implicetInput[i+1] == "(")
                {
                    //32()
                    implicetInput.Insert(i, "(");
                    implicetInput.Insert(i + 2, "*");
                    
                    int open = 1;
                    int close = 0;
                    for(int j = i+3; j < implicetInput.Count; j++)
                    {
                        if (implicetInput[j] == "(")
                        {
                            open++;
                        }
                        if (implicetInput[j] == ")")
                        {
                            close++;
                        }
                        if (open == close + 1)
                        {
                            implicetInput.Insert(j+1,")");
                        }
                    }
                    //(34*()
                }

                if(implicetInput[i] == ")" & !opperand.Contains(implicetInput[i+1]) & !bracket.Contains(implicetInput[i + 1]))
                {

                    //()32
                    implicetInput.Insert(i+1, "*");                   
                    implicetInput.Insert(i + 3, ")");
                

                  
                    int open = 0;
                    int close = 1;
                    for (int j = i; j > -1; j--)
                    {
                        if (implicetInput[j] == "(")
                        {
                            open++;
                        }
                        if (implicetInput[j] == ")")
                        {
                            close++;
                        }
                        if (close == open+1 & j !=implicetInput.Count-1)
                        {
                            implicetInput.Insert(j, "(");
                            break;
                        }
                    }
                }

                if(implicetInput[i] == ")" & implicetInput[i+1] == "(")
                {
                    implicetInput.Insert(i+1,"*");
                }
            }

            return implicetInput;
        }
        private List<string> ParseBrackets(List<List<string>> bracketSplit)
        {

            for (int i = 0; i < bracketSplit.Count; i++)
            {
                if(bracketSplit[i][0] == "(" & bracketSplit[i].Last() == ")")
                {
                    string result = EvaluateInput(bracketSplit[i].GetRange(1, bracketSplit[i].Count-2));
                    bracketSplit[i].Clear();
                    bracketSplit[i].Add(result);

                }
            }
            List<string> L = new List<string> {};
            foreach (List<string> index in bracketSplit)
            {
                L.AddRange(index);
            }
            if (L.Contains("(") || L.Contains(")"))
            {
                L = ParseBrackets(SplitBrackets(L));
            }

            return L;

        }
        private List<List<string>> SplitBrackets(List<string> splitInput)
        {
            List<List<string>> bracketSplit = new List<List<string>>();
            bracketSplit.Add(new List<string>());
            bracketSplit[0].Add(splitInput[0]);
            for (int i = 1, j = 0; i < splitInput.Count; i++)
            {

                if (splitInput[i] == "(")
                {
                    bracketSplit.Add(new List<string>());
                    j += 1;

                }
                bracketSplit[j].Add(splitInput[i]);
                if (splitInput[i] == ")")
                {
                    bracketSplit.Add(new List<string>());
                    j += 1;

                }
            }
            bracketSplit.RemoveAll(inputindex => inputindex.Count == 0);
            return bracketSplit;

        }

        private string EvaluateInput(List<string> input)
        {
            try
            {
                input = SimplifyPM(input);
                input = SimplifyConsecutiveSign(input);
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
                if (input[i] == "^")
                {
                    input[i] = Math.Pow(float.Parse(input[i - 1]), float.Parse(input[i + 1])).ToString();
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
                        input[i] = (float.Parse(input[i - 1]) * float.Parse(input[i + 1])).ToString();
                        input.RemoveAt(i - 1);
                        input.RemoveAt(i);
                        if (input.Count != 1)
                        {
                            i = 0;
                        }
                        break;
                    case "/":
                        input[i] = (float.Parse(input[i - 1]) / float.Parse(input[i + 1])).ToString();
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
                        input[i] = (float.Parse(input[i - 1]) + float.Parse(input[i + 1])).ToString();
                        input.RemoveAt(i - 1);
                        input.RemoveAt(i);
                        if (input.Count != 1)
                        {
                            i = 0;
                        }
                        break;
                    case "-":
                        input[i] = (float.Parse(input[i - 1]) - float.Parse(input[i + 1])).ToString();
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
}

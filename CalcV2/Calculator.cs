using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CalcV2
{
    internal class Calculator
    {

        public void Calculate(string ConsoleInput)
        {
            List<string> splitInput = Regex.Split(ConsoleInput, @"\s*([()=+-/*^])\s*").ToList();
            splitInput.RemoveAll(inputindex => string.IsNullOrWhiteSpace(inputindex));
          
            splitInput = SimplifyPM(splitInput);

            foreach (string str in splitInput)
            {
                Console.WriteLine(" index {0}", str);
            }



        }

        private List<string> SimplifyPM(List<string> input)
        {
            string[] check = { "+", "-", "*", "/", "^" };
            string[] checkpm = { "+", "-" };
        

            for(int i = 1; i < input.Count; i++)
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
                        input.RemoveAt(i-1);
                        i--;
                    }
                }

            }

            return input;
        }
    }
}

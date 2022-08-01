using System.Text.RegularExpressions;
string input = Console.ReadLine();
string[] splitInput = Regex.Split(input, @"\s*([()])\s*");
foreach(string str in splitInput)
{
    Console.WriteLine(str);
}
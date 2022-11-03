using System.Text.RegularExpressions;
double test = 210984306752864937;

string n = test.ToString("F10");
Console.WriteLine(n);



string input = Console.ReadLine();
string[] splitInput = Regex.Split(input, @"\s*([()])\s*");
foreach(string str in splitInput)
{
    Console.WriteLine(str);
}
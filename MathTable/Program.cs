string input = Console.ReadLine();
string[] splitinput = input.Split(",");

void DoMath()
{
    for(int i = 0; i< splitinput.Length; i++)
    {
        Console.WriteLine(-Math.Pow(2, -double.Parse(splitinput[i])));
    }
}

DoMath();
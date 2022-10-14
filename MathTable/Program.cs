

void DoMath()
{

    double[] splitinput = {2,1.5,1.1,1.05,1.01,1.001,1.0001};
    
    string[] splitinput2 = { };
    for (int i = 0; i< splitinput.Length; i++)
    {
        double a = 4-Math.Pow(splitinput[i], 2);

        double b = 3;
        double c = a - b;
        double d = c / (splitinput[i] - 1);
        Console.WriteLine(d);
    }
}

void Derivative()
{
    string input = Console.ReadLine();
    string[] splitinput = input.Split("x");

}
DoMath();
StreamWriter writer = new StreamWriter("epicinput.txt");
for (int i = 0; i < 1000000; i++)
{
    writer.Write("a");
}
writer.Close();
string readText = File.ReadAllText("epicinput.txt");
Console.WriteLine(readText);

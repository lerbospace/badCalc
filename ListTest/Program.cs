using System;
namespace lecronge
{

    public class Test
    {
        public string name;
        public Test(string name)
        {
            this.name = name;
        }
    }
    public class Program
    {

        public struct SpecialInt
        {
            public SpecialInt(int Value)
            {
                this.Value = Value;
            }
            public int Value;
        }

        public static void Main(String[] args)
        {
         

            List<Test> MasterList = new List<Test>();
            List<Test> SubList = new List<Test>();

            Test a = new Test("Joe");
            MasterList.Add(a);
            SubList.Add(MasterList[0]);

            Console.WriteLine(MasterList[0].name);
            Console.WriteLine(SubList[0].name);
            Console.WriteLine(a.name);
            Console.WriteLine("-------------------");

            a.name = "Bob";
            Console.WriteLine(MasterList[0].name);
            Console.WriteLine(SubList[0].name);
            Console.WriteLine(a.name);
            Console.WriteLine("-------------------");

            MasterList[0].name = "Sneed";

            Console.WriteLine(MasterList[0].name);
            Console.WriteLine(SubList[0].name);
            Console.WriteLine(a.name);
            Console.WriteLine("-------------------");






        }
    }

}




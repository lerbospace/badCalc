using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;

public class program
{
    public static void Main(String[] args)
    {

        for (; ; )
        {
            StreamReader sr = new StreamReader(@"C:\Users\azzhu\Documents\programming\c#\StrangeLibrary\strangeLibrary.in");
            Console.Write("> ");
            string input = Console.ReadLine();
            if (input.Length != 9)
            {
                Console.WriteLine("Error: tha t does not appear to be a valid book ID!\nPlease enter another book ID.");
                continue;
            }
            string line;
            bool found = false;

            while ((line = sr.ReadLine()) != null)
            {
                string[] splitinput = line.Split(',');
                if (input == splitinput[0])
                {
                    switch (splitinput[3])
                    {
                        case "Romance":
                            Romance romance = new Romance(splitinput[0], splitinput[1], splitinput[2], splitinput[3], splitinput[4]);
                            romance.Display();
                            romance.DisplayExtra();
                            found = true;
                            break;
                        case "Horror":
                            Horror horror = new Horror(splitinput[0], splitinput[1], splitinput[2], splitinput[3], splitinput[4]);
                            horror.Display();
                            horror.DisplayExtra();
                            found = true;
                            break;
                        case "Non-fiction":
                            NonFiction nonFiction = new NonFiction(splitinput[0], splitinput[1], splitinput[2], splitinput[3], splitinput[4]);
                            nonFiction.Display();
                            nonFiction.DisplayExtra();
                            found = true;
                            break;
                        case "Classic":
                            Classic classic = new Classic(splitinput[0], splitinput[1], splitinput[2], splitinput[3], splitinput[4]);
                            classic.Display();
                            classic.DisplayExtra();
                            found = true;
                            break;
                        case "Fantasy":
                            Fantasy fantasy = new Fantasy(splitinput[0], splitinput[1], splitinput[2], splitinput[3], splitinput[4]);
                            fantasy.Display();
                            fantasy.DisplayExtra();
                            found = true;

                            break;
                        case "Cooking":
                            Cooking cooking = new Cooking(splitinput[0], splitinput[1], splitinput[2], splitinput[3], splitinput[4]);
                            cooking.Display();
                            cooking.DisplayExtra();
                            found = true;
                            break;

                    }
                    found = true;
                    break;

                }
            }
            if (found != true)
            {
                Console.WriteLine("A book with that ID number could not be found!\nPlease enter another book ID.");
            }

            sr.Close();

        }

    }

    internal abstract class Book
    {
        public Book(string id, string title, string author, string genre, string extra)
        {
            Id= id;
            Title= title;
            Author= author;
            Genre= genre;
            Extra = extra;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Extra { get; set; }

        public void Display()
        {
            Console.WriteLine("ID: {0}",Id);
            Console.WriteLine("Title: {0}",Title);
            Console.WriteLine("Author: {0}",Author);
            Console.WriteLine("Genre: {0}",Genre);
            
        }

        public abstract void DisplayExtra();
        
    }
    internal class Romance:Book
    {
       public Romance(string id, string title, string author, string genre, string extra)
            :base(id, title, author, genre, extra)
        {

        }

        public override void DisplayExtra()
        {
            Console.WriteLine("Related: {0}",Extra);
        }
    }
    internal class Horror:Book
    {
        public Horror(string id, string title, string author, string genre, string extra)
           : base(id, title, author, genre, extra)
        {

        }

        public override void DisplayExtra()
        {
            Console.WriteLine("Age: {0}", Extra);
        }
    }

    internal class NonFiction:Book
    {
        public NonFiction(string id, string title, string author, string genre, string extra)
           : base(id, title, author, genre, extra)
        {

        }

        public override void DisplayExtra()
        {
            Console.WriteLine("Weight: {0}kg", Extra);
        }
    }

    internal class Classic:Book
    {
        public Classic(string id, string title, string author, string genre, string extra)
           : base(id, title, author, genre, extra)
        {

        }

        public override void DisplayExtra()
        {
            Console.WriteLine("Page Count: {0}", Extra);
        }
    }

    internal class Fantasy:Book
    {
        public Fantasy(string id, string title, string author, string genre, string extra)
           : base(id, title, author, genre, extra)
        {

        }

        public override void DisplayExtra()
        {
            Console.WriteLine("Main Character: {0}", Extra);
        }
    }

    internal class Cooking:Book
    {
        public Cooking(string id, string title, string author, string genre, string extra)
           : base(id, title, author, genre, extra)
        {

        }

        public override void DisplayExtra()
        {
            Console.WriteLine("Suitable for Vegetarians.: {0}", Extra);
        }
    }
}
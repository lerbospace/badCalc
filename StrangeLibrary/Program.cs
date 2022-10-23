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
        Romance romance;
        Horror horror;
        NonFiction nonFiction;
        Classic classic;
        Fantasy fantasy;
        Cooking cooking;

        
        

        Dictionary<string,Book> books = new Dictionary<string,Book> { };
        string[] libraryArray = File.ReadAllLines(@"C:\Users\azzhu\Documents\programming\c#\StrangeLibrary\strangeLibrary.in");
        for (; ; )
        {
            try
            {
                
                Console.Write("> ");
                string input = Console.ReadLine();
                input = input.Trim();
                if (input.ToLower().Contains("q"))
                {
                    Console.WriteLine("Exiting Program");
                    Environment.Exit(0);
                }

                if (input.Length != 9)
                {
                    Console.WriteLine("Error: that does not appear to be a valid book ID!\nPlease enter another book ID.");
                    continue;
                }

                
                
                string find = Array.Find(libraryArray, index => index.StartsWith(input));
                if (find == null)
                {
                    Console.WriteLine("A book with that ID number could not be found!\nPlease enter another book ID.");
                    continue;

                }

                
                string[] splitinput = find.Split(',');
                if (books.ContainsKey(splitinput[0]))
                {
                    books[splitinput[0]].Display();
                    books[splitinput[0]].DisplayExtra();
                    continue;
                }
                if (input == splitinput[0])
                {
                    switch (splitinput[3])
                    {
                        case "Romance":
                            romance = new Romance(splitinput[0], splitinput[1], splitinput[2], splitinput[3], splitinput[4]);
                            romance.Display();
                            romance.DisplayExtra();
                            books.Add(input,romance);

                            break;
                        case "Horror":
                            horror = new Horror(splitinput[0], splitinput[1], splitinput[2], splitinput[3], splitinput[4]);
                            horror.Display();
                            horror.DisplayExtra();
                            books.Add(input, horror);

                            break;
                        case "Non-fiction":
                            nonFiction = new NonFiction(splitinput[0], splitinput[1], splitinput[2], splitinput[3], splitinput[4]);
                            nonFiction.Display();
                            nonFiction.DisplayExtra();
                            books.Add(input, nonFiction);

                            break;
                        case "Classic":
                            classic = new Classic(splitinput[0], splitinput[1], splitinput[2], splitinput[3], splitinput[4]);
                            classic.Display();
                            classic.DisplayExtra();
                            books.Add(input, classic);

                            break;
                        case "Fantasy":
                            fantasy = new Fantasy(splitinput[0], splitinput[1], splitinput[2], splitinput[3], splitinput[4]);
                            fantasy.Display();
                            fantasy.DisplayExtra();
                            books.Add(input, fantasy);

                            break;
                        case "Cooking":
                            cooking = new Cooking(splitinput[0], splitinput[1], splitinput[2], splitinput[3], splitinput[4]);
                            cooking.Display();
                            cooking.DisplayExtra();
                            books.Add(input, cooking);

                            break;



                    }

                    

                }
            }
            catch (Exception e)
            { 
                Console.WriteLine("Abnormal error encountered \n{0}",e.Message.ToString());
            }

            
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
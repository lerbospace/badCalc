using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSim
{
    class program
    {
        Random random = new Random();
        List<string[]> particles = new List<string[]> { };
        public static void Main(String[] args)
        {
            Console.BufferHeight = 500;
            Console.BufferWidth = 500;
            Console.SetWindowSize(50, 50);
            
            program program = new program();


            List<string[]>yello = program.Create(100, "Yellow");
            program.Update();
        }

        void Update()
        {
            Console.Clear();
            for(int i = 0; i < particles.Count; i++)
            {
                Console.ForegroundColor =(ConsoleColor) Enum.Parse(typeof(ConsoleColor), particles[i][2]);
                int x = int.Parse(particles[i][0]);
                int y = int.Parse(particles[i][1]);
                Console.SetCursorPosition(x,y);
                Console.Write("O");
            }
        }

        List<string[]> Create(int number, string colour)
        {
            List<string[]> group = new List<string[]>();
            for(int i = 0; i < number; i++)
            {
                group.Add(particle(Random(), Random(), colour));
                particles.Add(group[i]);
            }
            return group;
        }

        string[] particle(int x,int y, string colour)
        {
             
            string[] ds = {x.ToString(),y.ToString(),colour.ToString() };
            return ds;
        }

        int Random()
        {
            return random.Next(0,200)+50;
        }

    }

    
}
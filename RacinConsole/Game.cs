using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacinConsole
{
    internal class Game
    {
        Car c;
        ConsoleKey key;
        int gameSpeed = 1;

        internal void Start()
        {
            c = new Car("Toyota Corolla", 1000, 1, 1);
            // Console.SetWindowSize(100,100);
           // LoadTrack();
            Loop();
        }

        internal void LoadTrack()
        {
            string[] RaceTrack = File.ReadAllLines(@"..\..\..\RaceTrack.txt");
            foreach(string str in RaceTrack)
            {
                foreach(char ch in str)
                {
                    Console.Write(ch);
                }
                Console.WriteLine();
            }
        }

        void Loop()
        {
            for(; ; )
            {

                Thread.Sleep(100);
                while (Console.KeyAvailable == true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    key = keyInfo.Key;
                    c.Input(key);
                }
                /*if (c.speed > 0)
                {
                    c.speed = c.speed - c.speed * 0.1f;
                } Makes game worse*/
                DrawPre();
                c.UpdatePos();
                DrawPost();
            }
        }

        void DrawPre()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Car {0}",c.name);
            Console.WriteLine("Top Speed {0}", c.topSpeed);
            Console.WriteLine("Speed {0}",c.speed);
            Console.WriteLine("Dircetion(angle) {0}",c.direction);
            Console.WriteLine("xdir {0}, ydir {1}",c.xdir,c.ydir);
            Console.WriteLine("xPos {0}, yPos {1}",c.xPos,c.yPos);
            Console.SetCursorPosition((int)c.xPos, (int)c.yPos);
            
            Console.Write(" ");
            
            
        }

        void DrawPost()
        {
            Console.SetCursorPosition((int)c.xPos, (int)c.yPos);
            Console.Write(c.icon);
        }
    }
}

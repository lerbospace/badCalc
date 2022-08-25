using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacinConsole
{
    internal class Car
    {
        public string name;
        public float speed;
        public char icon = '^';
        

        public int topSpeed;
        protected float acceleration;
        protected float deceleration;
        public float direction;

        public double xPos = 50;
        public double yPos = 50;

        public double xdir;
        public double ydir;

        public Car(string name, int topSpeed, float acceleration, float deceleration)
        {
            this.name = name;
          
            this.topSpeed = topSpeed;
            this.acceleration = acceleration;
            this.deceleration = deceleration;

          
     

        }

        public void Input(ConsoleKey key)
        {
          
           
            switch (key)
            {
                case ConsoleKey.W:
                    if (speed < topSpeed)
                    {
                        speed += acceleration;

                    }
                    break;
                case ConsoleKey.S:
                    if (speed > -topSpeed)
                    {
                        speed -= deceleration;
                    }
                    break;
                case ConsoleKey.D:
                    direction += 5f;
                    break;
                case ConsoleKey.A:
                    direction -= 5f;
                    break;
            }
            direction = direction % 360;


        }

        public void UpdatePos()
        {           

 
	    direction = direction % 360;


            xdir = (speed * Math.Cos(direction * Math.PI / 180));
            ydir = (speed * Math.Sin(direction * Math.PI / 180));

         
           xPos += xdir;
           yPos += ydir;

           Console.SetCursorPosition((int)xPos, (int)yPos);
           Console.Write(icon);

        }



    }
}

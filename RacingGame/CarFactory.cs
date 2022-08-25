using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingGame
{
    internal static class CarFactory
    {
        public static Car CreateCar(string name, int topSpeed, float acceleration, float deceleration)
        {
            return new Car(name, topSpeed, acceleration, deceleration);
        }
        public static Car CreateCar(string _carType)
        {
            switch (_carType)
            {
                case "Toyota Corolla":
                    return new Car("Toyota Corolla", 200, 10, 20);
                case "Motorbike":
                    return new Car("Motorbike",  220, 15, 10);
                case "Truck":
                    return new Car("Truck", 300, 5, 10);
                case "Bike":
                    return new Car("Bike", 30, 10, 30);
                case "Broken Car":
                    return new Car("Broken Car", 100, -100, -1);
            }
            return null;
        }
        public static Car CreateCar()
        {
            return new Car("Basic Car", 150, 1, 10);
        }

    }
}
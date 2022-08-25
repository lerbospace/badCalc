using System;

namespace CountryThing
{

    class program
    {
        public static void Main(String[] args)
        {
         
            Country co = new Country();
            co.population = 1;
            City city = new City();
            city.population = 100;
            co.haspop.Add(city);
            Console.WriteLine("Total {0}",co.GetPopulation());
        }

       

        class Country: Component
        {
            public List<Component> haspop = new List<Component> { };
            public int population { get; set; }

            public int GetPopulation()
            {
                int total = this.population;
                Console.WriteLine("Country pop: {0}",population);
                foreach (Component comp in haspop)
                {
                    total += comp.GetPopulation();
                }
                return total;
            }

        }

        class City: Component
        {
            public int population { get; set; }

            public int GetPopulation()
            {
                Console.WriteLine("City pop: {0}",population);
                return population;
            }
        }

        interface Component
        {
            public int population { get; set; }

            public int GetPopulation()
            {
                
                return 0;
            }

        }
    }
}

  
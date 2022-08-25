using System;

namespace reminder
{
    class program
    {
        public static void Main(String[] args)
        {
            List <Reminder> r = new List<Reminder> { };
            r.Add(new Reminder("clash of clans grid", 1730, "attack"));
            r.Add(new Reminder("clash of clans ShadowMaster", 1920, "attack"));
            r.Add(new Reminder("clash of clans Hades", 1730, "attack"));

            foreach (Reminder rem in r)
            {
                Console.WriteLine("************");
                rem.Remind();
            }
        }
    }


    class Reminder
    {
        public Reminder(string location, int time, string action)
        {
            Location  = location;
            Time = time;
            Action = action;
        }

        public string Location { get; set; }
        public int Time { get; set; }
        public string Action { get; set; }

        public void Remind()
        {
            Console.WriteLine("Thing: to do {0}",Action);
            Console.WriteLine("Where: {0}",Location);
            Console.WriteLine("When: {0}",Time);
        }
    }
}
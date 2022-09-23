using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleTest
{
    internal class ParticleStuff
    {
        Random random = new Random();
        List<Particle> particles = new List<Particle>();
        List<Particle> yellow;
        List<Particle> red;
        List<Particle> green;
        List<Particle> blue;
        float rr;
        float ry;
        float rg;
        float rb;

        float yr;
        float yy;
        float yg;
        float yb;

        float gr;
        float gy;
        float gg;
        float gb;

        float br;
        float by;
        float bg;
        float bb;

        
        
        
        public ParticleStuff()
        {
            
            yellow = Create(100, Color.Yellow);
            red  = Create(100, Color.Red);
            green = Create(100, Color.Green);
            blue = Create(100, Color.Blue);

            rr = RandomGravity();
            ry = RandomGravity();
            rg = RandomGravity();
            rb = RandomGravity();

            yr = RandomGravity();
            yy = RandomGravity();
            yg = RandomGravity();
            yb = RandomGravity();

            gr = RandomGravity();
            gy = RandomGravity();
            gg = RandomGravity();
            gb = RandomGravity();

            br = RandomGravity();
            by = RandomGravity();
            bg = RandomGravity();
            bb = RandomGravity();

        }

        //ref List<Particle> particles { get { return ref particles; } }
        struct Particle
        {
            public Particle(double x, double y, Color colour)
            {
                this.x = x;
                this.y = y;
                this.colour = colour;
                this.vx = 0;
                this.vy = 0;
                this.mass = 1;
            }
            public double x;
            public double y;
            public Color colour;
            public double vx;
            public double vy;
            public double mass;
        }

        void Rule(ref List<Particle> Group1, ref List<Particle> Group2, float G)
        {

            //Gravity coefficient
            float g = G / -100;
            


            //Loop through first group of points
            for (int i = 0; i <Group1.Count; i++)
            {
                Particle p1 = Group1[i];
                //Force acting on particle
                double fx = 0;
                double fy = 0;
                double dx = 0;
                double dy = 0;
                //Loop through second group of points
                for (int j = Group2.Count-1; j > 0; j--)
                {
                    Particle p2 = Group2[j];
                    //Calculate the ddistance between points using Pythagorean theorem
                    dx = p1.x - p2.x;
                    dy = p1.y - p2.y;
                    double r = Math.Sqrt(dx * dx + dy * dy);

                    //Calculate the force in given bounds. 
                    if (r > 0.01f && r< 80)
                    {
                        double F = (g * 1) /r;
                        fx += dx * F;
                        fy += dy * F;
                    }
                }

                //Calculate new velocity
                p1.vx = (p1.vx + fx) *0.5;
                p1.vy = (p1.vx + fy) *0.5;
                if (Math.Abs(p1.vx) > 200 || Math.Abs(p1.vy) > 200)
                {
                    dy = dy+0;
                    dx = dx+0;
                    p1.colour = Color.Violet;
                }
                //Update position based on velocity
               
                
                
                p1.x += p1.vx;
                p1.y += p1.vy;


                //Checking for canvas bounds
               
                    if (p1.x < 0) { p1.vx *= -1; p1.x = 0; };
                   if (p1.x > 1000) { p1.vx *= -1; p1.x = 1000; };
                    if (p1.y < 0) { p1.vy *= -1; p1.y = 0; };
                    if (p1.y > 1000) { p1.vy *= -1; p1.y = 1000; };
               

                Group1[i] = p1;
            }

        }


        public void Update()
        {
            List<Particle> tempRed = red.ToList();
            List<Particle> tempYellow = yellow.ToList();
            List<Particle> tempGreen = green.ToList();
            List<Particle> tempBlue = blue.ToList();

            //Green
            Rule(ref green, ref red, gr);
            Rule(ref green, ref tempYellow, gy);
            Rule(ref green, ref tempGreen, gg);
            Rule(ref green, ref tempBlue, gb);
           

         
            //Blue
            Rule(ref blue, ref red, br);
            Rule(ref blue, ref tempYellow, by);
            Rule(ref blue, ref tempGreen, bg);
            Rule(ref blue, ref tempBlue, bb);
            //Yellow
            Rule(ref yellow, ref tempRed, yr);
            Rule(ref yellow, ref tempYellow, yy);
            Rule(ref yellow, ref tempGreen, yg);
            Rule(ref yellow, ref tempBlue, yb);

            //Red
            Rule(ref red, ref tempRed, rr);
            Rule(ref red, ref tempYellow, ry);
            Rule(ref red, ref tempGreen, rg);
            Rule(ref red, ref tempBlue, rb);





        }

        public void Draw(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black, 4);
            //MessageBox.Show("here");
            //p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            
            for (int i = 0; i < particles.Count; i++)
            {
                p.Color = particles[i].colour;
                e.Graphics.DrawEllipse(p, (int)particles[i].x, (int)particles[i].y, 1, 1);
            }
            //p.Color = red[0].colour;
            for (int i = 0; i < red.Count; i++)
            {
                p.Color = red[i].colour;
                e.Graphics.DrawEllipse(p, (int)red[i].x, (int)red[i].y, 1, 1);
            }
            //p.Color = green[0].colour;
            for (int i = 0; i < green.Count; i++)
            {
                p.Color = green[i].colour;
                e.Graphics.DrawEllipse(p, (int)green[i].x, (int)green[i].y, 1, 1);
            }
            for (int i = 0; i < blue.Count; i++)
            {
                p.Color = blue[i].colour;
                e.Graphics.DrawEllipse(p, (int)blue[i].x, (int)blue[i].y, 1, 1);
            }
            //Thread.Sleep(30);

        }
        List<Particle> Create(int number, Color colour)
        {
            List<Particle> group = new List<Particle>();
            for (int i = 0; i < number; i++)
            {
                Particle temp = new Particle(Random(), Random(), colour);
                group.Add(temp);
                particles.Add(temp);
                
                //particles.Add(group[i]);
            }
            return group;
        }

        int Random()
        {
            return random.Next(0, 1000);
        }

        float RandomGravity()
        {
            float a = random.Next(0, 200);
            a-= 100;
            a /= 10;
            //MessageBox.Show(a.ToString());
            return a;

        }

    }
}

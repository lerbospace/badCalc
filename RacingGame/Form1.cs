namespace RacingGame
{
    public partial class Form1 : Form
    {
        public List<Car> carList = new List<Car> { };
        int dir = 10;
        public Form1()
        {
            InitializeComponent();

            carList.Add(CarFactory.CreateCar("Toyota Corolla"));

            carList.ForEach(n => Controls.Add(n));
            this.SetStyle(ControlStyles.UserPaint, true);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Form1_Paint(object sender, PaintEventArgs e)
        {

            //MessageBox.Show(dir.ToString());
             Point now = new Point(100,100);
             Point Destination = new Point(10*(int)Math.Cos(carList[0]._direction * Math.PI / 180),
                                       10*(int) Math.Sin(carList[0]._direction * Math.PI / 180));
            Pen p = new Pen(Color.Black, 5);
            e.Graphics.DrawLine(p, now, Destination);
            Invalidate();
            Refresh();

          
            
        }

        private void c(object sender, EventArgs e)
        {

        }
    }
}
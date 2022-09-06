using System;
using System.Drawing;
using System.Windows.Forms;

namespace UnitCinverter
{
    public class MyForm : Form
    {
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private ListBox listBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private bool reverse = false;

        public MyForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.listBox1 = new ListBox();
            this.label2 = new Label();
            this.button1 = new Button();
            this.textBox2 = new TextBox();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.button2 = new Button();
            this.button3 = new Button();
            this.button4 = new Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Items.AddRange(new object[] {
            "Centimeters to inches",
            "Meters to yards",
            "Kilometers to miles",
            "Grams to ounces",
            "Kilograms to pounds",
            "Tonnes to tons",
            "Celsius to farhrenheit"});
            this.listBox1.Location = new System.Drawing.Point(10, 90);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(166, 94);
            this.listBox1.TabIndex = 2;
            this.listBox1.Click += new EventHandler(UnitSelect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Conversion";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Convert!";
            this.button1.Click += new EventHandler(Convert);
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(10, 312);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Units";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Units";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Reverse";
            this.button2.Click += new EventHandler(Reverse);
        
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 362);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new EventHandler(Clear);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(137, 362);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Quit";
            button4.Click += new EventHandler(Quit);
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(223, 397);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "My Unit Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Quit(object sender, EventArgs e)
        {
            Close();
        }

        void Convert(object sender, EventArgs e)
        {

            int temp = listBox1.SelectedIndex;
            reverse = false;
            UnitSelect(sender, e);
            this.listBox1.Items.Clear();
            this.listBox1.Items.AddRange(new object[] {
            "Centimeters to inches",
            "Meters to yards",
            "Kilometers to miles",
            "Grams to ounces",
            "Kilograms to pounds",
            "Tonnes to tons",
            "Celsius to farhrenheit"});
            if (float.TryParse(textBox1.Text, out float ab) == false)
            {
                MessageBox.Show("Invalid Input");
                return;
            }
            float a;
            float b;
            listBox1.SelectedIndex = temp;
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    float.TryParse(textBox1.Text, out a);
                    b = a * 0.3937f;
                    textBox2.Text = b.ToString();
                    Console.WriteLine(b);

                    break;
                case 1:
                    float.TryParse(textBox1.Text, out a);
                    b = a * 1.0936132983f;
                    textBox2.Text = b.ToString();

                    break;
                case 2:
                    float.TryParse(textBox1.Text, out a);
                    b = a * 0.6213711f;
                    textBox2.Text = b.ToString();
                    break;
                case 3:
                    float.TryParse(textBox1.Text, out a);
                    b = a * 0.03527396195f;
                    textBox2.Text = b.ToString();
                    break;
                case 4:
                    float.TryParse(textBox1.Text, out a);
                    b = a * 2.20462262185f;
                    textBox2.Text = b.ToString();
                    break;
                case 5:
                    float.TryParse(textBox1.Text, out a);
                    b = a * 1.10231f;
                    textBox2.Text = b.ToString();
                    break;
                case 6:
                    float.TryParse(textBox1.Text, out a);
                    b = 0.5555555555555555555f * (a + 32);
                    textBox2.Text = b.ToString();
                    break;




            }

        }

        void Reverse(object sender, EventArgs e)
        {
            int temp = listBox1.SelectedIndex;
            reverse = true;
            UnitSelect(sender, e);
            listBox1.Items.Clear();
            this.listBox1.Items.AddRange(new object[] {
            "inches to Centimeters",
            "yards to metres",
            "miles to Kilometers",
            "ounces to grams",
            "pounds to Kilograms",
            "Tons to tonness",
            "farhrenheit to Celsius"});

            if (float.TryParse(textBox1.Text, out float ab) == false)
            {
                MessageBox.Show("Invalid Input");
                return;
            }
            float a;
            float b;
            listBox1.SelectedIndex = temp;

            switch (listBox1.SelectedIndex)
            {
                case 0:
                    float.TryParse(textBox1.Text, out a);
                    b = a * 2.54f;
                    textBox2.Text = b.ToString();

                    break;
                case 1:
                    float.TryParse(textBox1.Text, out a);
                    b = a * 0.9144f;
                    textBox2.Text = b.ToString();

                    break;
                case 2:
                    float.TryParse(textBox1.Text, out a);
                    b = a * 1.609344f;
                    textBox2.Text = b.ToString();
                    break;
                case 3:
                    float.TryParse(textBox1.Text, out a);
                    b = a * 28.34952f;
                    textBox2.Text = b.ToString();
                    break;
                case 4:
                    float.TryParse(textBox1.Text, out a);
                    b = a * 0.45359237f;
                    textBox2.Text = b.ToString();
                    break;
                case 5:
                    float.TryParse(textBox1.Text, out a);
                    b = a * 0.90718474f;
                    textBox2.Text = b.ToString();
                    break;
                case 6:
                    float.TryParse(textBox1.Text, out a);
                    b = (a * 1.8f) + 32;
                    textBox2.Text = b.ToString();
                    break;


            }


        }
        void UnitSelect(object sender, EventArgs e)
        {
            List<string> metric = new List<string> { "cm", "m", "Km", "g", "Kg", "Tonnes", "C" };
            List<string> imperial = new List<string> { "in", "y", "Mi", "oz", "lb", "Tons", "F" };
            if (listBox1.SelectedIndex == -1)
            {
                return;
            }
            if (reverse == false)
            {
                label4.Text = metric[listBox1.SelectedIndex];
                label5.Text = imperial[listBox1.SelectedIndex];
            }

            if (reverse == true)
            {
                label5.Text = metric[listBox1.SelectedIndex];
                label4.Text = imperial[listBox1.SelectedIndex];
            }

        }

        void Clear(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }


        public static class Program
        {
            [STAThread]
            public static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MyForm());
            }
        }
    }
}
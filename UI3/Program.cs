using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public class MyForm : Form
    {

        private FlowLayoutPanel flowPanel;
        private TextBox textbox;
        private CheckBox checkbox;

        public MyForm()
        {
            InitComponents();
        }

        private void InitComponents()
        {
            // Form properties
            Text = "My first GUI";
            ClientSize = new Size(400, 500);
            AutoSize = true;

            // Form method
            CenterToScreen();

            flowPanel = new FlowLayoutPanel();
            flowPanel.Location = new Point(50, 250);

            addTooltips();
            addButtons();
            addTextbox();
            addCheckbox();

            Controls.Add(flowPanel);
        }

        private void initFlowLayoutPanel()
        {
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.BorderStyle = BorderStyle.FixedSingle;
        }


        private void addButtons()
        {
            var button1 = new Button();
            button1.Text = "Button1";
            button1.AutoSize = true;

            var button2 = new Button();
            button2.Text = "Button 2";
            button2.AutoSize = true;

            var button3 = new Button();
            button3.Text = "Button 3";
            button3.AutoSize = true;

            var buttonQ = new Button();
            buttonQ.Text = "Quit";
            buttonQ.AutoSize = true;
            buttonQ.Margin = new Padding(10, 10, 0, 0);
           // buttonQ.Location = new Point(ClientSize.Width, 0);

            // Note this line carefully: it wires the quit button
            buttonQ.Click += new EventHandler(Button_Click_Quit);

            flowPanel.Controls.Add(button1);
            flowPanel.Controls.Add(button2);
            flowPanel.Controls.Add(button3);
            flowPanel.Controls.Add(buttonQ);
        }

        private void Button_Click_Quit(object sender, EventArgs e)
        {
            Close();
        }


        private void addTooltips()
        {
            // This was homework from a previous class
        }

        private void addTextbox()
        {
            // Create a TextBox object  
            textbox = new TextBox();

            // Set background and foreground  
            textbox.Text = "TextBox!";
            textbox.Location = new Point(50, 180);

            this.Controls.Add(textbox);
        }

        private void addCheckbox()
        {
            checkbox = new CheckBox();
            checkbox.Text = "Make textbox red!";
            checkbox.Size = new Size(200, 20);
            checkbox.Location = new Point(50,200);
            checkbox.Click += new EventHandler(Checkbox_Click);

            this.Controls.Add(checkbox);
        }

        private void Checkbox_Click(object? sender, EventArgs e)
        {
            if(checkbox.Checked==true)
            {
                textbox.BackColor = Color.Red;
            }
            else
            {
                textbox.BackColor = Color.White;
            }
           
        }

        // Your goal for this lesson is to tidy up the controls and wir up the checkbox so it turns the textbox background red
        // Position the checkbox so it sits right next to the textbox in a more natural, aesthetic position
        // The code is partially complete, but, as usual, you will need to search the Internet/read the documention to complete it
        // Feel free to complete the empty methods with the work you have done over the previous lessons
    }

    public static class Program
    {
        // Switches us to a single-threaded apartment model
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyForm());
        }
    }
}
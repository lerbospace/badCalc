using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public class MyForm : Form
    {

        private FlowLayoutPanel flowPanel;

        public MyForm()
        {
            InitComponents();
        }

        private void InitComponents()
        {
            // Form properties
            Text = "My first GUI";
            ClientSize = new Size(800, 450);
            AutoSize = true;

            // Form method
            CenterToScreen();

            flowPanel = new FlowLayoutPanel();

            addButtons();

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
            button1.Click += new EventHandler(Button_Click_1);

            var button2 = new Button();
            button2.Text = "Button 2";
            button2.AutoSize = true;
            button2.Click += new EventHandler(Button_Click_1);

            var buttonQ = new Button();
            buttonQ.Text = "Quit";
            buttonQ.AutoSize = true;
            buttonQ.Margin = new Padding(10, 10, 0, 0);

            // Note this line carefully: it wires the quit button
            buttonQ.Click += new EventHandler(Button_Click_Quit);

            flowPanel.Controls.Add(button1);
            flowPanel.Controls.Add(button2);
            flowPanel.Controls.Add(buttonQ);
        }



        private void Button_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Button 1 was clicked!","Button1",MessageBoxButtons.OKCancel);
        }

        private void Button_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("Button 2 was clicked!");
        }
        // In the previous lesson, getting the quit button to work
        // was a secondary goal. Here we can see that this has been
        // done. This example demonstrates that methods can be
        // passed to other methods just like a variable.
        private void Button_Click_Quit(object sender, EventArgs e)
        {
            // This method is inherited from the superclass
            Close();
        }

        // Your goal for this lesson is to get the other two buttons
        // wired up so that that they do the following:
        // Button 1: throw a Message Box saying 'Button 1 was clicked!'
        // Button 2: should change the title text to 'Button 2 was clicked!'
        // As usual, make full use of your search engine and C# documentation
        // to carry out some research. To help you start, here is a link
        // to the C# documentation on the MessageBox class
        // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.messagebox?view=windowsdesktop-6.0
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
 
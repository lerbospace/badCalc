using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public class MyForm : Form
    {

        private FlowLayoutPanel flowPanel;
        Button button;
        Button button2;
        Button buttonQ;

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
            addTooltips(button, "wow button 1");
            addTooltips(button2, "wow button 2");
            addTooltips(buttonQ, "Click to Quit the program");
            addTooltips(flowPanel, "where is it?");


            Controls.Add(flowPanel);
        }

        private void initFlowLayoutPanel()
        {
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void addButtons()
        {
            button = new Button();
            button.Text = "Button1";
            button.AutoSize = true;

            button2 = new Button();
            button2.Text = "Button 2";
            button2.AutoSize = true;

            buttonQ = new Button();
            buttonQ.Text = "Quit";
            buttonQ.AutoSize = true;
            buttonQ.Margin = new Padding(10, 10, 0, 0);
            buttonQ.Click += new EventHandler(Button_Click);

            flowPanel.Controls.Add(button);
            flowPanel.Controls.Add(button2);
            flowPanel.Controls.Add(buttonQ);

            

            
        }
        public void Button_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void addTooltips(Control button, string message)
        {
            // TODO
            ToolTip tooltip = new ToolTip();
            tooltip.ShowAlways = true;
            tooltip.SetToolTip(button, message);
           

            // Your goal: add tooltips to the flowlayout panel and buttons
            // Tooltips are those little messages that appear when you hover the cursor over a component
            // Hint: read the C# documentation on the ToolTip 
            // Hint2: you will need to make the buttons fields of MyForm to access them
        }
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
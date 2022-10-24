using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace GUICalc
{

    public class MyForm: Form
    {
        private FlowLayoutPanel flowPanel;
        TextBox output;
        TextBox input;
        Calculator calculator = new Calculator();

        public MyForm()
        {
            InitComponents();
        }

        private void InitComponents()
        {
            flowPanel = new FlowLayoutPanel();
            //flowPanel.AutoSize = true;
            flowPanel.Width = 256;
            
            

            //Output
            
            output = new TextBox();
            output.TabIndex = 1;
            output.ReadOnly = true;   
            //output.Text = "Output goes here\r\n newline?";
            output.Size = new Size(flowPanel.Width-30, 50);
            output.Location = new Point(30, 30);
            output.Multiline = true;
            //output.WordWrap = true;
            output.ScrollBars = ScrollBars.Vertical;
            //output.ScrollBars = 




            //Input
            
            input = new TextBox();
            input.TabIndex = 0;
            //input.Text = "Enter input here";
            input.Size = new Size(flowPanel.Width-30, 30);
            //input.Multiline = true;
            input.Location = new Point(30, 160);
            input.KeyDown += new KeyEventHandler(RecieveInput);

            //Flowpanel

            flowPanel.Controls.Add(output);
            flowPanel.Controls.Add(input);

            Controls.Add(flowPanel);
        }

        void RecieveInput(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                string result = calculator.Calculate(input.Text);

                if (input.Text.Contains("="))
                {
                    output.AppendText("\r\n" + result);
                    input.Text = "";
                    return;
                }
                output.AppendText("\r\n"+input.Text+" = "+result);
                input.Text = "";

            }
            
           
            //output.ScrollToCaret();
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
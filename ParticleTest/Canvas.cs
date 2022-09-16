using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ParticleTest
{
    public partial class Canvas : Form
    {

        ParticleStuff particleStuff = new ParticleStuff();
        Button Reset;

        public Canvas()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

        }

        private void InitializeComponent()
        {

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.BackColor = Color.Black;
            this.Text = "Canvas";
            this.Paint += PaintNew;
            this.Reset = new Button();
            this.Reset.Text = "Reset";
            this.Reset.Click += ResetGame;

            Controls.Add(Reset);

        }

        void PaintNew(object sender, PaintEventArgs e)
        {

            this.Invalidate();
            particleStuff.Update();
            particleStuff.Draw(sender, e);
            //Thread.Sleep(30);
        }

        void ResetGame(object sender, EventArgs e)
        {
            particleStuff = new ParticleStuff();
        }


    }
}

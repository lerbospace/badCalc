using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Drawing;
using System.Media;

namespace RacingGame
{
    public class Car : TextBox
    {
        public string name;
        public float speed;
        public Color colour;

        protected int _topSpeed;
        protected float _acceleration;
        protected float _deceleration;
        public float _direction;

        public int xPos = 50;
        public int yPos = 50;

        public Car(string name, Color colour, int topSpeed, float acceleration, float deceleration)
        {
            this.name = name;
            this.colour = colour;
            this._topSpeed = topSpeed;
            this._acceleration = acceleration;
            this._deceleration = deceleration;

            this.Size = new Size(10, 10);
            this.Text = this.name;
            this.ReadOnly = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(InputKeyDown);
            this.SetStyle(ControlStyles.UserPaint, true);

        }

        private void InputKeyDown(object sender, KeyEventArgs e)
        {

            
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (speed < _topSpeed)
                    {
                        speed += _acceleration;
                        
                    }
                    break;
                case Keys.S:
                    if (speed > -_topSpeed)
                    {
                        speed -= _deceleration;
                    }
                    break;
                case Keys.D:
                    _direction += 15f;
                    break;
                case Keys.A:
                    _direction -= 15f;
                    break;
            }
            _direction = _direction % 360;
            UpdatePos();
            Invalidate();

        }

        public void UpdatePos()
        {

            //  MessageBox.Show("epfiurew");
            xPos += (int)Math.Round(speed * Math.Cos(_direction * Math.PI / 180));
                yPos += (int)Math.Round(speed * Math.Sin(_direction * Math.PI / 180));

            if (speed > 0)
            {
                speed = speed-1;
            }
            this.Location = new Point(xPos, yPos);
            
        }
    


    }
}
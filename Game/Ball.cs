using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace Game
{
    class Ball : GameObject
    {   
        public float Radius { get; set; }

        public Ball(int x, int y,int radius) : base(x,y,radius,radius) 
        {
            Radius = radius;
        }
        public override PaintEventHandler Draw()
        {
            return (object sender, PaintEventArgs args) => { args.Graphics.DrawEllipse(new Pen(Color.Black),X,Y,Radius,Radius) ; };
        }

        public override void Move(int difX, int difY, Physic physic)
        {
            X += difX;
            Y += difY;
        }
    }
}

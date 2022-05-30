using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class Rect:GameObject
    {
        public SolidBrush solidBrush = new SolidBrush(Color.Black);

        public Color Color { get; set; }

        public Rect(int x, int y, int width, int height) : base(x,y,width,height)
        {
            Width = width;
            Height = height;
        }

        public override PaintEventHandler Draw() 
        {
            return (object sender,PaintEventArgs args) => { args.Graphics.FillRectangle(solidBrush, X, Y, Width, Height);};
        }

        public override void Move(int difX, int difY,Physic physic)
        {
            X += difX;
            Y += difY;
        }

        public void TestCollision(List<GameObject>gameObjects) 
        {
            var flag = false;
            foreach (var elem in gameObjects)
            {
                if (this.GetCollideData(elem).Flag) flag = true;
            }
            if (flag) Color = Color.Red;
        }
    }
}

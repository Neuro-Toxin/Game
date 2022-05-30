using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Game
{
    class CustomButton:Button
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
       
        public ButtonState bState { get; private set; }

        ButtonSprites sprites;

        public CustomButton(ButtonSprites sprites,int x, int y, int width, int height,string text = "button") 
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            this.sprites = sprites;
            Text = text;

            bState = ButtonState.Unactive;

            BackgroundImage = new Bitmap(sprites.GetSprite(this), new Size(Width, Height));

            Location = new Point(X, Y);
            Visible = true;

            SetStyle(ControlStyles.Selectable,false);
            
            Click += CustomButton_Click;
            MouseMove += CustomButton_MouseMove;
            MouseLeave += CustomButton_MouseLeave;
            MouseDown += CustomButton_MouseDown;
            MouseUp += CustomButton_MouseUp;
            
        }

        private void CustomButton_MouseUp(object sender, MouseEventArgs e)
        {
            bState = ButtonState.Unactive;
            BackgroundImage = sprites.GetSprite(this);
        }

        private void CustomButton_MouseDown(object sender, MouseEventArgs e)
        {
            bState = ButtonState.Active;
            BackgroundImage = sprites.GetSprite(this);
        }

        private void CustomButton_Click(object sender, EventArgs e)
        {
            
        }
        
        private void CustomButton_MouseMove(object sender, EventArgs e)
        {
            bState = ButtonState.InFocus;
            BackgroundImage = sprites.GetSprite(this);
        }

        private void CustomButton_MouseLeave(object sender, EventArgs e)
        {
            bState = ButtonState.Unactive;
            BackgroundImage = sprites.GetSprite(this);
        }
    }

    public enum ButtonState 
    {
        Unactive,
        Active,
        InFocus
    }
}

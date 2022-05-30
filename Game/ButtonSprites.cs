using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Game
{
    class ButtonSprites : InterfaceSprites
    {
        public ButtonSprites(Image image) : base(image)
        {

        }

        public Image GetSprite(CustomButton button) 
        {
            Bitmap bmp = new Bitmap(image,button.Width, button.Height);
            var g = Graphics.FromImage(bmp);
            g.DrawImage
                (
                    image,
                    new Rectangle(0, 0, button.Width, button.Height),
                    (int)button.bState * image.Width/3,
                    0,
                    image.Width/3,
                    image.Height,
                    GraphicsUnit.Pixel
                );
            return bmp;
        }
    }
}

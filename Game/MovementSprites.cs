using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Game
{
    public class MovementSprites : GameSprites
    {
        private int rows;
        private int columns;
        private int currentFrameNumber;

        public MovementSprites(Image image,int timerInterval, int rows, int columns) : base(image, timerInterval)
        {
            this.rows = rows;
            this.columns = columns;
            spritesTimer.Tick += SpritesTimer_Tick;
        }

        private void SpritesTimer_Tick(object sender, EventArgs e)
        {
            currentFrameNumber += 1; 
            if (currentFrameNumber > rows - 1) currentFrameNumber = 0;
        }

        public override PaintEventHandler GetSprite(GameObject obj)
        {
            return (object sender, PaintEventArgs args) =>
            {   
                if (!obj.isMoving) currentFrameNumber = 0;

                args.Graphics.DrawImage
                (
                    image,
                    new Rectangle((int)obj.X, (int)obj.Y, obj.Width, obj.Height),
                    currentFrameNumber * image.Width / rows,
                    (int)obj.dir * image.Height / columns,
                    image.Width / rows,
                    image.Height / columns,
                    GraphicsUnit.Pixel
                );
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Game
{
    public abstract class GameSprites : Sprites
    {
        protected Timer spritesTimer;
        public GameSprites(Image image, int timerInterval) : base(image)
        {
            spritesTimer = new Timer { Interval = timerInterval };
            spritesTimer.Start();
        }
        public abstract PaintEventHandler GetSprite(GameObject obj);
    }
}

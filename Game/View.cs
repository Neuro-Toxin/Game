using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Game
{
    public partial class View : Form
    {
        //private List<GameObject> gameObjects = new List<GameObject>();
        private Game game;
        private Timer viewTimer;

        public View(Game game,int fps)
        {   
            this.game = game;
            viewTimer = new Timer { Interval = 1000/fps };
            viewTimer.Start();

            DoubleBuffered = true;
            EnterFullScreen();
            EnterFullWindow();
            


            viewTimer.Tick += (sender, args) =>
            {
                Invalidate();

            };

            Button button = new CustomButton(new ButtonSprites(Resources.ButtonSprite2), 400, 400, 150, 50, "Leave Full Screen");
            Button button2 = new CustomButton(new ButtonSprites(Resources.ButtonSprite2), button.Location.X, button.Location.Y + 50, 150, 50);

            

            Controls.Add(button);
            Controls.Add(button2);
        }

        public void Create(GameObject obj) 
        {   
            this.Paint += obj.Draw();
            //game.gameObjects.Add(obj);
        }

        public void EnterFullWindow() 
        {
            
        }

        public void EnterFullScreen()
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
        }

        public void LeaveFullScreen()
        {
            //WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            
        }
    }
}

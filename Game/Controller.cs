using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Input;

namespace Game
{
    class Controller
    {
        private Form targetForm;
        private Game game;
        private Timer timer;

        private DirectionFlags flags = new DirectionFlags(false,false,false,false);

        public Controller(Form form, Game game, Timer timer)
        {
            targetForm = form;
            this.game = game;
            this.timer = timer;

            targetForm.KeyDown += TargetForm_KeyDown;
            targetForm.KeyUp += TargetForm_KeyUp;
            timer.Tick += Timer_Tick;
        }

        private void TargetForm_KeyUp(object sender, KeyEventArgs args)
        {
            if (args.KeyCode == Keys.A) { flags.Left = false; };
            if (args.KeyCode == Keys.W) { flags.Up = false; };
            if (args.KeyCode == Keys.S) { flags.Down = false; };
            if (args.KeyCode == Keys.D) { flags.Right = false; };
        }

        private void TargetForm_KeyDown(object sender, KeyEventArgs args)
        {
            if (args.KeyCode == Keys.A) { flags.Left = true; flags.Right = false; };
            if (args.KeyCode == Keys.D) { flags.Right = true; flags.Left = false; };
            if (args.KeyCode == Keys.W) { flags.Up = true; flags.Down = false; };
            if (args.KeyCode == Keys.S) { flags.Down = true; flags.Up = false; };
        }

        private void Timer_Tick(object sender, EventArgs e)
        {   
            game.MovePlayer(flags);
        }
    }

    public class DirectionFlags
    {
        public bool Right { get; set; }
        public bool Left { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }

        public DirectionFlags(bool right, bool left, bool up, bool down) 
        {
            Right = right;
            Left = left;
            Up = up;
            Down = down;
        }
    }
}

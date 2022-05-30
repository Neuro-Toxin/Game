using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    static class Run
    {
        
        [STAThread]
        static void Main()
        {
            var game = new Game();
            game.Start();
        }
    }
}

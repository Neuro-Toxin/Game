using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class Game
    {
        public static List<GameObject> gameObjects = new List<GameObject>();
        Player player;
        Timer timer;
        View view;
        Controller controller;
        public Physic physic { get; private set; }
        public static Label label = new Label { Text = "Direction:", Location = new Point(0, 0), Size = new Size(100, 20), Visible = true };

        public Game()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            timer = new Timer();
            timer.Interval = 30;
            physic = new Physic(9.8);
            view = new View(this, 45);

            controller = new Controller(view, this, timer);
            
            view.Controls.Add(label);
            
            player = new Player
                (
                    new MovementSprites(Resources.sprite3, 190, 4, 4),
                    500, 500, 40, 63, 5
                );
            var rect = new Rect(200, 200, 200, 200);
            rect.Color = Color.Black;
            


            gameObjects.Add(player);
            gameObjects.Add(rect);
            InitGameObjects();
        }

        private void InitGameObjects()
        {
            foreach (var elem in gameObjects)
                view.Create(elem);
        }

        public void MovePlayer(DirectionFlags flags)
        {
            int difX = flags.Right ? player.Speed : flags.Left ? -player.Speed : 0;
            int difY = flags.Down ? player.Speed : flags.Up ? -player.Speed : 0;

            label.Text = flags.Down ? "Down" : flags.Left ? "Left" : flags.Right ? "Right" : flags.Up? "Up":label.Text;

            player.Move(difX, difY, physic);
        }

        public void Start()
        {
            timer.Start();
            Application.Run(view);
        }
    }

    public enum Direction
    {
        Down,
        Up,
        Left,
        Right,
        None,
    }

    public class Physic
    {
        public double G { get; private set; }
        public Physic(double g)
        {
            G = g;
        }
    }

    public static class Collider
    {
        public static ColliderData GetCollideData(this GameObject obj1, GameObject obj2)
        {
            bool flag = false;
            var dir = Direction.None;

            var x1 = obj1.X; var y1 = obj1.Y;
            var w1 = obj1.Width;
            var h1 = obj1.Height;

            var x2 = obj2.X; var y2 = obj2.Y;
            var w2 = obj2.Width;
            var h2 = obj2.Height;


            if ((x1 + w1) >= x2 && (y1 >= y2 && y1 <= (y2 + h2) || (y1 + h1) >= y2 && (y1 + h1) <= (y2 + h2)))
            {
                flag = true;
                dir = Direction.Right;
                
            }
            
            return new ColliderData(dir,flag);
        }
    }

    public class ColliderData
    {
        public Direction Direction { get; private set; }
        public bool Flag { get; private set; }

        public ColliderData(Direction direction, bool flag)
        {
            Direction = direction;
            Flag = flag;
        }
    }
}

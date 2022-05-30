using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Game
{
    

    public abstract class GameObject
    {
        public float X { get; protected set; }
        public float Y { get; protected set; }
        public int Height { get; protected set; }
        public int Width { get; protected set; }

        public Direction dir { get; protected set; }
        public bool isMoving { get; protected set; }

        public abstract PaintEventHandler Draw();
        public abstract void Move(int difX, int difY,Physic physic);
        
        public GameObject(float x, float y, int width, int height) 
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Direction GetDir(int difX, int difY)
        {
            Direction dirX;
            Direction dirY;

            dirX = difX > 0 ? Direction.Right : difX < 0 ? Direction.Left : Direction.None;
            dirY = difY > 0 ? Direction.Down : difY < 0 ? Direction.Up : Direction.None;

            if (dirX == Direction.None)
            {
                if (dirY == Direction.Up) return Direction.Up;
                else if (dirY == Direction.Down) return Direction.Down;
                return dir;
            }
            return dirX;
        }
    }
}

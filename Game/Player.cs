using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Game
{
    public class Player : GameObject
    {   
        public int Speed { get; private set; }
        
        private GameSprites sprites;

        public Player(MovementSprites sprites,int x, int y, int width, int height , int speed) : base(x, y, width, height)
        {
            this.sprites = sprites;
            Width = width;
            Height = height;
            Speed = speed;
            dir = Direction.Right;
        }

        public override PaintEventHandler Draw()
        {
            return sprites.GetSprite(this);
        }

        public override void Move(int difX, int difY, Physic physic)
        {
            var collisions = CheckCollision();
            dir = GetDir(difX, difY);

            if (collisions.Contains(Direction.Down) && difY > 0) difY = 0; 
            if (collisions.Contains(Direction.Up) && difY < 0) difY = 0; 
            if (collisions.Contains(Direction.Right) && difX > 0) difX = 0; 
            if (collisions.Contains(Direction.Left) && difX < 0) difX = 0; 

            isMoving = difX == 0 && difY == 0 ? false : true;
            

            X += difX;
            Y += difY;
        }

        public void Jump() 
        {

        }

        public HashSet<Direction> CheckCollision() 
        {
            var answer = new HashSet<Direction>();
            foreach (var elem in Game.gameObjects) 
            {
                var collide = this.GetCollideData(elem);
                if (collide.Flag) answer.Add(collide.Direction);
            }
            return answer;
        }
    }
}

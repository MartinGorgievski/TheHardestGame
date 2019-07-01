using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHardestGame
{
    
    public enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        UP_LEFT,
        UP_RIGHT,
        DOWN_LEFT,
        DOWN_RIGHT
    }
    [Serializable]
    public class Square
    {
        public Point Position { get; set; }
        public int X { get { return Position.X; } }
        public int Y { get { return Position.Y; } }
        public Direction dir { get; set; }
        public Direction prevDir { get; set; }
        private static int Speed = 5;
        public Stack<Direction> dirStack { get; set; }


        public Square()
        {
            dirStack = new Stack<Direction>();
            Position = new Point(162, 162);
        }

        public void Draw(Graphics g)
        {
            SolidBrush b = new SolidBrush(Color.Orange);
            g.FillRectangle(b, X, Y, 15, 15);
            b.Dispose();
        }
        public void DrawFinish(Graphics g)
        {
            SolidBrush b = new SolidBrush(Color.Green);
            g.FillRectangle(b, 632, 252, 30, 30);
            b.Dispose();
        }

        public void Move(Direction dir)
        {

            if (dir == Direction.RIGHT)
            {
                Position = new Point(X + Speed, Y);
                this.dir = dir;
            }
            if (dir == Direction.LEFT)
            {
                Position = new Point(X - Speed, Y);
                this.dir = dir;
            }
            if (dir == Direction.UP)
            {
                Position = new Point(X, Y - Speed);
                this.dir = dir;
            }
            if (dir == Direction.DOWN)
            {
                Position = new Point(X, Y + Speed);
                this.dir = dir;
            }
            dirStack.Push(dir);
        }
        public void checkDirSide()
        {

            if (dir == Direction.LEFT)
            {
                Position = new Point(X + 3, Y);
            }
            else if (dir == Direction.RIGHT)
            {
                Position = new Point(X - 3, Y);
            }
            else if (dir == Direction.UP)
            {
                Position = new Point(X, Y + 3);
            }
            else if (dir == Direction.DOWN)
            {
                Position = new Point(X, Y - 3);
            }
        }

        public bool canUp()
        {
            if ((Y == 52 && X < 208) || (Y == 252 && (X > 208 && X < 252)) || (Y == 77 && (X > 251 && X < 552)) || (Y == 52 && X > 551))
            {
                return false;
            }
            return true;
        }

        public bool canLeft()
        {
            if (X == 52 || (X == 252 && Y < 252) || (X == 582 && Y > 82) || (X == 552 && Y <77))
            {
                return false;
            }
            return true;
        }

        public bool canRight()
        {
            if ((X == 207 && (Y > 51 && Y < 252)) || (X == 282 && (Y > 232)) || (X == 532 && (Y > 82 && Y < 233)) || (X == 682 && (Y > 51 && Y < 283)))
            {
                return false;
            }
            return true;
        }

        public bool canDown()
        {
            if ((Y == 282 && ((X > 51 && X < 283) || (X > 581 && X < 683))) || (Y == 232 && (X > 286 && X < 533)) || (Y == 82 && (X > 536 && X < 578)))
            {
                return false;
            }
            return true;
        }
    }
}

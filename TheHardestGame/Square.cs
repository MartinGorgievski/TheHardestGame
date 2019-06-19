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
            if(dir  == Direction.LEFT)
            {
                Position = new Point(X - Speed, Y);
                this.dir = dir;
            }
            if(dir == Direction.UP)
            {
                Position = new Point(X, Y - Speed);
                this.dir = dir;
            }
            if(dir == Direction.DOWN)
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

        //public bool isHitWall(PointF prevPoint, PointF currPoint)
        //{
        //    float diffX = Math.Abs(prevPoint.X - currPoint.X);
        //    float diffY = Math.Abs(prevPoint.Y - currPoint.Y);

        //    if (diffX == 0)
        //    {
        //        float RangeLow = (prevPoint.Y > currPoint.Y) ? currPoint.Y : prevPoint.Y;
        //        float RangeHigh = (prevPoint.Y < currPoint.Y) ? currPoint.Y : prevPoint.Y;

        //        if(dirStack.Count > 0)
        //        {
        //            Direction curDir = dirStack.Pop();
        //            if (dir == Direction.RIGHT && curDir != Direction.LEFT)
        //            {
        //                return (Math.Abs(X - currPoint.X) <= 15) && Y >= RangeLow && Y <= RangeHigh;
        //            }

        //            else if (dir == Direction.RIGHT && curDir == Direction.LEFT)
        //            {
        //                return false;
        //            }

        //            if (dir == Direction.LEFT)
        //            {
        //                return (Math.Abs(X - currPoint.X) <= 3) && Y >= RangeLow && Y <= RangeHigh;
        //            }
        //        }
        //        else
        //        {
        //            if (dir == Direction.RIGHT)
        //            {
        //                return (Math.Abs(X - currPoint.X) <= 15) && Y >= RangeLow && Y <= RangeHigh;
        //            }
        //            if (dir == Direction.LEFT)
        //            {
        //                return (Math.Abs(X - currPoint.X) <= 3) && Y >= RangeLow && Y <= RangeHigh;
        //            }
        //        }
               
        //        return false;
        //    }
        //    else
        //    {
        //        float RangeLow = (prevPoint.X > currPoint.X) ? currPoint.X : prevPoint.X;
        //        float RangeHigh = (prevPoint.X < currPoint.X) ? currPoint.X : prevPoint.X;

        //        return (Math.Abs(Y - currPoint.Y) <= 15) && X >= RangeLow && X <= RangeHigh;
        //    }


        //}
    }
}

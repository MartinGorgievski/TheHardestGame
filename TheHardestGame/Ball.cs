using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace TheHardestGame
{
    [Serializable]
    public class Ball
    {
        public Point Position { get; set; }
        public int X { get { return Position.X; } }
        public int Y { get { return Position.Y; } }
        public  int Radius { get { return 10; } }
        private static int speed = 2;
        public Direction dir { get; set; }

        public Ball(Point position, Direction dir)
        {
            Position = position;
            this.dir = dir;
        }

        public void DrawBall(Graphics g)
        {
            SolidBrush b = new SolidBrush(Color.Blue);
            g.FillEllipse(b, X, Y, 2 * Radius, 2 * Radius);
            b.Dispose();
        }
        public void MoveBall()
        {
            if(dir == Direction.RIGHT)
            {
                Position = new Point(X + speed, Y);
            }
            if(dir == Direction.LEFT)
            {
                Position = new Point(X - speed, Y);
            }
            
        }
        public bool isHitWithBall(float x, float y)
        {



            return false;
        }
         
    }
}

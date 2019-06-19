using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace TheHardestGame
{
    [Serializable]
    public class GameDoc
    {
        public List<Ball> balls { get; set; }
        public Square square { get; set; }
        public PointF[] points { get; set; } 
        public int Fails { get; set; }
        public int Coins { get; set; }
        public float TimePast { get; set; }
        public GameDoc()
        {
            TimePast = 0.0F;
            Fails = 0;
            Coins = 0;
            balls = new List<Ball>();
            points = new PointF[18];
            square = new Square();

            points[0] = new PointF(50.0F, 50.0F);
            points[1] = new PointF(50.0F, 300.0F);
            points[2] = new PointF(300.0F, 300.0F);
            points[3] = new PointF(300.0F, 250.0F);
            points[4] = new PointF(550.0F, 250.0F);
            points[5] = new PointF(550.0F, 100.0F);
            points[6] = new PointF(580.0F, 100.0F);
            points[7] = new PointF(580.0F, 300.0F);
            points[8] = new PointF(580.0F, 300.0F);
            points[9] = new PointF(700.0F, 300.0F);
            points[10] = new PointF(700.0F, 50.0F);
            points[11] = new PointF(550.0F, 50.0F);
            points[12] = new PointF(550.0F, 75.0F);
            points[13] = new PointF(250.0F, 75.0F);
            points[14] = new PointF(250.0F, 250.0F);
            points[15] = new PointF(225.0F, 250.0F);
            points[16] = new PointF(225.0F, 50.0F);
            points[17] = new PointF(50.0F, 50.0F);

            Point p = new Point(260, 85);
            balls.Add(new Ball(p, Direction.RIGHT));

            Point p1 = new Point(530, 105);
            balls.Add(new Ball(p1, Direction.LEFT));

            Point p2 = new Point(260, 125);
            balls.Add(new Ball(p2, Direction.RIGHT));

            Point p3 = new Point(530, 145);
            balls.Add(new Ball(p3, Direction.LEFT));

            Point p4 = new Point(260, 165);
            balls.Add(new Ball(p4, Direction.RIGHT));

            Point p5 = new Point(530, 185);
            balls.Add(new Ball(p5, Direction.LEFT));

            Point p6 = new Point(260, 205);
            balls.Add(new Ball(p6, Direction.RIGHT));

            Point p7 = new Point(530, 225);
            balls.Add(new Ball(p7, Direction.LEFT));
        }

        public void DrawBalls(Graphics g)
        {
            foreach(Ball ball in balls)
            {
                isHitLineBall(ball);
                if(ball.isHitWithBall(square.X, square.Y))
                {
                    square.Position = new Point(162, 162);
                    Fails++;
                }
                ball.DrawBall(g);
            }
        }

        public void DrawSquare(Graphics g)
        {
            //isHitSquareLines();
           
            square.Draw(g);
        }

        public void isHitLineBall(Ball ball)
        {
            
            if (ball.Position.X + ball.Radius >= 540)
                ball.dir = Direction.LEFT;
            if(ball.Position.X + ball.Radius <= 260)
                ball.dir = Direction.RIGHT;
        }

        //public bool isHitSquareLines()
        //{
        //    var isFirst = false;
        //    PointF prevpoint = new PointF(0, 0);
        //    foreach (var point in points)
        //    {
        //        if (isFirst && square.isHitWall(prevpoint, point))
        //        {
        //            square.checkDirSide();
        //            return true;

        //        }
        //        isFirst = true;
        //        prevpoint = point;

        //    }
        //    return false;
        //}
    }
}

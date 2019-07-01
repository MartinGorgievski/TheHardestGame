using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TheHardestGame
{
    public partial class Level1 : Form
    {
        //public Square square;
        public GameDoc gameDoc;
        private Timer timer;
        String FileName = null;
        //private int TimerCount;
        //private bool timerActive;
        public Level1()
        {   
            InitializeComponent();
            panel1.Hide();
            DoubleBuffered = true;
            gameDoc = new GameDoc();
            timer = new Timer();
            timer.Interval = 10;
            //TimerCount = 0;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Stop();
            //timerActive = true;
            this.BackColor = Color.White;
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gameDoc.TimePast += timer.Interval;
            foreach(var item in gameDoc.balls)
            {
                item.MoveBall();
                Invalidate(true);
            }
            checkFinish(gameDoc.square.X, gameDoc.square.Y);
        }
        private void Level1_Paint(object sender, PaintEventArgs e)
        {
            Brush b = new SolidBrush(Color.Blue);
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            pen.Width = 5;
            toolStripLabel1.Text = "X: " + gameDoc.square.X + ", Y: " + gameDoc.square.Y;
            e.Graphics.DrawLines(pen, gameDoc.points);
            gameDoc.DrawBalls(e.Graphics);
            Time.Text = (gameDoc.TimePast / 1000).ToString() + ":"+ (gameDoc.TimePast % 1000).ToString() + "s";
            lblFails.Text ="Fails:" + gameDoc.Fails.ToString();
            gameDoc.DrawSquare(e.Graphics);
            gameDoc.square.DrawFinish(e.Graphics);
        }

        public bool checkDeath(float x, float y)
        {
            foreach (Ball b in gameDoc.balls)
            {
                if ((b.Position.X + b.Radius >= x && b.Position.X - b.Radius <= x) && (b.Position.Y + b.Radius >= y -10 && b.Position.Y - b.Radius <= y))
                {
                    return true;
                }
            }

            return false;
        }
        
        public void checkFinish(float x, float y)
        {
            if (checkDeath(x, y))
            {
                timer.Stop();
                gameDoc.Fails += 1;
                gameDoc.square.Position = new Point(162, 162);
                timer.Start();
            }
            if(x > 617 && x < 662 && y > 237 && y < 282)
            {
                timer.Stop();
                string message = "BRAVO!";
                var rez = MessageBox.Show(message);
                if (rez == DialogResult.OK)
                {
                    panelStart.Enabled = true;
                    panelStart.Show();
                    gameDoc.TimePast = 0;
                    gameDoc.Fails = 0;
                    gameDoc.square.Position = new Point(162, 162);
                    lblFails.Text = "Fails: 0";
                    Time.Text = "00:00";
                    panel1.Enabled = false;
                    panel1.Hide();
                }
            }
        }
        private void Level1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Up && gameDoc.square.canUp())
            {
               gameDoc.square.Move(Direction.UP);
               //checkFinish(gameDoc.square.X, gameDoc.square.Y);
               Invalidate(true);
            }
            if(e.KeyCode == Keys.Down && gameDoc.square.canDown())
            {
               gameDoc.square.Move(Direction.DOWN);
                //checkFinish(gameDoc.square.X, gameDoc.square.Y);
                Invalidate(true);
            }
            if(e.KeyCode == Keys.Left && gameDoc.square.canLeft())
            {
              gameDoc.square.Move(Direction.LEFT);
                //checkFinish(gameDoc.square.X, gameDoc.square.Y);
                Invalidate(true);
            }

            if(e.KeyCode == Keys.Right && gameDoc.square.canRight())
            {
              gameDoc.square.Move(Direction.RIGHT);
                //checkFinish(gameDoc.square.X, gameDoc.square.Y);
              Invalidate(true); 
            }
           
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel1.Show();
            timer.Stop();
        }

        private void btnRezume_Click(object sender, EventArgs e)
        {
            
            panel1.Enabled = false;
            panel1.Hide();
            timer.Start();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel1.Show();
            timer.Stop();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel1.Hide();
            timer.Start();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            panelStart.Enabled = false;
            panelStart.Hide();
            timer.Start();
        }

        private void btnExitOnStart_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            panelStart.Enabled = true;
            panelStart.Show();
            gameDoc.TimePast = 0;
            gameDoc.Fails = 0;
            gameDoc.square.Position = new Point(162, 162);
            lblFails.Text = "Fails: 0";
            Time.Text = "00:00";
            panel1.Enabled = false;
            panel1.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(FileName == null)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "TheHardestGame file (*.hdr) | *.hdr";
                saveFileDialog1.Title = "Save game progress";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    FileName = saveFileDialog1.FileName;
            }
            if(FileName != null)
            {
                System.Runtime.Serialization.IFormatter fmt = new
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                System.IO.FileStream strm = new System.IO.FileStream(FileName, System.IO.FileMode.Create,
                    System.IO.FileAccess.Write, System.IO.FileShare.None);
                fmt.Serialize(strm, gameDoc);
                strm.Close();
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            FileName = null;
            btnSave_Click(sender, e);
        }

        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "TheHardestGame file (*.hdr) | *.hdr";
            openFileDialog1.Title = "Save game progress";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileName = openFileDialog1.FileName;
                    System.Runtime.Serialization.IFormatter fmt = new
                        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    System.IO.FileStream strm = new System.IO.FileStream(FileName, System.IO.FileMode.Open,
                        System.IO.FileAccess.Read, System.IO.FileShare.None);
                    gameDoc = (GameDoc)fmt.Deserialize(strm);
                    strm.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: Could not read file \"" + FileName + "\" form disk Original error:" + ex.Message);
                    FileName = null;
                }
            }
            Invalidate(true);
        }

        private void btnLoadG_Click(object sender, EventArgs e)
        {
            
            btnLoadGame_Click(sender, e);
            panelStart.Hide();
            panelStart.Enabled = false;
        }
    }
}

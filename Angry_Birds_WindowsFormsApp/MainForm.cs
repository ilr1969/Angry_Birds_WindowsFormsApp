using System;
using System.Drawing;
using System.Windows.Forms;

namespace Angry_Birds_WindowsFormsApp
{
    public partial class MainForm : Form
    {
        BirdBall birdBall;
        PigBall pigBall;
        Timer timer;
        public MainForm()
        {
            InitializeComponent();
            pigBall = new PigBall(this);
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (CheckCollision())
            {
                ScoreLabel.Text = (Convert.ToInt32(ScoreLabel.Text) + 1).ToString();
                StartNewGame();
            }
            else if (birdBall.yPos > ClientSize.Height + birdBall.Radius || birdBall.xPos > ClientSize.Width)
            {
                timer.Stop();
                birdBall.xPos = 0;
                birdBall.yPos = ClientSize.Height - birdBall.Radius;
                birdBall.RecreateBirdBall();
            }
            else if (birdBall.yPos > ClientSize.Height)
            {
                birdBall.xSpeed /= 1.2F;
                birdBall.ySpeed = -birdBall.ySpeed / 1.1F;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            timer.Start();
            if (e.X < ClientSize.Width / 3)
            {
                birdBall.Start(e.X, e.Y);
            }
        }

        public void StartNewGame()
        {
            pigBall.Clear();
            pigBall = new PigBall(this);
            pigBall.Draw();
            birdBall = new BirdBall(this);
            birdBall.Draw();
            Graphics graphics = CreateGraphics();
            graphics.DrawLine(new Pen(Brushes.Black), ClientSize.Width / 3, 0, ClientSize.Width / 3, ClientSize.Height);
        }

        public bool CheckCollision()
        {
            return ((pigBall.xPos - birdBall.xPos) * (pigBall.xPos - birdBall.xPos) + (pigBall.yPos - birdBall.yPos) * (pigBall.yPos - birdBall.yPos) <= pigBall.Radius * pigBall.Radius);
        }

        private void перезапускИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void правилаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Слева появляется красная птичка.\n" +
                "2. Справа в произвольном месте - зелёная свинья.\n" +
                "3. Нужно щёлкнуть в левой части экрана, чтобы запустить птичку.\n" +
                "4. Если птичка попадёт в свинью - игроку защитывается очко, сбитая свинья исчезает и появляется новая в произвольном месте.\n" +
                "Игра продолжается.");
        }
    }
}

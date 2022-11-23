using System.Drawing;
using System.Windows.Forms;

namespace Angry_Birds_WindowsFormsApp
{
    public class BirdBall : Ball
    {
        protected Timer timer = new Timer();
        public float xSpeed = 5;
        public float ySpeed = 5;
        protected float g = 0.5F;
        public BirdBall(MainForm form) : base(form)
        {
            yPos = form.ClientSize.Height - Radius;
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            Clear();
            Move();
            Draw();
            var graphics = form.CreateGraphics();
            graphics.DrawLine(new Pen(Brushes.Black), form.ClientSize.Width / 3, 0, form.ClientSize.Width / 3, form.ClientSize.Height);
        }
        public void RecreateBirdBall()
        {
            Stop();
            Clear();
            Draw();
        }

        public void Move()
        {
            ySpeed -= g;
            xPos += xSpeed;
            yPos -= ySpeed;
        }

        public void Start(int xMousePos, int yMousePos)
        {
            xSpeed = (xMousePos) / 10;
            ySpeed = (form.ClientSize.Height - yMousePos) /10;
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}

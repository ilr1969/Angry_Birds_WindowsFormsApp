using System.Drawing;

namespace Angry_Birds_WindowsFormsApp
{
    public class Ball
    {
        protected MainForm form;
        public float xPos = 0;
        public float yPos = 0;
        public int Radius = 20;
        protected Brush brush = Brushes.Red;
        public Ball(MainForm form)
        {
            this.form = form;
        }

        public void Draw()
        {
            Graphics Circle = form.CreateGraphics();
            var rectangle = new RectangleF(xPos, yPos, Radius, Radius);
            Circle.FillEllipse(brush, rectangle);
        }
        public void Clear()
        {
            Graphics Circle = form.CreateGraphics();
            var rectangle = new RectangleF(xPos, yPos, Radius, Radius);
            Circle.FillEllipse(Brushes.White, rectangle);
        }

    }
}

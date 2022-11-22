using System;
using System.Drawing;

namespace Angry_Birds_WindowsFormsApp
{
    public class PigBall : Ball
    {
        Random random = new Random();
        public PigBall(MainForm form) : base(form)
        {
            Radius = random.Next(20, 40);
            brush = Brushes.Green;
            xPos = random.Next(form.ClientSize.Width / 2, form.ClientSize.Width - Radius);
            yPos = random.Next(0, form.ClientSize.Height - Radius);
        }
    }
}

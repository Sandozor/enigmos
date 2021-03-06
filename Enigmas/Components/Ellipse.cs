﻿using Cpln.Enigmos.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cpln.Enigmos.Enigmas.Components
{
    class Ellipse : Panel
    {
        
        public Ellipse()
        {
            Paint += new PaintEventHandler(DrawEllipse);
        }

        private void DrawEllipse(object sender, PaintEventArgs e)
        {
            SolidBrush myBrush = new SolidBrush(Color.Red);
            Graphics formGraphics;

            formGraphics = this.CreateGraphics();
            formGraphics.FillEllipse(myBrush, new Rectangle(0, 0, Width, Height));
            myBrush.Dispose();
            formGraphics.Dispose();
        }
    }
}

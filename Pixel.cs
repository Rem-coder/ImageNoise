using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageNoise
{
    class Pixel
    {
        public Point Location { get; }
        public Color Color { get; }

        public Pixel(Color color, Point location)
        {
            Location = location;
            Color = color;
        }
    }
}

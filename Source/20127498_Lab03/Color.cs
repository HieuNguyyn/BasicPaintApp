using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20127498_Lab01
{
    class Color
    {
        // Red
        public float R { get; set; }
        // Green
        public float G { get; set; }
        // Blue
        public float B { get; set; }
        //Initialization Function
        public Color(float r = 0, float g = 0, float b = 0)
        {
            R = r;
            G = g;
            B = b;
        }
        public Color(Color c)
        {
            R = c.R;
            G = c.G;
            B = c.B;
        }
        public void setColor(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }
        // Comparison Operator
        public static bool operator ==(Color color1, Color color2)
        {
            float e = 1.0f / 10000000.0f;
            return (Math.Abs(color1.R - color2.R) < e && Math.Abs(color1.G - color2.G) < e && Math.Abs(color1.B - color2.B) < e);
        }
        public static bool operator !=(Color color1, Color color2)
        {
            return !(color1 == color2);
        }
        public float getR() { return R; }
        public float getG() { return G; }
        public float getB() { return B; }
    }
}

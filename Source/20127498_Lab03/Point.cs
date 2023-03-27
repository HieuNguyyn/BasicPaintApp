using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20127498_Lab01
{
    class Point
    {
        // Initialization Functions
        public int X { get; set; } // Coordinate of X
        public int Y { get; set; } // Coordinate of Y
        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }
        public void setPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void setPoint(Point c)
        {
            X = c.X;
            Y = c.Y;
        }
        public int getX() { return X; }
        public int getY() { return Y; }
    }
}

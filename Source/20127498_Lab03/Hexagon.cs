using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20127498_Lab01
{
    // Because Hexagon is Polygon with 6 vertices so class Hexagon inherits class Polygon
    class Hexagon : Polygon
    {
        // Initialize a Hexagon
        public Hexagon()
        {
            nPoly = 6;
            init();
        }
        public override void set(Point pi, Point pj)
        {
            base.set(pi, pj);
            // y_max = y_min + The height of the hexagon (height = sqrt(3)/2 * bottom length)
            p2r.Y = p2.Y = p1.Y + (int)Math.Round((p2.X - p1.X) * Math.Sqrt(3) / 2.0);
            // With p1(x_min, y_min) and p2(x_max, y_max)
            //  A--dx-rx-dx-p2
            //  --------------
            //  ry----------ry
            //  --------------
            //  p1-dx-rx-dx--B
            //  rx is the distance from p1 to B divide by 2, ry is the distance from A to p1 divide by 2
            //  dx is rx devide by 2
            int rx = Math.Abs(p1.X - p2.X) / 2, ry = Math.Abs(p1.Y - p2.Y) / 2;
            int dx = rx / 2;
            // Coordinate of 6 vertices in Oxy
            // Coordinate of 3 vertices in Oxy
            //               y
            //               |
            //               |
            //            0--|--1
            //           /   |   \
            //  --------5----|----2----------x
            //           \   |   / 
            //            4--|--3  
            //               |
            //               |
            nPoints[0].setPoint(-dx, ry);
            nPoints[1].setPoint(dx, ry);
            nPoints[2].setPoint(rx, 0);
            nPoints[3].setPoint(dx, -ry);
            nPoints[4].setPoint(-dx, -ry);
            nPoints[5].setPoint(-rx, 0);
        }
    }
}

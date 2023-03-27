using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20127498_Lab01
{
    // Because Rectangle is Polygon with 4 vertices so class Rectangle inherits class Polygon
    class Rectangle : Polygon
    {
        // Initialize a Rectangle
        public Rectangle()
        {
            nPoly = 4;
            init();
        }

        public override void set(Point A, Point B)
        {
            base.set(A, B);
            // With p1(x_min, y_min) and p2(x_max, y_max)
            //  A----rx---p2
            //  ------------
            //  ry--------ry
            //  ------------
            //  p1---rx----B
            //  rx is the distance from p1 to B divide by 2, ry is the distance from A to p1 divide by 2
            int rx = Math.Abs(p1.X - p2.X) / 2, ry = Math.Abs(p1.Y - p2.Y) / 2;
            // Coordinates of 4 vertices in Oxy
            //               y
            //               |
            //         3-----|-----2
            //         |     |     |
            //         |     |     |
            //  -------|-----|-----|---------x
            //         |     |     |
            //         |     |     |
            //         0-----|-----1
            //               |
            nPoints[0].setPoint(-rx, -ry);
            nPoints[1].setPoint(rx, -ry);
            nPoints[2].setPoint(rx, ry);
            nPoints[3].setPoint(-rx, ry);
        }
    }
}

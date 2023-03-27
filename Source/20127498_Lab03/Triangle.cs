using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20127498_Lab01
{
    // Because Triangle is Polygon with 3 vertices so class Triangle inherits class Polygon
    class Triangle : Polygon
    {
        // Initialize the Triangle
        public Triangle()
        {
            nPoly = 3;
            init();
        }

        public override void set(Point A, Point B)
        {
            base.set(A, B);
            // y_max = y_min + The height of the triangle (height = sqrt(3)/2 * bottom length)
            p2r.Y = p2.Y = p1.Y + (int)Math.Round((p2.X - p1.X) * Math.Sqrt(3) / 2.0);
            // With p1(x_min, y_min) and p2(x_max, y_max)
            //  A----rx---p2
            //  ------------
            //  ry--------ry
            //  ------------
            //  p1---rx----B
            //  rx is the distance from p1 to B divide by 2, ry is the distance from A to p1 divide by 2
            int rx = Math.Abs(p1.X - p2.X) / 2, ry = Math.Abs(p1.Y - p2.Y) / 2;
            // Coordinate of 3 vertices in Oxy
            //               y
            //               |
            //               0
            //              /|\
            //             / | \
            //  ----------/--|--\------------x
            //           /   |   \
            //          /    |    \
            //         1-----|-----2
            //               |
            nPoints[0].setPoint(0, ry);
            nPoints[1].setPoint(-rx, -ry);
            nPoints[2].setPoint(rx, -ry);
        }
    }
}

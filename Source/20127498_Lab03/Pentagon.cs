using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20127498_Lab01
{
    // Because Pentagon is Polygon with 5 vertices so class Pentagon inherits class Polygon
    class Pentagon : Polygon
    {
        public Pentagon()
        {
            nPoly = 5;
            init();
        }

        public override void set(Point A, Point B)
        {
            base.set(A, B);
            // y_max = y_min + d (where d = x_max - x_min)
            p2r.Y = p2.Y = p1.Y + (p2.X - p1.X);
            // With p1(x_min, y_min) and p2(x_max, y_max)
            //  A----rx---p2
            //  ------------
            //  ry--------ry
            //  ------------
            //  p1---rx----B
            //  rx is the distance from p1 to B divide by 2, ry is the distance from A to p1 divide by 2
            int rx = Math.Abs(p1.X - p2.X) / 2, ry = Math.Abs(p1.Y - p2.Y) / 2;
            int x18 = (int)Math.Round(rx * Math.Cos(18 * Math.PI / 180)),
                x54 = (int)Math.Round(rx * Math.Cos(54 * Math.PI / 180)),
                y18 = (int)Math.Round(ry * Math.Sin(18 * Math.PI / 180)),
                y54 = (int)Math.Round(ry * Math.Sin(54 * Math.PI / 180));
            // Coordinate of 5 vertices in Oxy
            //         y
            //         |
            //         |
            //  ---C---0---B---  
            //  ---|/--|--\|---
            //  ---1---|---4------x
            //  ---|\--|--/|---
            //  ---A-2-|-3-D---
            //         |
            //         |
            // nPoints[0].setPoint((x_max + x_min) / 2, y_max);
            // Distance from 0 to C: d0C = x_nPoints[0] - x_min
            // Distance from C to 1: dC1 = (int)Math.Round(d0C / Math.Tan(54 * Math.PI / 180))
            // nPoints[1].setPoint(x_min, y_max - dC1);
            // nPoints[4].setPoint(x_min, y_max - dC1);
            // Distance from 1 to A: d1A = y_nPoints[1] - y_min
            // Distance from A to 2 = distance from 3 to D: dA2 = (int)Math.Round(d1A / Math.Tan(72 * Math.PI / 180))
            // nPoints[2].setPoint(x_min + dA2, y_min);
            // nPoints[3].setPoint(x_max - dA2, y_min);
            nPoints[0].setPoint(0, ry);
            nPoints[1].setPoint(x18, y18);
            nPoints[2].setPoint(x54, -y54);
            nPoints[3].setPoint(-x54, -y54);
            nPoints[4].setPoint(-x18, y18);
        }
    }
}

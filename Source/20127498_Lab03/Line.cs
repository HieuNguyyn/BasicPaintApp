using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;

namespace _20127498_Lab01
{
    // Because Line is Object so class Line inherits class Object
    class Line : Object
    {
        // Initialize the Line
        public Line() { }
        public Line(Point s, Point e)
        {
            p1.setPoint(s);
            p2.setPoint(e);
        }
        // Set p1 = A, p2 = B
        public override void set(Point A, Point B)
        {
            p1.setPoint(A.X, A.Y);
            p2.setPoint(B.X, B.Y);
        }
        public Point getP1()
        {
            return p1;
        }
        public Point getP2()
        {
            return p2;
        }
        // Draw a Line with Color and Thinkness
        public override void Draw(OpenGL gl)
        {
            gl.Color(LineColor.R, LineColor.G, LineColor.B);
            gl.LineWidth(LineWidth);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex2sv(new short[] { (short)p1.X, (short)p1.Y });
            gl.Vertex2sv(new short[] { (short)p2.X, (short)p2.Y });
            gl.End();
            gl.Flush();
        }
        // Determine that point(x, y) is inside the box of control point or not
        public override bool isInsideBox(int x, int y)
        {
            if (Math.Abs(y - p1.Y) <= 2.0 && Math.Abs(p2.Y - p1.Y) <= 2.0)
                return (x >= p1.X && x <= p2.X) || (x < p1.X && x > p2.X);
            if (Math.Abs(x - p1.X) <= 2.0 && Math.Abs(p2.X - p1.X) <= 2.0)
                return (y >= p1.Y && y <= p2.Y) || (y < p1.Y && y > p2.Y);
            double a = (double)(x - p1.X) / (y - p1.Y), b = (double)(p2.X - p1.X) / (p2.Y - p1.Y);
            return (Math.Abs(a - b) < 0.5);
        }
        // Draw the control points
        public override void drawControlBox(OpenGL gl)
        {
            Rectangle box = new Rectangle();
            Color c = new Color(0.5f, 0.5f, 0.5f);
            box.LineColor = c;
            // Coordinate of the control points
            int[][] cp = new int[][] {  new int[]{p1.X, p1.Y},
                                        new int[]{ p2.X, p2.Y} };
            // Draw the control points
            foreach (int[] p in cp)
            {
                box.set(new Point(p[0] - 3, p[1] - 3), new Point(p[0] + 3, p[1] + 3));
                box.Draw(gl);
                gl.Flush();
            }
        }
        // Translation
        public override void translate(Point s, Point e)
        {
            // Translation vector
            int vx = e.X - s.X,
                vy = e.Y - s.Y;
            // Translate the control points
            p1.X += vx;
            p2.X += vx;
            p1.Y += vy;
            p2.Y += vy;
        }
        // Determine the selected control point
        public override int getControlPointId(int x, int y)
        {
            // Coordinate of control points
            int[][] cp = new int[][] {
                new int[]{p1.X, p1.Y},
                 new int[]{ p2.X, p2.Y }
            };
            // Determine that point is selected
            for (int i = 0; i < 2; i++)
            {
                if (x >= cp[i][0] - 5 && x <= cp[i][0] + 5 && y >= cp[i][1] - 5 && y <= cp[i][1] + 5)
                    return i;
            }
            return -1;
        }
        // Scale the shape
        public override void dragControlPoint(int CPid, Point s, Point e)
        {
            // Translation vector
            int vx = e.X - s.X,
                vy = e.Y - s.Y;
            int x1 = p1.X, y1 = p1.Y, x2 = p2.X, y2 = p2.Y;
            Point pu = new Point(), pv = new Point();
            pu.setPoint(p1); pv.setPoint(p2);
            // Scale the shape
            if (CPid == 0) // is the first point
                pu.setPoint(x1 + vx, y1 + vy);
            else // is the second point
                pv.setPoint(x2 + vx, y2 + vy);
            p1.setPoint(pu);
            p2.setPoint(pv);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;

namespace _20127498_Lab01
{
    class Object
    {
        // Color of Line
        public Color LineColor { get; set; } = new Color();
        // Color Fill
        public Color FillColor { get; set; } = new Color();
        // Size of Thickness
        public int LineWidth { get; set; } = 1;
        // The point on the left and top
        protected Point p1 = new Point();
        // The point on the right and bottom
        protected Point p2 = new Point();
        // p1----------
        // ------------
        // ------------
        // ------------
        // ----------p2
        // Set x_min, y_min and x_max, y_max
        public virtual void set(Point A, Point B)
        {
            p1.setPoint(Math.Min(A.X, B.X), Math.Min(A.Y, B.Y));
            p2.setPoint(Math.Max(A.X, B.X), Math.Max(A.X, B.X));
        }
        // Draw
        public virtual void Draw(OpenGL gl) { }
        // Determine that point(x, y) is inside the box of control point or not
        public virtual bool isInsideBox(int x, int y) { return false; }
        // Draw the control points
        public virtual void drawControlBox(OpenGL gl) { }
        // Fill color, mode = true is Flood Fill, false is Scan Line Fill
        public virtual void Fill(OpenGL gl, bool mode) { }
        // Determine the selected control point
        public virtual int getControlPointId(int x, int y) { return -1; }
        // Translation
        public virtual void translate(Point s, Point e) { }
        // Scale the shape
        public virtual void dragControlPoint(int CPid, Point s, Point e) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;

namespace _20127498_Lab01
{
    // Because Ellipse is Shape so class Ellipse inherits class Shape
    class Ellipse : Shape
    {
        public override void set(Point A, Point B)
        {

            p1.setPoint(Math.Min(A.X, B.X), Math.Min(A.Y, B.Y));
            p2.setPoint(Math.Max(A.X, B.X), Math.Max(A.Y, B.Y));
        }

        // Draw a pixel with a diffirent thick
        private void DrawPoint(OpenGL gl, int u, int v)
        {
            for (int i = 0; i < LineWidth; i++)
                for (int j = 0; j < LineWidth; j++)
                    gl.Vertex2sv(new short[] { (short)(u + i), (short)(v + j) });

        }
        // Draw the ellipse
        public override void Draw(OpenGL gl)
        {
            int cx = (p1.X + p2.X) / 2;
            int cy = (p1.Y + p2.Y) / 2;
            gl.Color(LineColor.R, LineColor.G, LineColor.B);
            // Push the current matrix into the stack
            gl.PushMatrix();
            // Basic affine transform functions
            // Translation
            gl.Translate(cx, cy, 0.0);
            // Rotate
            gl.Rotate(Angle, 0.0, 0.0, 1.0);
            gl.Begin(OpenGL.GL_POINTS);
            int u, v;
            // Draw 4 points corresponding to 4 part of coordinate axis
            int[][] quarter = { new int[] { 1, 1 },
                                new int[] { -1, 1 },
                                new int[] { 1, -1 },
                                new int[] { -1, -1 } };
            // Calculate the basic parameters
            int rx = p2.X - cx, // rx
            ry = p2.Y - cy,     // ry        
            x = 0, y = ry,      // (x0, y0) = (0, ry) 
            rx2 = rx * rx,      // rx^2
            ry2 = ry * ry,      // ry^2
            x2 = 2 * ry2 * x,   // 2ry^2x0        
            y2 = 2 * rx2 * y;   // 2rx^2y0        
            double p = (ry2 - rx2 * ry) + rx2 / 4.0; // ry^2 - rx^2ry + 1/4rx^2
            cx = cy = 0;
            // Draw according to algorithm in the theoretical class
            // Area 1
            while (x2 < y2)
            {
                foreach (int[] i in quarter)
                {
                    u = x * i[0] + cx;
                    v = y * i[1] + cy;
                    DrawPoint(gl, u, v);
                }
                x++;
                x2 += (ry2 * 2);
                if (p < 0)
                {
                    p += (x2 + ry2);
                }
                else
                {
                    y--;
                    y2 -= (rx2 * 2);
                    p += (x2 - y2 + ry2);
                }
            }
            // Area 2
            // (x0, y0) = (x_last, y_last)
            p = (double)ry2 * (x + 0.5) * (x + 0.5) + (double)rx2 * (y - 1) * (y - 1) - (double)rx2 * ry2;
            while (y > 0)
            {
                foreach (int[] i in quarter)
                {
                    u = x * i[0] + cx;
                    v = y * i[1] + cy;
                    DrawPoint(gl, u, v);
                }
                y--;
                y2 -= (rx2 * 2);
                if (p > 0)
                {
                    p += (rx2 - y2);
                }
                else
                {
                    x++;
                    x2 += (ry2 * 2);
                    p += (x2 - y2 + rx2);
                }
            }
            foreach (int[] i in quarter)
            {
                u = x * i[0] + cx;
                v = y * i[1] + cy;
                DrawPoint(gl, u, v);
            }
            gl.End();
            // Get the current matrix at the top of the stack
            gl.PopMatrix();
        }
        public override void Fill(OpenGL gl, bool mode) { }
    }
}

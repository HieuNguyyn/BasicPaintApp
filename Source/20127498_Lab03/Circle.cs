using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;

namespace _20127498_Lab01
{
    // Because Circle is Ellipse so class Circle inherits class Ellipse
    class Circle : Ellipse
    {
        // Draw a pixel with a diffirent thick
        private void DrawPoint(OpenGL gl, int u, int v)
        {
            for (int i = 0; i < LineWidth; i++)
                for (int j = 0; j < LineWidth; j++)
                    gl.Vertex2sv(new short[] { (short)(u + i), (short)(v + j) });

        }
        //Draw the circle
        public override void Draw(OpenGL gl)
        {
            gl.Color(LineColor.R, LineColor.G, LineColor.B);
            gl.Begin(OpenGL.GL_POINTS);
            int u, v;
            // Draw 4 points corresponding to 4 part of coordinate axis
            int[][] quarter = { new int[] { 1, 1 },
                                new int[] { -1, 1 },
                                new int[] { 1, -1 },
                                new int[] { -1, -1 } };
            // Calculate the basic parameters
            int cx = (p1.X + p2.X) / 2,
                cy = (p1.Y + p2.Y) / 2,
                rx = p2.X - cx,         // rx
                ry = rx,                // ry
                x = 0, y = ry,          // (x0, y0) = (0, ry) 
                rx2 = rx * rx,          // rx^2
                ry2 = ry * ry,          // ry^2
                x2 = 2 * ry2 * x,       // 2ry^2x0        
                y2 = 2 * rx2 * y;       // 2rx^2y0      
            double P = (ry2 - rx2 * ry) + rx2 / 4.0; // ry^2 - rx^2ry + 1/4rx^2
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
                if (P < 0)
                {
                    P += (x2 + ry2);
                }
                else
                {
                    y--;
                    y2 -= (rx2 * 2);
                    P += (x2 - y2 + ry2);
                }
            }
            // Area 2
            // (x0, y0) = (x_last, y_last)
            P = (double)ry2 * (x + 0.5) * (x + 0.5) + (double)rx2 * (y - 1) * (y - 1) - (double)rx2 * ry2;
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
                if (P > 0)
                {
                    P += (rx2 - y2);
                }
                else
                {
                    x++;
                    x2 += (ry2 * 2);
                    P += (x2 - y2 + rx2);
                }
            }
            gl.End();
        }
        public override void Fill(OpenGL gl, bool mode) { }
    }
}

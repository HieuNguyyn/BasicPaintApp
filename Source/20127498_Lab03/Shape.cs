using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;

namespace _20127498_Lab01
{
    class Shape : Object
    {
        // Rotation angle
        public double Angle { get; set; } = 0.0;
        // Set x_min, y_min and x_max, y_max
        public override void set(Point pi, Point pj)
        {
            p1.setPoint(pi.X < pj.X ? pi.X : pj.X, pi.Y < pj.Y ? pi.Y : pj.Y);
            p2.setPoint(pi.X > pj.X ? pi.X : pj.X, pi.Y > pj.Y ? pi.Y : pj.Y);
        }
        // Determine that point(x, y) is inside the box of control point or not
        public override bool isInsideBox(int x, int y)
        {
            // Center point
            int cx = (p1.X + p2.X) / 2, cy = (p1.Y + p2.Y) / 2;
            // Move the coordinate from (0, 0) to the (cx, cy)
            x -= cx;
            y -= cy;
            // Formula follow the link: https://gamefromscratch.com/gamedev-math-recipes-rotating-one-point-around-another-point/
            int u = (int)Math.Round(x * Math.Cos(-Angle * Math.PI / 180) - y * Math.Sin(-Angle * Math.PI / 180)),
                v = (int)Math.Round(y * Math.Cos(-Angle * Math.PI / 180) + x * Math.Sin(-Angle * Math.PI / 180));
            x = u; y = v;
            return !(x < p1.X - cx || x > p2.X - cx || y < p1.Y - cy || y > p2.Y - cy);
        }
        // Draw the control points
        public override void drawControlBox(OpenGL gl)
        {
            int cx = (p1.X + p2.X) / 2,
                cy = (p1.Y + p2.Y) / 2;
            gl.Color(LineColor.R, LineColor.G, LineColor.B);
            // Push the current matrix into the stack
            gl.PushMatrix();
            // Basic affine transform functions
            // Translation
            gl.Translate(cx, cy, 0.0);
            // Rotation
            gl.Rotate(Angle, 0.0, 0.0, 1.0);
            // Create a box of control points
            Rectangle box = new Rectangle();
            int x1 = p1.X - cx - 5, y1 = p1.Y - cy - 10, x2 = p2.X - cx + 5, y2 = p2.Y - cy + 10;
            Point pi = new Point(x1, y1), pj = new Point(x2, y2);
            box.LineColor = new Color(0.5f, 0.5f, 0.5f);
            // Draw the frame surrounding the shape
            box.set(pi, pj);
            box.Draw(gl);
            // Draw 8 control points
            int xm = 0, ym = 0;
            int[][] cp = new int[][] {  new int[]{x1, y1},
                                        new int[]{x2, y2},
                                        new int[]{x1, y2},
                                        new int[]{x2, y1},
                                        new int[]{x1, ym},
                                        new int[]{x2, ym},
                                        new int[]{xm, y1},
                                        new int[]{xm, y2} };
            foreach (int[] p in cp)
            {
                box.set(new Point(p[0] - 3, p[1] - 3), new Point(p[0] + 3, p[1] + 3));
                box.Draw(gl);
            }
            // Draw the control point to rotate the shape
            Line li = new Line();
            li.set(new Point(xm, y2), new Point(xm, y2 + 20 - 4));
            li.LineColor = new Color(0.5f, 0.5f, 0.5f);
            li.Draw(gl);
            Circle ci = new Circle();
            ci.set(new Point(xm - 3, y2 + 20 - 3), new Point(xm + 3, y2 + 20 + 3));
            ci.LineColor = new Color(0.5f, 0.5f, 0.5f);
            ci.Draw(gl);
            // Get the current matrix at the top of the stack
            gl.PopMatrix();
        }
        // Get color of pixel(x, y)
        private Color getPixelColor(OpenGL gl, int x, int y) 
        {
            Color color = new Color();
            byte[] pixels = new byte[4];
            gl.ReadPixels(x, y, 2, 2, OpenGL.GL_RGB, OpenGL.GL_UNSIGNED_BYTE, pixels);
            color.setColor(pixels[0] / 255.0f, pixels[1] / 255.0f, pixels[2] / 255.0f);
            return color;
        }
        // Set color to pixel(x, y)
        private void setPixelColor(OpenGL gl, int x, int y, Color color) 
        {
            gl.Color(color.R, color.G, color.B);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(x, y);
            gl.End();
            gl.Flush();
        }
        // Flood Fill Algorithm
        // You can follow the link for detail: https://www.geeksforgeeks.org/flood-fill-algorithm-implement-fill-paint/
        private void floodFill(OpenGL gl, int x, int y, Color oldColor)
        {
            Color color = new Color(getPixelColor(gl, x, y));
            if (color == oldColor)
            {
                setPixelColor(gl, x, y, FillColor);
                floodFill(gl, x + 1, y, FillColor);
                floodFill(gl, x - 1, y, FillColor);
                floodFill(gl, x, y + 1, FillColor);
                floodFill(gl, x, y - 1, FillColor);
            }
        }
        // Fill color with mode = true is Flood Fill and false is Scan Line Fill
        public override void Fill(OpenGL gl, bool mode)
        {
            if (mode == true)
            {
                int cx = (p1.X + p2.X) / 2,
                    cy = (p1.Y + p2.Y) / 2;
                Color oldColor = getPixelColor(gl, cx, cy);
                floodFill(gl, cx, cy, oldColor);
            }
        }
        // Determine the selected control point
        public override int getControlPointId(int x, int y)
        {
            int cx = 0, cy = 0;
            if (Angle != 0)
            {
                // Center point
                cx = (p1.X + p2.X) / 2; cy = (p1.Y + p2.Y) / 2;
                // Move the coordinate from (0, 0) to the (cx, cy)
                x -= cx;
                y -= cy;
                // Formula follow the link: https://gamefromscratch.com/gamedev-math-recipes-rotating-one-point-around-another-point/
                int u = (int)Math.Round(x * Math.Cos(-Angle * Math.PI / 180) - y * Math.Sin(-Angle * Math.PI / 180)),
                    v = (int)Math.Round(y * Math.Cos(-Angle * Math.PI / 180) + x * Math.Sin(-Angle * Math.PI / 180));
                x = u; y = v;
            }
            int x1 = p1.X - cx - 5,
                y1 = p1.Y - cy - 5,
                x2 = p2.X - cx + 5,
                y2 = p2.Y - cy + 5;
            int xm = cx == 0 ? (p1.X + p2.X) / 2 : 0,
                ym = cy == 0 ? (p1.Y + p2.Y) / 2 : 0;
            // Coordinate of control points
            int[][] cp = new int[][] {  new int[]{x1, y1}, // 0
                                        new int[]{x2, y2}, // 1
                                        new int[]{x1, y2}, // 2
                                        new int[]{x2, y1}, // 3
                                        new int[]{x1, ym}, // 4
                                        new int[]{x2, ym}, // 5
                                        new int[]{xm, y1}, // 6
                                        new int[]{xm, y2}, // 7
                                        new int[]{xm, y2 + 20} // 8
            };
            //y
            //|      8
            //|      | 
            //|--2---7---1--
            //|--4-------5--
            //|--0---6---3--
            //O---------------------x
            for (int i = 0; i < 9; i++)
            {
                if (x >= cp[i][0] - 5 && x <= cp[i][0] + 5 && y >= cp[i][1] - 5 && y <= cp[i][1] + 5)
                    return i; // Return the index of the control point selected           
            }
            return -1;
        }
        // Scale the shape
        public override void dragControlPoint(int CPid, Point s, Point e)
        {
            // Translation vector
            int vx = e.X - s.X,
                vy = e.Y - s.Y;
            // If the selected control point is rotate point
            if (CPid == 8)
            {
                // Center
                int cx = (p1.X + p2.X) / 2, cy = (p1.Y + p2.Y) / 2;
                Point v1 = new Point(s.X - cx, s.Y - cy), v2 = new Point(e.X - cx, e.Y - cy);
                // Rotate angle
                double alpha = Math.Acos((v1.X * v2.X + v1.Y * v2.Y) / (Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y) * Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y))) / Math.PI * 180.0;
                if (v1.X * v2.Y - v2.X * v1.Y < 0) alpha *= -1;
                Angle = alpha;
                return;
            }
            // Height and Width of the shape
            int h = p2.Y - p1.Y,
                w = p2.X - p1.X;
            int x1 = p1.X, y1 = p1.Y, x2 = p2.X, y2 = p2.Y;
            Point pu = new Point(), pv = new Point();
            pu.setPoint(p1); pv.setPoint(p2);
            if (CPid == 1 || CPid == 5 || CPid == 3) // If the selected control point is on the right side
            {
                if (-vx >= w)
                    vx = 1 - w;
            }

            else if (CPid == 2 || CPid == 4 || CPid == 0) // If the selected control point is on the left side
            {
                if (vx >= w)
                    vx = w - 1;
            }

            if (CPid == 2 || CPid == 7 || CPid == 1) // If the selected control point is on the top
            {
                if (-vy >= h)
                    vy = 1 - h;
            }
            else if (CPid == 0 || CPid == 6 || CPid == 3) // If the selected control point is on the bottom
            {
                if (vy >= h)
                    vy = h - 1;
            }
            // Scale the control points
            switch (CPid)
            {
                case 0:
                    pu.setPoint(x1 + vx, y1 + vy);
                    break;
                case 1:
                    pv.setPoint(x2 + vx, y2 + vy);
                    break;
                case 2:
                    pu.setPoint(x1 + vx, y1);
                    pv.setPoint(x2, y2 + vy);
                    break;
                case 3:
                    pu.setPoint(x1, y1 + vy);
                    pv.setPoint(x2 + vx, y2);
                    break;
                case 4:
                    pu.setPoint(x1 + vx, y1);
                    break;
                case 5:
                    pv.setPoint(x2 + vx, y2);
                    break;
                case 6:
                    pu.setPoint(x1, y1 + vy);
                    break;
                case 7:
                    pv.setPoint(x2, y2 + vy);
                    break;
            }
            p1.setPoint(pu);
            p2.setPoint(pv);
        }
        // Translation
        public override void translate(Point s, Point e)
        {
            // Translation vector
            int vx = e.X - s.X,
                vy = e.Y - s.Y;
            // Translation the control point
            p1.X += vx;
            p1.Y += vy;
            p2.X += vx;
            p2.Y += vy;
        }
    }
}

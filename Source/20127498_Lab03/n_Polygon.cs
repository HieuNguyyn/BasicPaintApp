using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;

namespace _20127498_Lab01
{
    // Because n_Polygon is Polygon with n vertices so class n_Polygon inherits class Polygon
    class n_Polygon : Polygon
    {
        // List of vertices
        List<Point> vertexes = new List<Point>();
        // Add a vertice
        public void addVertex(Point p)
        {
            vertexes.Add(p);
            nPoly++;
        }
        // Drag and drop the mouse to set the vertice of the polygon
        public void moveVertex(Point p)
        {
            if (nPoly > 0)
                vertexes[nPoly - 1].setPoint(p);
        }
        // Draw the polygon
        public override void Draw(OpenGL gl)
        {
            if (nPoly <= 1) return;
            Line li = new Line();
            li.LineColor = LineColor;
            li.LineWidth = LineWidth;
            // Draw edges by connecting the vertices
            Point start = new Point(), end = new Point();
            start.setPoint(vertexes[nPoly - 1]);
            for (int i = 0; i < nPoly; i++)
            {
                end.setPoint(vertexes[i]);
                li.set(start, end);
                li.Draw(gl);
                start.setPoint(end);
            }
        }
        // Return a polygon
        public Polygon getPolygon()
        {
            nPoly--;
            if (nPoly < 2) return null;
            Polygon p = new Polygon();
            p.nPoly = nPoly;
            p.nPoints = new Point[nPoly];
            p.LineColor = LineColor;
            p.LineWidth = LineWidth;
            p.FillColor = FillColor;
            // Find x_min, y_min, x_max, _max 
            int x1 = vertexes[0].X, x2 = vertexes[0].X, y1 = vertexes[0].Y, y2 = vertexes[0].Y;
            for (int i = 1; i < nPoly; i++)
            {
                if (vertexes[i].X < x1) x1 = vertexes[i].X;
                if (vertexes[i].X > x2) x2 = vertexes[i].X;

                if (vertexes[i].Y < y1) y1 = vertexes[i].Y;
                if (vertexes[i].Y > y2) y2 = vertexes[i].Y;
            }
            p.set(new Point(x1, y1), new Point(x2, y2));
            int xc = (x1 + x2) / 2,
                yc = (y1 + y2) / 2;
            // Coordinate of n vertices of polygon
            for (int i = 0; i < nPoly; i++)
            {
                p.nPoints[i] = new Point(vertexes[i].X - xc, vertexes[i].Y - yc);
            }
            return p;
        }
    }
}

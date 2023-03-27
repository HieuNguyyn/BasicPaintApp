using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL;

namespace _20127498_Lab01
{
    class ScanFill
    {
        private List<Point> ListOfIntersectPoints; // List of intersection between scan line and egdes
        private List<Line> ListOfEdges; // List of edges
        private List<Point> polygon; // List of points
        private int point_ymin; // Start point of the scan line fill
        private int point_ymax; // End point of the scan line fill
        // Fill the polygon
        public void setFill(List<Point> po)
        {
            this.polygon = po;
            ListOfIntersectPoints = new List<Point>();
            ListOfEdges = new List<Line>();
            point_ymin = 2000;
            point_ymax = 0;
        }
        // Having a intersecsion between scan line y and edge x will return true, otherwise return false
        public bool findIntersectGLPoint(int x1, int y1, int x2, int y2, int y, ref int x) //Tìm giao điểm của dòng quét y và cạnh
        {
            if (y2 == y1)
                return false;
            x = (x2 - x1) * (y - y1) / (y2 - y1) + x1;
            bool isInsideEdgeX;
            bool isInsideEdgeY;
            // x is between x1 and x2 is returning true, otherwise returning false
            if (x1 < x2)
                isInsideEdgeX = (x1 <= x) && (x <= x2);
            else
                isInsideEdgeX = (x2 <= x) && (x <= x1);
            // y is between y1 and y2 is returning true, otherwise returning false
            if (y1 < y2)
                isInsideEdgeY = (y1 <= y) && (y <= y2);
            else
                isInsideEdgeY = (y2 <= y) && (y <= y1);
            return isInsideEdgeX && isInsideEdgeY;
        }
        // Initialize a list of edges
        public void initEdges()
        {
            if (polygon.Count() > 2)
            {
                for (int a = 1; a < polygon.Count(); a++) 
                {
                    // Find the point_ymin and point_ymax
                    if (polygon[a - 1].getY() < point_ymin)
                        point_ymin = polygon[a - 1].getY();
                    if (polygon[a - 1].getY() > point_ymax)
                        point_ymax = polygon[a - 1].getY();
                    // Create a line connect 2 point a and a-1
                    Line current = new Line(polygon[a - 1], polygon[a]);
                    // Add the line to the list
                    ListOfEdges.Add(current);
                }
                int i = polygon.Count() - 1;
                // Find the point_ymax and point _ymin again
                if (polygon[i].getY() > point_ymax)
                    point_ymax = polygon[i].getY();
                if (polygon[i].getY() < point_ymin)
                    point_ymin = polygon[i].getY();
                // Create a line connect 2 point is first vertice and last vertice
                Line last = new Line(polygon[i], polygon[0]);
                // Add the line to the list
                ListOfEdges.Add(last);
            }
        }
        // Scan Line Fill
        public void scanlineFill(OpenGL gl)
        {
            int edgesSize = ListOfEdges.Count();
            for (int i = point_ymin; i <= point_ymax; i++) // Travel all the scan line
            {
                int intersectX = 0;
                for (int j = 0; j < edgesSize; j++) // Travel all the edges of the polygon
                {
                    // Find the intersection of scan line i and edge j
                    if (findIntersectGLPoint(ListOfEdges[j].getP1().getX(), ListOfEdges[j].getP1().getY(), ListOfEdges[j].getP2().getX(), ListOfEdges[j].getP2().getY(), i, ref intersectX))
                    {
                        // Create a intersection
                        Point p = new Point(intersectX, i);
                        if (ListOfEdges[j].getP1().getY() > ListOfEdges[j].getP2().getY())
                        {
                            // Find the bigger y
                            if (p.getY() == ListOfEdges[j].getP1().getY())
                                continue;
                        }
                        else
                        {
                            // Find the bigger y
                            if (ListOfEdges[j].getP1().getY() < ListOfEdges[j].getP2().getY())
                            {
                                if (p.getY() == ListOfEdges[j].getP2().getY())
                                    continue;
                            }
                        }
                        // Add the intersection to the list
                        ListOfIntersectPoints.Add(p);
                    }
                }
                int intersectSize = ListOfIntersectPoints.Count();
                Point swap = new Point(0, 0);
                // Sort the x_intersec
                for (int a = 0; a < intersectSize - 1; a++)
                {
                    for (int j = i + 1; j < intersectSize; j++)
                    {
                        if (ListOfIntersectPoints[a].getX() > ListOfIntersectPoints[a].getX())
                        {
                            swap = ListOfIntersectPoints[a];
                            ListOfIntersectPoints[a] = ListOfIntersectPoints[j];
                            ListOfIntersectPoints[j] = swap;
                        }
                    }
                }
                int intersectPointsSize = ListOfIntersectPoints.Count();
                // Fill
                for (int j = 1; j < intersectPointsSize; j += 2) 
                {
                    gl.Begin(OpenGL.GL_LINES);
                    gl.LineWidth(1);
                    gl.Vertex2sv(new short[] { (short)(ListOfIntersectPoints[j - 1].getX()), (short)ListOfIntersectPoints[j - 1].getY() });
                    gl.Vertex2sv(new short[] { (short)(ListOfIntersectPoints[j].getX()), (short)ListOfIntersectPoints[j].getY() });
                    gl.End();
                }
                ListOfIntersectPoints.Clear();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;

namespace _20127498_Lab01
{
    public partial class Form1 : Form
    {
        OpenGL gl;
        List<Object> shapes = new List<Object>(); // List of shapes
        int n_shapes = 0; // Number of shapes        
        Object currentShape; // Current shape
        private int Selected = -1;  // Shape is selected or not
        int objectId = -1;  // The shape is chosen
        int chosenControlPointId = -1;  // The control point is chosen
        enum Mode { Line, Circle, Rectangle, Ellipse, Triangle, Pentagon, Hexagon, Polygon, Select, Clear }; //Mode
        Mode currentMode = Mode.Line;   // Current Mode
        Color currentLineColor = new Color();   // Current Line Color
        Color currentFillColor = new Color(1, 1, 1);   // Current Color of the Shape
        bool currentModeFill = false; // Current Mode Filling, true is Flood Fill and false is Scan Line Fill
        bool isDrawing = false; // Drawing or not  
        Point pStart = new Point(); // Start point when click mouse
        Point pEnd = new Point(); // End point when drag and drop mouse      
        int timeDrawing = 0;    // Time to draw
        OpenGLControl openGLControl;
        public Form1()
        {
            InitializeComponent();
        }
        // Render the shape
        private void renderShapes()
        {
            // Clear the color and depth buffer
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            foreach (Object s in shapes)
            {
                s.Draw(gl);
                s.Fill(gl, false); //Fill in Scan Line Mode
                s.Draw(gl);
            }
            gl.Flush(); // Execute a drawing immediately instead of waiting after a certain amount of time
        }
        // Click the Clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear the color and depth buffer
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            // Reset all
            List<Object> shape = new List<Object>();
            shapes = shape;
            n_shapes = 0;
            Selected = -1;
            objectId = -1;
            chosenControlPointId = -1;
            isDrawing = false;
            timeDrawing = 0;
            gl.Flush(); // Execute a drawing immediately instead of waiting after a certain amount of time
        }
        // Click the Line button
        private void btnLine_Click(object sender, EventArgs e)
        {
            btnLine.Enabled = false;
            btnCircle.Enabled = true;
            btnRectangle.Enabled = true;
            btnEllipse.Enabled = true;
            btnTriangle.Enabled = true;
            btnPentagon.Enabled = true;
            btnHexagon.Enabled = true;
            btnSelect.Enabled = true;
            currentMode = Mode.Line;
            button.Enabled = false;
        }
        // Click the Circle button
        private void btnCircle_Click(object sender, EventArgs e)
        {
            btnLine.Enabled = true;
            btnCircle.Enabled = false;
            btnRectangle.Enabled = true;
            btnEllipse.Enabled = true;
            btnTriangle.Enabled = true;
            btnPentagon.Enabled = true;
            btnHexagon.Enabled = true;
            btnSelect.Enabled = true;
            currentMode = Mode.Circle;
            button.Enabled = false;
        }
        // Click the Rectangle button
        private void btnRectangle_Click(object sender, EventArgs e)
        {
            btnLine.Enabled = true;
            btnCircle.Enabled = true;
            btnRectangle.Enabled = false;
            btnEllipse.Enabled = true;
            btnTriangle.Enabled = true;
            btnPentagon.Enabled = true;
            btnHexagon.Enabled = true;
            btnSelect.Enabled = true;
            currentMode = Mode.Rectangle;
            button.Enabled = false;
        }
        // Click the Ellipse button
        private void btnEllipse_Click(object sender, EventArgs e)
        {
            btnLine.Enabled = true;
            btnCircle.Enabled = true;
            btnRectangle.Enabled = true;
            btnEllipse.Enabled = false;
            btnTriangle.Enabled = true;
            btnPentagon.Enabled = true;
            btnHexagon.Enabled = true;
            btnSelect.Enabled = true;
            currentMode = Mode.Ellipse;
            button.Enabled = false;
        }
        // Click the Triangle button
        private void btnTriangle_Click(object sender, EventArgs e)
        {
            btnLine.Enabled = true;
            btnCircle.Enabled = true;
            btnRectangle.Enabled = true;
            btnEllipse.Enabled = true;
            btnTriangle.Enabled = false;
            btnPentagon.Enabled = true;
            btnHexagon.Enabled = true;
            btnSelect.Enabled = true;
            currentMode = Mode.Triangle;
            button.Enabled = false;
        }
        // Click the Pentagon button
        private void btnPentagon_Click(object sender, EventArgs e)
        {
            btnLine.Enabled = true;
            btnCircle.Enabled = true;
            btnRectangle.Enabled = true;
            btnEllipse.Enabled = true;
            btnTriangle.Enabled = true;
            btnPentagon.Enabled = false;
            btnHexagon.Enabled = true;
            btnSelect.Enabled = true;
            currentMode = Mode.Pentagon;
            button.Enabled = false;
        }
        // Click the Hexagon button
        private void BtnHexagon_Click(object sender, EventArgs e)
        {
            btnLine.Enabled = true;
            btnCircle.Enabled = true;
            btnRectangle.Enabled = true;
            btnEllipse.Enabled = true;
            btnTriangle.Enabled = true;
            btnPentagon.Enabled = true;
            btnHexagon.Enabled = false;
            btnSelect.Enabled = true;
            currentMode = Mode.Hexagon;
            button.Enabled = false;
        }
        // When click the mouse in the openGLControl area
        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            pStart.setPoint(e.Location.X, openGLControl.Height - e.Location.Y);
            // Draw the polygon if mode polygon is selected
            if (currentMode == Mode.Polygon)
            {
                if (!isDrawing)
                {
                    Selected = -1;
                    renderShapes();
                    currentShape = new n_Polygon();
                    currentShape.LineColor = currentLineColor;
                    currentShape.FillColor = currentFillColor;
                    currentShape.LineWidth = (int)lst_Width.Value;
                    currentShape.FillColor = currentFillColor;
                    isDrawing = true;
                    timer_Drawing.Start();
                    timeDrawing = 0;

                }
                return;
            }
            isDrawing = true;
            // Mode Select is selected
            if (currentMode == Mode.Select)
            {
                int x = pStart.X, y = pStart.Y;
                // Determine drag the selected control point or not
                if (objectId >= 0) 
                {
                    chosenControlPointId = shapes[objectId].getControlPointId(x, y);
                    if (chosenControlPointId >= 0)
                    {
                        return;
                    }
                }
                // Determine the selected shape
                objectId = -1;
                // Check if the shape is inside the box of control points
                for (int i = n_shapes - 1; i >= 0; i--)
                    if (shapes[i].isInsideBox(x, y))
                    {
                        objectId = i;
                        break;
                    }
                renderShapes();
                // Draw the control points box of this shape
                if (objectId >= 0)
                {
                    shapes[objectId].drawControlBox(gl);
                }
                return;
            }
            timer_Drawing.Start();
            timeDrawing = 0;
            switch (currentMode)
            {
                case Mode.Line:
                    currentShape = new Line();
                    break;
                case Mode.Triangle:
                    currentShape = new Triangle();
                    break;
                case Mode.Rectangle:
                    currentShape = new Rectangle();
                    break;
                case Mode.Circle:
                    currentShape = new Circle();
                    break;
                case Mode.Ellipse:
                    currentShape = new Ellipse();
                    break;
                case Mode.Pentagon:
                    currentShape = new Pentagon();
                    break;
                case Mode.Hexagon:
                    currentShape = new Hexagon();
                    break;
            }
            currentShape.LineColor = currentLineColor;
            currentShape.LineWidth = (int)lst_Width.Value;
            currentShape.FillColor = currentFillColor;
        }
        // Move the mouse to resize object and draw Polygon
        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;
            pEnd.setPoint(e.Location.X, openGLControl.Height - e.Location.Y); // Update the end point when moving the mouse
            // If mode Polygon is selected
            if (currentMode == Mode.Polygon)
            {
                ((n_Polygon)currentShape).moveVertex(pEnd);
                renderShapes();
                currentShape.Draw(gl);
            }
            // If mode Select is selected
            else if (currentMode == Mode.Select)
            {
                if (objectId >= 0)
                {
                    if (chosenControlPointId >= 0)
                        shapes[objectId].dragControlPoint(chosenControlPointId, pStart, pEnd); // Scale the shape 
                    else shapes[objectId].translate(pStart, pEnd); // Translate the shape
                    if (chosenControlPointId != 8)
                        pStart.setPoint(pEnd);
                    renderShapes();
                    shapes[objectId].drawControlBox(gl);
                }
            }
            // The other mode
            else
            {
                currentShape.set(pStart, pEnd);
                renderShapes();
                currentShape.Draw(gl);
                gl.Flush();
            }
        }
        // When drag the mouse in the openGLControl area
        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            // If mode Polygon is selected
            if (currentMode == Mode.Polygon)
            {
                if (isDrawing)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Right) // If you do a right click
                    {
                        // Stop to draw Polygon
                        shapes.Add(((n_Polygon)currentShape).getPolygon());
                        n_shapes++;
                        isDrawing = false;
                        timer_Drawing.Stop();
                        renderShapes();
                    }
                    else
                    {
                        // Continuing to draw the Polygon
                        if (((n_Polygon)currentShape).nPoly == 0)
                        {
                            ((n_Polygon)currentShape).addVertex(new Point(e.Location.X, openGLControl.Height - e.Location.Y));
                        }
                        ((n_Polygon)currentShape).addVertex(new Point(e.Location.X, openGLControl.Height - e.Location.Y));
                        currentShape.Draw(gl);
                    }
                }
                return;
            }
            isDrawing = false;
            // If mode Select is selected
            if (currentMode == Mode.Select)
            {
                // If still control point is selected
                if (chosenControlPointId >= 0)
                {
                    // Draw a control points box
                    renderShapes();
                    shapes[objectId].drawControlBox(gl);
                    chosenControlPointId = -1;
                }
            }
            else
            {
                // Stop timer
                timer_Drawing.Stop();
                shapes.Add(currentShape);
                n_shapes++;
            }
        }
        // Time Drawing Session
        private void timer_Drawing_Tick(object sender, EventArgs e)
        {
            timeDrawing++;
            int min, sec, mil;
            mil = timeDrawing % 10;
            sec = (timeDrawing / 10) % 60;
            min = timeDrawing / 600;
            lb_Time.Text = min.ToString() + ":" + (sec < 10 ? "0" : "") + sec.ToString() + "." + mil.ToString();
        }
        // Color Dialog for Line Color
        // Use guide: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.colordialog?redirectedfrom=MSDN&view=windowsdesktop-7.0
        private void bt_LineColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentLineColor = new Color(colorDialog.Color.R / 255.0f, colorDialog.Color.G / 255.0f, colorDialog.Color.B / 255.0f);
                bt_LineColor.BackColor = colorDialog.Color; // Save the user-choose color
            }
        }

        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            // Get the OpenGL object
            gl = openGLControl.OpenGL;
            // Set the projection matrix
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Load the identity
            gl.LoadIdentity();
        }
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            // Set the projection matrix
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Load the identity
            gl.LoadIdentity();
            // Create a perspective transformation
            gl.Viewport(0, 0, openGLControl.Width, openGLControl.Height);
            gl.Ortho2D(0, openGLControl.Width, 0, openGLControl.Height);
        }

        private void lst_Width_ValueChanged(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void openGLControl_Load(object sender, EventArgs e)
        {
            gl.ClearColor(1f, 1f, 1f, 1f);
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lb_Time_Click(object sender, EventArgs e)
        {

        }

        private void btnPolygon_Click(object sender, EventArgs e)
        {
            btnLine.Enabled = true;
            btnCircle.Enabled = true;
            btnRectangle.Enabled = true;
            btnEllipse.Enabled = true;
            btnTriangle.Enabled = true;
            btnPentagon.Enabled = true;
            btnHexagon.Enabled = true;
            btnSelect.Enabled = true;
            currentMode = Mode.Polygon;
            button.Enabled = false;
        }
        // Click the Select button
        private void btnSelect_Click(object sender, EventArgs e)
        {
            btnLine.Enabled = true;
            btnCircle.Enabled = true;
            btnRectangle.Enabled = true;
            btnEllipse.Enabled = true;
            btnTriangle.Enabled = true;
            btnPentagon.Enabled = true;
            btnHexagon.Enabled = true;
            btnSelect.Enabled = false;
            currentMode = Mode.Select;
            button.Enabled = true;
        }
        // Click the Fill button
        private void btnFill_Click(object sender, EventArgs e)
        {
            currentModeFill = true;

            if (currentMode == Mode.Select && objectId >= 0)
            {
                shapes[objectId].FillColor = currentFillColor;
                renderShapes();                
            }
        }
        //Color Dialog for Fill Color
        private void btnFillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentFillColor = new Color(colorDialog.Color.R / 255.0f, colorDialog.Color.G / 255.0f, colorDialog.Color.B / 255.0f);
                btnFillColor.BackColor = colorDialog.Color; // Save the user-choose color
            }
        }
    }
}

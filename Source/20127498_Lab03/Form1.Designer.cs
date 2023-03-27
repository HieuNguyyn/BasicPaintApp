
namespace _20127498_Lab01
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openGLControl = new SharpGL.OpenGLControl();
            this.lb_LineColor = new System.Windows.Forms.Label();
            this.bt_LineColor = new System.Windows.Forms.Button();
            this.lb_LineSize = new System.Windows.Forms.Label();
            this.lst_Width = new System.Windows.Forms.NumericUpDown();
            this.lb_Time = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.timer_Drawing = new System.Windows.Forms.Timer(this.components);
            this.button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPolygon = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnPentagon = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.btnHexagon = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_ColorFill = new System.Windows.Forms.Label();
            this.btnFillColor = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.lb_TimeDrawing = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_Width)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.openGLControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.openGLControl.Cursor = System.Windows.Forms.Cursors.Cross;
            this.openGLControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Location = new System.Drawing.Point(0, 0);
            this.openGLControl.Margin = new System.Windows.Forms.Padding(5);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(1041, 635);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.Load += new System.EventHandler(this.openGLControl_Load);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            // 
            // lb_LineColor
            // 
            this.lb_LineColor.AutoSize = true;
            this.lb_LineColor.Location = new System.Drawing.Point(13, 9);
            this.lb_LineColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_LineColor.Name = "lb_LineColor";
            this.lb_LineColor.Size = new System.Drawing.Size(72, 17);
            this.lb_LineColor.TabIndex = 17;
            this.lb_LineColor.Text = "Line Color";
            // 
            // bt_LineColor
            // 
            this.bt_LineColor.BackColor = System.Drawing.SystemColors.ControlText;
            this.bt_LineColor.Location = new System.Drawing.Point(11, 30);
            this.bt_LineColor.Margin = new System.Windows.Forms.Padding(4);
            this.bt_LineColor.Name = "bt_LineColor";
            this.bt_LineColor.Size = new System.Drawing.Size(115, 22);
            this.bt_LineColor.TabIndex = 18;
            this.bt_LineColor.UseVisualStyleBackColor = false;
            this.bt_LineColor.Click += new System.EventHandler(this.bt_LineColor_Click);
            // 
            // lb_LineSize
            // 
            this.lb_LineSize.AutoSize = true;
            this.lb_LineSize.Location = new System.Drawing.Point(167, 9);
            this.lb_LineSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_LineSize.Name = "lb_LineSize";
            this.lb_LineSize.Size = new System.Drawing.Size(66, 17);
            this.lb_LineSize.TabIndex = 19;
            this.lb_LineSize.Text = "Line Size";
            this.lb_LineSize.Click += new System.EventHandler(this.label2_Click);
            // 
            // lst_Width
            // 
            this.lst_Width.Location = new System.Drawing.Point(170, 31);
            this.lst_Width.Margin = new System.Windows.Forms.Padding(4);
            this.lst_Width.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.lst_Width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lst_Width.Name = "lst_Width";
            this.lst_Width.Size = new System.Drawing.Size(115, 22);
            this.lst_Width.TabIndex = 20;
            this.lst_Width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lst_Width.ValueChanged += new System.EventHandler(this.lst_Width_ValueChanged);
            // 
            // lb_Time
            // 
            this.lb_Time.AutoSize = true;
            this.lb_Time.Location = new System.Drawing.Point(961, 25);
            this.lb_Time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Time.Name = "lb_Time";
            this.lb_Time.Size = new System.Drawing.Size(48, 17);
            this.lb_Time.TabIndex = 21;
            this.lb_Time.Text = "0:00.0";
            this.lb_Time.Click += new System.EventHandler(this.lb_Time_Click);
            // 
            // timer_Drawing
            // 
            this.timer_Drawing.Tick += new System.EventHandler(this.timer_Drawing_Tick);
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(0, 0);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.btnPolygon);
            this.panel1.Controls.Add(this.btnLine);
            this.panel1.Controls.Add(this.btnCircle);
            this.panel1.Controls.Add(this.btnPentagon);
            this.panel1.Controls.Add(this.btnTriangle);
            this.panel1.Controls.Add(this.btnHexagon);
            this.panel1.Controls.Add(this.btnRectangle);
            this.panel1.Controls.Add(this.btnEllipse);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1041, 151);
            this.panel1.TabIndex = 22;
            // 
            // btnPolygon
            // 
            this.btnPolygon.BackColor = System.Drawing.SystemColors.Control;
            this.btnPolygon.Image = global::_20127498_Lab01.Properties.Resources.icons8_polygon_30;
            this.btnPolygon.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPolygon.Location = new System.Drawing.Point(769, 42);
            this.btnPolygon.Margin = new System.Windows.Forms.Padding(4);
            this.btnPolygon.Name = "btnPolygon";
            this.btnPolygon.Size = new System.Drawing.Size(100, 70);
            this.btnPolygon.TabIndex = 17;
            this.btnPolygon.Text = "Polygon";
            this.btnPolygon.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPolygon.UseVisualStyleBackColor = false;
            this.btnPolygon.Click += new System.EventHandler(this.btnPolygon_Click);
            // 
            // btnLine
            // 
            this.btnLine.BackColor = System.Drawing.SystemColors.Control;
            this.btnLine.Enabled = false;
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLine.Location = new System.Drawing.Point(13, 42);
            this.btnLine.Margin = new System.Windows.Forms.Padding(4);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(100, 70);
            this.btnLine.TabIndex = 9;
            this.btnLine.Text = "Line";
            this.btnLine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLine.UseVisualStyleBackColor = false;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.BackColor = System.Drawing.SystemColors.Control;
            this.btnCircle.Image = ((System.Drawing.Image)(resources.GetObject("btnCircle.Image")));
            this.btnCircle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCircle.Location = new System.Drawing.Point(121, 42);
            this.btnCircle.Margin = new System.Windows.Forms.Padding(4);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(100, 70);
            this.btnCircle.TabIndex = 13;
            this.btnCircle.Text = "Circle";
            this.btnCircle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCircle.UseVisualStyleBackColor = false;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnPentagon
            // 
            this.btnPentagon.BackColor = System.Drawing.SystemColors.Control;
            this.btnPentagon.Image = ((System.Drawing.Image)(resources.GetObject("btnPentagon.Image")));
            this.btnPentagon.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPentagon.Location = new System.Drawing.Point(553, 42);
            this.btnPentagon.Margin = new System.Windows.Forms.Padding(4);
            this.btnPentagon.Name = "btnPentagon";
            this.btnPentagon.Size = new System.Drawing.Size(100, 70);
            this.btnPentagon.TabIndex = 11;
            this.btnPentagon.Text = "Pentagon";
            this.btnPentagon.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPentagon.UseVisualStyleBackColor = false;
            this.btnPentagon.Click += new System.EventHandler(this.btnPentagon_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.BackColor = System.Drawing.SystemColors.Control;
            this.btnTriangle.Image = ((System.Drawing.Image)(resources.GetObject("btnTriangle.Image")));
            this.btnTriangle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTriangle.Location = new System.Drawing.Point(445, 42);
            this.btnTriangle.Margin = new System.Windows.Forms.Padding(4);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(100, 70);
            this.btnTriangle.TabIndex = 8;
            this.btnTriangle.Text = "Triangle";
            this.btnTriangle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTriangle.UseVisualStyleBackColor = false;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // btnHexagon
            // 
            this.btnHexagon.BackColor = System.Drawing.SystemColors.Control;
            this.btnHexagon.Image = ((System.Drawing.Image)(resources.GetObject("btnHexagon.Image")));
            this.btnHexagon.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHexagon.Location = new System.Drawing.Point(661, 42);
            this.btnHexagon.Margin = new System.Windows.Forms.Padding(4);
            this.btnHexagon.Name = "btnHexagon";
            this.btnHexagon.Size = new System.Drawing.Size(100, 70);
            this.btnHexagon.TabIndex = 12;
            this.btnHexagon.Text = "Hexagon";
            this.btnHexagon.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHexagon.UseVisualStyleBackColor = false;
            this.btnHexagon.Click += new System.EventHandler(this.BtnHexagon_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.BackColor = System.Drawing.SystemColors.Control;
            this.btnRectangle.Image = ((System.Drawing.Image)(resources.GetObject("btnRectangle.Image")));
            this.btnRectangle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRectangle.Location = new System.Drawing.Point(229, 42);
            this.btnRectangle.Margin = new System.Windows.Forms.Padding(4);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(100, 70);
            this.btnRectangle.TabIndex = 10;
            this.btnRectangle.Text = "Rectangle";
            this.btnRectangle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRectangle.UseVisualStyleBackColor = false;
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.BackColor = System.Drawing.SystemColors.Control;
            this.btnEllipse.Image = ((System.Drawing.Image)(resources.GetObject("btnEllipse.Image")));
            this.btnEllipse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEllipse.Location = new System.Drawing.Point(337, 42);
            this.btnEllipse.Margin = new System.Windows.Forms.Padding(4);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(100, 70);
            this.btnEllipse.TabIndex = 14;
            this.btnEllipse.Text = "Ellipse";
            this.btnEllipse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEllipse.UseVisualStyleBackColor = false;
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.SystemColors.Control;
            this.btnSelect.Image = global::_20127498_Lab01.Properties.Resources.icons8_natural_user_interface_2_30;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelect.Location = new System.Drawing.Point(941, 0);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 70);
            this.btnSelect.TabIndex = 16;
            this.btnSelect.Text = "Select";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.Image = global::_20127498_Lab01.Properties.Resources.icons8_eraser_30;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClear.Location = new System.Drawing.Point(941, 78);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 70);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.lb_ColorFill);
            this.panel2.Controls.Add(this.btnFillColor);
            this.panel2.Controls.Add(this.btnFill);
            this.panel2.Controls.Add(this.lb_TimeDrawing);
            this.panel2.Controls.Add(this.bt_LineColor);
            this.panel2.Controls.Add(this.lb_LineColor);
            this.panel2.Controls.Add(this.lb_Time);
            this.panel2.Controls.Add(this.lst_Width);
            this.panel2.Controls.Add(this.lb_LineSize);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 574);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1041, 61);
            this.panel2.TabIndex = 23;
            // 
            // lb_ColorFill
            // 
            this.lb_ColorFill.AutoSize = true;
            this.lb_ColorFill.Location = new System.Drawing.Point(634, 9);
            this.lb_ColorFill.Name = "lb_ColorFill";
            this.lb_ColorFill.Size = new System.Drawing.Size(62, 17);
            this.lb_ColorFill.TabIndex = 27;
            this.lb_ColorFill.Text = "Color Fill";
            // 
            // btnFillColor
            // 
            this.btnFillColor.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFillColor.Location = new System.Drawing.Point(637, 31);
            this.btnFillColor.Name = "btnFillColor";
            this.btnFillColor.Size = new System.Drawing.Size(86, 25);
            this.btnFillColor.TabIndex = 26;
            this.btnFillColor.UseVisualStyleBackColor = false;
            this.btnFillColor.Click += new System.EventHandler(this.btnFillColor_Click);
            // 
            // btnFill
            // 
            this.btnFill.Image = global::_20127498_Lab01.Properties.Resources.icons8_paint_palette_30;
            this.btnFill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFill.Location = new System.Drawing.Point(742, 9);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(110, 46);
            this.btnFill.TabIndex = 25;
            this.btnFill.Text = "Fill Color";
            this.btnFill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // lb_TimeDrawing
            // 
            this.lb_TimeDrawing.AutoSize = true;
            this.lb_TimeDrawing.Location = new System.Drawing.Point(859, 25);
            this.lb_TimeDrawing.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_TimeDrawing.Name = "lb_TimeDrawing";
            this.lb_TimeDrawing.Size = new System.Drawing.Size(94, 17);
            this.lb_TimeDrawing.TabIndex = 22;
            this.lb_TimeDrawing.Text = "Time Drawing";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 635);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.openGLControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "20127498_Lab03";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_Width)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnPentagon;
        private System.Windows.Forms.Button btnHexagon;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lb_LineColor;
        private System.Windows.Forms.Button bt_LineColor;
        private System.Windows.Forms.Label lb_LineSize;
        private System.Windows.Forms.NumericUpDown lst_Width;
        private System.Windows.Forms.Label lb_Time;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Timer timer_Drawing;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_TimeDrawing;
        private System.Windows.Forms.Button btnPolygon;
        private System.Windows.Forms.Button btnFillColor;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Label lb_ColorFill;
    }
}


using System;
using System.Drawing;
using System.Windows.Forms;

namespace Painter
{
    public partial class FormOverlay : Form
    {

        public FormOverlay(FormMain fm1)
        {
            this.fm1 = fm1;
            InitializeComponent();
        }

        private void FormOverlay_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.AllowTransparency = false;
            this.BackColor = Color.AliceBlue;
            this.TransparencyKey = this.BackColor;
            WindowState = FormWindowState.Maximized;
        }

        FormMain fm1;
        bool bPaint = false;
        bool bFigure = false;
        Point MDown = new Point(0, 0);
        Point Start = new Point(0, 0);
        Point End = new Point(0, 0);
        public Color penColor { get; set; }


        private void FormOverlay_MouseMove(object sender, MouseEventArgs e)
        {
            if (bPaint)
            {
                Graphics g = CreateGraphics();

                Point MMove = new Point(0, 0);
                MMove.X = e.X; MMove.Y = e.Y;

                MDown = Drawing.Pen(MDown, MMove, g, penColor);
            }
        }

        private void FormOverlay_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            bPaint = false;

            if (bFigure)
            {
                Drawing.Figure(Start, End, g, fm1.GetNumeric(), penColor);
                Start.X = 0; Start.Y = 0;
                bFigure = false;
            }
        }

        private void FormOverlay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Start.X = 0; Start.Y = 0;
                Graphics g = CreateGraphics();
                g.Clear(this.BackColor);
                g.Dispose();
            }
        }

        private void FormOverlay_MouseDown(object sender, MouseEventArgs e)
        {
            if (fm1.checkBoxPen.Checked)
            {
                bPaint = true;
                MDown.X = e.X;
                MDown.Y = e.Y;
            }

            else if (fm1.checkBoxFig.Checked)
            {

                if (Start.X == 0 && Start.Y == 0)
                {
                    Start.X = e.X; Start.Y = e.Y;
                    bFigure = false;
                }

                else
                {
                    End.X = e.X; End.Y = e.Y;
                    bFigure = true;
                }
            }
        }
    }
}
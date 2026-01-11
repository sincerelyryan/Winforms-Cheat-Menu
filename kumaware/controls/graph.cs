using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class SinglePointCurveEditor : Control
{
    private const int DefaultPointRadius = 8;

    private PointF controlPoint = new PointF(0.5f, 0.5f);
    private int draggingPoint = -1;

    private int pointRadius = DefaultPointRadius;
    private float curveThickness = 2f;
    private int gridSpacing = 20;

    private Color gridColor = Color.FromArgb(60, 60, 60);
    private Color borderColor = Color.FromArgb(80, 80, 80);
    private Color curveColor = Color.FromArgb(150, 180, 230);
    private Color pointFillColor = Color.FromArgb(220, 220, 220);
    private Color pointBorderColor = Color.FromArgb(50, 50, 50);
    private Color curveBackground = Color.FromArgb(30, 30, 30);

    [Category("Behavior")]
    [Description("Normalized X value of the control point (0=left, 1=right)")]
    public float PointX
    {
        get { return controlPoint.X; }
        set
        {
            controlPoint.X = Math.Max(0f, Math.Min(1f, value));
            Invalidate();
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    [Category("Behavior")]
    [Description("Normalized Y value of the control point (0=top, 1=bottom)")]
    public float PointY
    {
        get { return controlPoint.Y; }
        set
        {
            controlPoint.Y = Math.Max(0f, Math.Min(1f, value));
            Invalidate();
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    [Category("Appearance")]
    [Description("Background color of the curve editor")]
    public Color CurveBackground
    {
        get { return curveBackground; }
        set { curveBackground = value; Invalidate(); }
    }

    [Category("Appearance")]
    [Description("Thickness of the curve line")]
    public float CurveThickness
    {
        get { return curveThickness; }
        set { curveThickness = Math.Max(0.5f, value); Invalidate(); }
    }

    [Category("Appearance")]
    [Description("Color of the curve line")]
    public Color CurveColor
    {
        get { return curveColor; }
        set { curveColor = value; Invalidate(); }
    }

    [Category("Appearance")]
    [Description("Color of the grid lines")]
    public Color GridColor
    {
        get { return gridColor; }
        set { gridColor = value; Invalidate(); }
    }

    [Category("Appearance")]
    [Description("Spacing between grid lines")]
    public int GridSpacing
    {
        get { return gridSpacing; }
        set { gridSpacing = Math.Max(5, value); Invalidate(); }
    }

    [Category("Appearance")]
    [Description("Color of the border around the control")]
    public Color BorderColor
    {
        get { return borderColor; }
        set { borderColor = value; Invalidate(); }
    }

    [Category("Appearance")]
    [Description("Fill color of the control point")]
    public Color PointFillColor
    {
        get { return pointFillColor; }
        set { pointFillColor = value; Invalidate(); }
    }

    [Category("Appearance")]
    [Description("Border color of the control point")]
    public Color PointBorderColor
    {
        get { return pointBorderColor; }
        set { pointBorderColor = value; Invalidate(); }
    }

    [Category("Appearance")]
    [Description("Radius of the control point")]
    public int PointRadius
    {
        get { return pointRadius; }
        set { pointRadius = Math.Max(2, value); Invalidate(); }
    }

    public event EventHandler ValueChanged;

    public SinglePointCurveEditor()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.UserPaint, true);
        Height = 200;
        Width = 200;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        using (SolidBrush brush = new SolidBrush(curveBackground))
        {
            g.FillRectangle(brush, ClientRectangle);
        }

        DrawGrid(g);
        DrawCurve(g);
        DrawPoint(g);
        DrawBorder(g);
    }

    private void DrawGrid(Graphics g)
    {
        using (Pen pen = new Pen(gridColor))
        {
            for (int x = 0; x <= Width; x += gridSpacing)
                g.DrawLine(pen, x, 0, x, Height);
            for (int y = 0; y <= Height; y += gridSpacing)
                g.DrawLine(pen, 0, y, Width, y);
        }
    }

    private void DrawCurve(Graphics g)
    {
        using (var pen = new Pen(curveColor, curveThickness))
        {
            PointF p0 = new PointF(0, Height); 
            PointF p1 = new PointF(controlPoint.X * Width, controlPoint.Y * Height);
            PointF p2 = new PointF(Width, 0); 
            g.DrawLines(pen, new[] { p0, p1, p2 });
        }
    }

    private void DrawPoint(Graphics g)
    {
        float px = controlPoint.X * Width;
        float py = controlPoint.Y * Height;
        RectangleF rect = new RectangleF(px - pointRadius, py - pointRadius, pointRadius * 2, pointRadius * 2);

        using (SolidBrush brush = new SolidBrush(pointFillColor))
        using (Pen pen = new Pen(pointBorderColor, 1))
        {
            g.FillEllipse(brush, rect);
            g.DrawEllipse(pen, rect);
        }
    }

    private void DrawBorder(Graphics g)
    {
        using (Pen pen = new Pen(borderColor))
        {
            g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        float px = controlPoint.X * Width;
        float py = controlPoint.Y * Height;
        RectangleF rect = new RectangleF(px - pointRadius, py - pointRadius, pointRadius * 2, pointRadius * 2);

        if (rect.Contains(e.Location))
        {
            draggingPoint = 0;
            Capture = true;
        }
        else
        {
            draggingPoint = -1;
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (draggingPoint != -1 && e.Button == MouseButtons.Left)
        {
            float x = Math.Max(0f, Math.Min(1f, e.X / (float)Width));
            float y = Math.Max(0f, Math.Min(1f, e.Y / (float)Height));

            controlPoint.X = x;
            controlPoint.Y = y;

            Invalidate();
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        draggingPoint = -1;
        Capture = false;
    }
}

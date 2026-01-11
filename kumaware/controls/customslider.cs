using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

[DefaultEvent("ValueChanged")]
[DefaultProperty("Value")]
public class customslider : Control
{
    private int minimum = 0;
    private int maximum = 50;
    private int value = 16;

    private Color backColorTop = Color.FromArgb(65, 65, 65);
    private Color backColorBottom = Color.FromArgb(45, 45, 45);

    private Color fillColorTop = Color.FromArgb(170, 200, 255);
    private Color fillColorBottom = Color.FromArgb(110, 150, 220);

    private string textFormat = "{0}/{1}";

    [Category("Behavior")]
    public int Minimum
    {
        get => minimum;
        set { minimum = value; if (this.value < minimum) this.value = minimum; Invalidate(); }
    }

    [Category("Behavior")]
    public int Maximum
    {
        get => maximum;
        set { maximum = value; if (this.value > maximum) this.value = maximum; Invalidate(); }
    }

    [Category("Behavior")]
    public int Value
    {
        get => value;
        set
        {
            int newValue = Math.Max(Minimum, Math.Min(Maximum, value));
            if (this.value != newValue)
            {
                this.value = newValue;
                Invalidate();
                ValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public event EventHandler ValueChanged;

    [Category("Appearance")]
    [Description("Background gradient top color")]
    public Color BarBackColorTop
    {
        get => backColorTop;
        set { backColorTop = value; Invalidate(); }
    }

    [Category("Appearance")]
    [Description("Background gradient bottom color")]
    public Color BarBackColorBottom
    {
        get => backColorBottom;
        set { backColorBottom = value; Invalidate(); }
    }

    [Category("Appearance")]
    [Description("Fill gradient top color")]
    public Color FillColorTop
    {
        get => fillColorTop;
        set { fillColorTop = value; Invalidate(); }
    }

    [Category("Appearance")]
    [Description("Fill gradient bottom color")]
    public Color FillColorBottom
    {
        get => fillColorBottom;
        set { fillColorBottom = value; Invalidate(); }
    }

    [Category("Appearance")]
    [Description("Text format ({0}=Value, {1}=Maximum)")]
    public string TextFormat
    {
        get => textFormat;
        set { textFormat = value; Invalidate(); }
    }

    public customslider()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.UserPaint, true);

        Height = 16;
        Font = new Font("Segoe UI", 9f, FontStyle.Bold);
        ForeColor = Color.White;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;

        float percent = (float)(Value - Minimum) / (Maximum - Minimum);
        int fillWidth = (int)(Width * percent);

        using (var bgBrush = new LinearGradientBrush(
            ClientRectangle,
            backColorTop,
            backColorBottom,
            LinearGradientMode.Vertical))
        {
            g.FillRectangle(bgBrush, ClientRectangle);
        }

        if (fillWidth > 0)
        {
            using (var fillBrush = new LinearGradientBrush(
                new Rectangle(0, 0, fillWidth, Height),
                fillColorTop,
                fillColorBottom,
                LinearGradientMode.Vertical))
            {
                g.FillRectangle(fillBrush, 0, 0, fillWidth, Height);
            }
        }

        string text = string.Format(TextFormat, Value, Maximum);
        SizeF size = g.MeasureString(text, Font);

        float x = (Width - size.Width) / 2;
        float y = (Height - size.Height) / 2;

        using (var tb = new SolidBrush(ForeColor))
            g.DrawString(text, Font, tb, x, y);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        UpdateValue(e.X);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            UpdateValue(e.X);
    }

    private void UpdateValue(int mouseX)
    {
        float percent = (float)mouseX / Width;
        percent = percent < 0f ? 0f : percent > 1f ? 1f : percent;

        Value = Minimum + (int)((Maximum - Minimum) * percent);
    }
}

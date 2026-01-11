using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Guna.UI2.WinForms;


namespace kumaware
{
    public partial class Form1 : Form
    {
        private bool bindwait = false;
        private Guna2GradientButton currentBindingButton;


        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            HookMouse(this);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cuiPanel3.Visible = true;
            cuiPanel4.Visible = false;
            timer1.Start();
        }

        private void siticoneGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (guna2GradientButton1.Checked == true)
            {
                cuiPanel3.Visible = true;
                cuiPanel5.Visible = false;
                cuiPanel4.Visible = false;
                cuiPanel6.Visible = false;
                cuiPanel3.BringToFront();
            }
            if (guna2GradientButton2.Checked == true)
            {
                cuiPanel3.Visible = false;
                cuiPanel5.Visible = false;
                cuiPanel4.Visible = true;
                cuiPanel6.Visible = false;
                cuiPanel4.BringToFront();
            }
            if (guna2GradientButton3.Checked == true)     
            {
                cuiPanel3.Visible = false;
                cuiPanel5.Visible = true;
                cuiPanel4.Visible = false;
                cuiPanel6.Visible = false;
                cuiPanel5.BringToFront();
            }
            if (guna2GradientButton4.Checked == true)
            {
                cuiPanel3.Visible = false;
                cuiPanel5.Visible = false;
                cuiPanel4.Visible = false;
                cuiPanel6.Visible = true;
                cuiPanel6.BringToFront();
            }
            timer1.Start();
        }

        private void cuiPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticonePictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void siticonePictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            bindwait = true;
            currentBindingButton = guna2GradientButton5;
            guna2GradientButton5.Text = "...";
            guna2GradientButton5.Focus();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            bindwait = true;
            currentBindingButton = guna2GradientButton6;
            guna2GradientButton6.Text = "...";
            guna2GradientButton6.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!bindwait)
                return base.ProcessCmdKey(ref msg, keyData);

            bindwait = false;

            Keys key = keyData & Keys.KeyCode;
            Keys mods = keyData & Keys.Modifiers;

            string text = "";

            if ((mods & Keys.Control) != 0) text += "Ctrl + ";
            if ((mods & Keys.Alt) != 0) text += "Alt + ";
            if ((mods & Keys.Shift) != 0) text += "Shift + ";

            text += NormalizeKey(key);

            currentBindingButton.Text = text;

            return true;
        }

        private string NormalizeKey(Keys key)
        {
            switch (key)
            {
                case Keys.Oemtilde: return "`";
                case Keys.OemMinus: return "-";
                case Keys.Oemplus: return "+";
                case Keys.OemOpenBrackets: return "[";
                case Keys.OemCloseBrackets: return "]";
                case Keys.OemPipe: return "\\";
                case Keys.OemSemicolon: return ";";
                case Keys.OemQuotes: return "'";
                case Keys.Oemcomma: return ",";
                case Keys.OemPeriod: return ".";
                case Keys.OemQuestion: return "/";
                case Keys.Return: return "Enter";
                case Keys.Escape: return "Esc";
                case Keys.Back: return "Backspace";
                case Keys.Space: return "Space";
                default: return key.ToString();
            }
        }

        private void HookMouse(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                c.MouseDown -= Form1_MouseDown;
                c.MouseDown += Form1_MouseDown;

                if (c.HasChildren)
                    HookMouse(c);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!bindwait)
                return;

            bindwait = false;

            string mouseName;

            switch (e.Button)
            {
                case MouseButtons.Left: mouseName = "M1"; break;
                case MouseButtons.Right: mouseName = "M2"; break;
                case MouseButtons.Middle: mouseName = "M3"; break;
                case MouseButtons.XButton1: mouseName = "M4"; break;
                case MouseButtons.XButton2: mouseName = "M5"; break;
                default: return;
            }

            currentBindingButton.Text = mouseName;
        }

        private void guna2GradientButton6_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void guna2GradientButton6_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {

        }
    }
}
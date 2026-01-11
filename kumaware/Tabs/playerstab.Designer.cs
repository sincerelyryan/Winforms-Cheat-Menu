namespace kumaware
{
    partial class playerstab
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Player1 | 100 HP | 100 S"}, -1, System.Drawing.Color.Silver, System.Drawing.Color.Empty, null);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Player2 | 100 HP | 100 S"}, -1, System.Drawing.Color.Silver, System.Drawing.Color.Empty, null);
            this.guna2Panel6 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel23 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.siticoneSeparator6 = new Siticone.Desktop.UI.WinForms.SiticoneSeparator();
            this.guna2Panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel6
            // 
            this.guna2Panel6.Controls.Add(this.guna2HtmlLabel23);
            this.guna2Panel6.Controls.Add(this.listView1);
            this.guna2Panel6.Controls.Add(this.siticoneSeparator6);
            this.guna2Panel6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(18)))), ((int)(((byte)(20)))));
            this.guna2Panel6.Location = new System.Drawing.Point(40, 64);
            this.guna2Panel6.Name = "guna2Panel6";
            this.guna2Panel6.Size = new System.Drawing.Size(431, 368);
            this.guna2Panel6.TabIndex = 5;
            // 
            // guna2HtmlLabel23
            // 
            this.guna2HtmlLabel23.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel23.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel23.ForeColor = System.Drawing.Color.Silver;
            this.guna2HtmlLabel23.Location = new System.Drawing.Point(5, 8);
            this.guna2HtmlLabel23.Name = "guna2HtmlLabel23";
            this.guna2HtmlLabel23.Size = new System.Drawing.Size(54, 15);
            this.guna2HtmlLabel23.TabIndex = 21;
            this.guna2HtmlLabel23.Text = "Player List";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(18)))), ((int)(((byte)(20)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView1.Location = new System.Drawing.Point(5, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(423, 338);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // siticoneSeparator6
            // 
            this.siticoneSeparator6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(190)))));
            this.siticoneSeparator6.Location = new System.Drawing.Point(-4, -1);
            this.siticoneSeparator6.Name = "siticoneSeparator6";
            this.siticoneSeparator6.Size = new System.Drawing.Size(435, 10);
            this.siticoneSeparator6.TabIndex = 1;
            // 
            // playerstab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 497);
            this.Controls.Add(this.guna2Panel6);
            this.Name = "playerstab";
            this.Text = "playesr";
            this.Load += new System.EventHandler(this.aimtab_Load);
            this.guna2Panel6.ResumeLayout(false);
            this.guna2Panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel23;
        private System.Windows.Forms.ListView listView1;
        private Siticone.Desktop.UI.WinForms.SiticoneSeparator siticoneSeparator6;
    }
}
namespace QLSach
{
    partial class Hyper
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
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Logoutt = new System.Windows.Forms.ToolStripMenuItem();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.S = new System.Windows.Forms.ToolStripMenuItem();
            this.Bill = new System.Windows.Forms.ToolStripMenuItem();
            this.NV = new System.Windows.Forms.ToolStripMenuItem();
            this.CategoryS = new System.Windows.Forms.ToolStripMenuItem();
            this.Provide = new System.Windows.Forms.ToolStripMenuItem();
            this.Exitt = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Logoutt});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // Logoutt
            // 
            this.Logoutt.Name = "Logoutt";
            this.Logoutt.Size = new System.Drawing.Size(224, 26);
            this.Logoutt.Text = "Đăng xuất";
            this.Logoutt.Click += new System.EventHandler(this.Logoutt_Click);
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.S,
            this.Bill,
            this.NV,
            this.CategoryS,
            this.Provide});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.chứcNăngToolStripMenuItem.Text = "Chức năng";
            // 
            // S
            // 
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(224, 26);
            this.S.Text = "Sách";
            this.S.Click += new System.EventHandler(this.S_Click);
            // 
            // Bill
            // 
            this.Bill.Name = "Bill";
            this.Bill.Size = new System.Drawing.Size(224, 26);
            this.Bill.Text = "Hóa đơn";
            this.Bill.Click += new System.EventHandler(this.Bill_Click);
            // 
            // NV
            // 
            this.NV.Name = "NV";
            this.NV.Size = new System.Drawing.Size(224, 26);
            this.NV.Text = "Nhân viên";
            this.NV.Click += new System.EventHandler(this.NV_Click);
            // 
            // CategoryS
            // 
            this.CategoryS.Name = "CategoryS";
            this.CategoryS.Size = new System.Drawing.Size(224, 26);
            this.CategoryS.Text = "Loại Sách";
            this.CategoryS.Click += new System.EventHandler(this.CategoryS_Click);
            // 
            // Provide
            // 
            this.Provide.Name = "Provide";
            this.Provide.Size = new System.Drawing.Size(224, 26);
            this.Provide.Text = "Nhà cung cấp";
            this.Provide.Click += new System.EventHandler(this.Provide_Click);
            // 
            // Exitt
            // 
            this.Exitt.Name = "Exitt";
            this.Exitt.Size = new System.Drawing.Size(143, 24);
            this.Exitt.Text = "Thoát";
            this.Exitt.Click += new System.EventHandler(this.Exitt_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.chứcNăngToolStripMenuItem,
            this.Exitt});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(156, 604);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // Hyper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 604);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "Hyper";
            this.Text = "Hyper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Hyper_FormClosed);
            this.Load += new System.EventHandler(this.Hyper_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Logoutt;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem S;
        private System.Windows.Forms.ToolStripMenuItem Bill;
        private System.Windows.Forms.ToolStripMenuItem NV;
        private System.Windows.Forms.ToolStripMenuItem CategoryS;
        private System.Windows.Forms.ToolStripMenuItem Provide;
        private System.Windows.Forms.ToolStripMenuItem Exitt;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}
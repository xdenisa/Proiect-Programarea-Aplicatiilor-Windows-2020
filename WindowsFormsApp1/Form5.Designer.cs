namespace WindowsFormsApp1
{
    partial class Form5
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bazaDeDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fisierTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portofoliuCurentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.uC_PAW1 = new WindowsFormsApp1.UC_PAW();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(0, 54);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(536, 244);
            this.listBox1.TabIndex = 3;
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bazaDeDateToolStripMenuItem,
            this.fisierTextToolStripMenuItem,
            this.portofoliuCurentToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bazaDeDateToolStripMenuItem
            // 
            this.bazaDeDateToolStripMenuItem.Name = "bazaDeDateToolStripMenuItem";
            this.bazaDeDateToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.bazaDeDateToolStripMenuItem.Text = "Baza de date";
            this.bazaDeDateToolStripMenuItem.Click += new System.EventHandler(this.bazaDeDateToolStripMenuItem_Click);
            // 
            // fisierTextToolStripMenuItem
            // 
            this.fisierTextToolStripMenuItem.Name = "fisierTextToolStripMenuItem";
            this.fisierTextToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.fisierTextToolStripMenuItem.Text = "Fisier text";
            this.fisierTextToolStripMenuItem.Click += new System.EventHandler(this.fisierTextToolStripMenuItem_Click);
            // 
            // portofoliuCurentToolStripMenuItem
            // 
            this.portofoliuCurentToolStripMenuItem.Name = "portofoliuCurentToolStripMenuItem";
            this.portofoliuCurentToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.portofoliuCurentToolStripMenuItem.Text = "Portofoliu curent";
            this.portofoliuCurentToolStripMenuItem.Click += new System.EventHandler(this.portofoliuCurentToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(41, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = " STERGE";
            this.label1.DragDrop += new System.Windows.Forms.DragEventHandler(this.label1_DragDrop);
            this.label1.DragEnter += new System.Windows.Forms.DragEventHandler(this.label1_DragEnter);
            // 
            // uC_PAW1
            // 
            this.uC_PAW1.Location = new System.Drawing.Point(0, 12);
            this.uC_PAW1.Name = "uC_PAW1";
            this.uC_PAW1.Size = new System.Drawing.Size(790, 374);
            this.uC_PAW1.TabIndex = 6;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.uC_PAW1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form5";
            this.Text = "Form5";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bazaDeDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fisierTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portofoliuCurentToolStripMenuItem;
        private UC_PAW uC_PAW1;
    }
}
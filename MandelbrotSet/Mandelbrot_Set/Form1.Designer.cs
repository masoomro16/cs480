namespace Mandelbrot_Set
{
    partial class Mandelbrot
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
            this.plotButton = new System.Windows.Forms.Button();
            this.mandelSet = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.zoomFactor = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mandelSet)).BeginInit();
            this.SuspendLayout();
            // 
            // plotButton
            // 
            this.plotButton.Location = new System.Drawing.Point(26, 177);
            this.plotButton.Name = "plotButton";
            this.plotButton.Size = new System.Drawing.Size(112, 25);
            this.plotButton.TabIndex = 0;
            this.plotButton.Text = "Plot Graph";
            this.plotButton.UseVisualStyleBackColor = true;
            this.plotButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // mandelSet
            // 
            this.mandelSet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mandelSet.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mandelSet.Location = new System.Drawing.Point(169, 12);
            this.mandelSet.Name = "mandelSet";
            this.mandelSet.Size = new System.Drawing.Size(603, 537);
            this.mandelSet.TabIndex = 1;
            this.mandelSet.TabStop = false;
            this.mandelSet.Click += new System.EventHandler(this.mandelSet_Click);
            this.mandelSet.Paint += new System.Windows.Forms.PaintEventHandler(this.mandelSet_Paint);
            this.mandelSet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mandelSet_MouseClick);
            this.mandelSet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mandelSet_MouseDown);
            this.mandelSet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mandelSet_MouseMove);
            this.mandelSet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mandelSet_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Zoom Factor";
            // 
            // zoomFactor
            // 
            this.zoomFactor.Location = new System.Drawing.Point(26, 111);
            this.zoomFactor.Name = "zoomFactor";
            this.zoomFactor.Size = new System.Drawing.Size(100, 20);
            this.zoomFactor.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Click and drag on area to zoom";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Mandelbrot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zoomFactor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mandelSet);
            this.Controls.Add(this.plotButton);
            this.Name = "Mandelbrot";
            this.Text = "Mandelbrot Set";
            ((System.ComponentModel.ISupportInitialize)(this.mandelSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button plotButton;
        private System.Windows.Forms.PictureBox mandelSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox zoomFactor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}


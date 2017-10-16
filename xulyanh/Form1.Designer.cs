namespace xylyanh
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.b1 = new System.Windows.Forms.Button();
            this.gradien = new System.Windows.Forms.Button();
            this.lap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tangsang1 = new System.Windows.Forms.Button();
            this.btw1 = new System.Windows.Forms.Button();
            this.btw2 = new System.Windows.Forms.Button();
            this.btw3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.w1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dentrag = new System.Windows.Forms.Button();
            this.tangsang2 = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(31, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 304);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox2.Location = new System.Drawing.Point(521, 64);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(313, 304);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // b1
            // 
            this.b1.Location = new System.Drawing.Point(10, 3);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(53, 28);
            this.b1.TabIndex = 2;
            this.b1.Text = "Open";
            this.b1.UseVisualStyleBackColor = true;
            this.b1.Click += new System.EventHandler(this.b1_Click);
            // 
            // gradien
            // 
            this.gradien.Location = new System.Drawing.Point(69, 3);
            this.gradien.Name = "gradien";
            this.gradien.Size = new System.Drawing.Size(62, 28);
            this.gradien.TabIndex = 3;
            this.gradien.Text = "Histogram";
            this.gradien.UseVisualStyleBackColor = true;
            this.gradien.Click += new System.EventHandler(this.b2_Click);
            // 
            // lap
            // 
            this.lap.Location = new System.Drawing.Point(132, 3);
            this.lap.Name = "lap";
            this.lap.Size = new System.Drawing.Size(53, 28);
            this.lap.TabIndex = 4;
            this.lap.Text = "Laplace";
            this.lap.UseVisualStyleBackColor = true;
            this.lap.Click += new System.EventHandler(this.b3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ảnh ban đầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(624, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ảnh kết quả";
            // 
            // tangsang1
            // 
            this.tangsang1.Location = new System.Drawing.Point(185, 3);
            this.tangsang1.Name = "tangsang1";
            this.tangsang1.Size = new System.Drawing.Size(100, 28);
            this.tangsang1.TabIndex = 15;
            this.tangsang1.Text = "Tăng độ sáng";
            this.tangsang1.UseVisualStyleBackColor = true;
            this.tangsang1.Click += new System.EventHandler(this.button4_Click);
            // 
            // btw1
            // 
            this.btw1.Location = new System.Drawing.Point(505, 6);
            this.btw1.Name = "btw1";
            this.btw1.Size = new System.Drawing.Size(75, 23);
            this.btw1.TabIndex = 5;
            this.btw1.Text = "W1";
            this.btw1.UseVisualStyleBackColor = true;
            this.btw1.Click += new System.EventHandler(this.btReadFile_Click);
            // 
            // btw2
            // 
            this.btw2.Location = new System.Drawing.Point(585, 6);
            this.btw2.Name = "btw2";
            this.btw2.Size = new System.Drawing.Size(75, 23);
            this.btw2.TabIndex = 10;
            this.btw2.Text = "W2";
            this.btw2.UseVisualStyleBackColor = true;
            this.btw2.Click += new System.EventHandler(this.button1_Click);
            // 
            // btw3
            // 
            this.btw3.Location = new System.Drawing.Point(665, 6);
            this.btw3.Name = "btw3";
            this.btw3.Size = new System.Drawing.Size(75, 23);
            this.btw3.TabIndex = 14;
            this.btw3.Text = "W3";
            this.btw3.UseVisualStyleBackColor = true;
            this.btw3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(619, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 27);
            this.button2.TabIndex = 13;
            this.button2.Text = "Tách thủy vân";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // w1
            // 
            this.w1.Location = new System.Drawing.Point(36, 462);
            this.w1.Name = "w1";
            this.w1.Size = new System.Drawing.Size(288, 20);
            this.w1.TabIndex = 6;
            this.w1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 446);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nội dung thủy vân cần nhúng";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(524, 453);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 20);
            this.textBox1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(600, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Kết quả tách thủy vân";
            // 
            // dentrag
            // 
            this.dentrag.Location = new System.Drawing.Point(425, 6);
            this.dentrag.Name = "dentrag";
            this.dentrag.Size = new System.Drawing.Size(75, 23);
            this.dentrag.TabIndex = 16;
            this.dentrag.Text = "Đen trắng";
            this.dentrag.UseVisualStyleBackColor = true;
            this.dentrag.Click += new System.EventHandler(this.btnDT_Click);
            // 
            // tangsang2
            // 
            this.tangsang2.Location = new System.Drawing.Point(291, 3);
            this.tangsang2.Name = "tangsang2";
            this.tangsang2.Size = new System.Drawing.Size(100, 28);
            this.tangsang2.TabIndex = 15;
            this.tangsang2.Text = "Tăng độ sáng 2";
            this.tangsang2.UseVisualStyleBackColor = true;
            this.tangsang2.Click += new System.EventHandler(this.button5_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(746, 6);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 17;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 535);
            this.Controls.Add(this.save);
            this.Controls.Add(this.dentrag);
            this.Controls.Add(this.tangsang2);
            this.Controls.Add(this.tangsang1);
            this.Controls.Add(this.btw3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btw2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.w1);
            this.Controls.Add(this.btw1);
            this.Controls.Add(this.lap);
            this.Controls.Add(this.gradien);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button gradien;
        private System.Windows.Forms.Button lap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button tangsang1;
        private System.Windows.Forms.Button btw1;
        private System.Windows.Forms.Button btw2;
        private System.Windows.Forms.Button btw3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox w1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button dentrag;
        private System.Windows.Forms.Button tangsang2;
        private System.Windows.Forms.Button save;
    }
}


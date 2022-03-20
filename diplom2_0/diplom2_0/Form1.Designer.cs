namespace diplom2_0
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localMaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clusterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.probaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localMinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anomalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.climbingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qualityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.splineToolStripMenuItem,
            this.borderToolStripMenuItem,
            this.localMaxToolStripMenuItem,
            this.clusterToolStripMenuItem,
            this.probaToolStripMenuItem,
            this.climbingToolStripMenuItem,
            this.qualityToolStripMenuItem,
            this.visualToolStripMenuItem,
            this.localMinToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.diffToolStripMenuItem,
            this.anomalToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 6, 0, 6);
            this.menuStrip1.Size = new System.Drawing.Size(1540, 37);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(133, 25);
            this.fileToolStripMenuItem.Text = "Відкрити файл";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // splineToolStripMenuItem
            // 
            this.splineToolStripMenuItem.Name = "splineToolStripMenuItem";
            this.splineToolStripMenuItem.Size = new System.Drawing.Size(77, 25);
            this.splineToolStripMenuItem.Text = "Сплайн";
            this.splineToolStripMenuItem.Click += new System.EventHandler(this.splineToolStripMenuItem_Click);
            // 
            // borderToolStripMenuItem
            // 
            this.borderToolStripMenuItem.Name = "borderToolStripMenuItem";
            this.borderToolStripMenuItem.Size = new System.Drawing.Size(199, 25);
            this.borderToolStripMenuItem.Text = "Вилучення аномальних";
            this.borderToolStripMenuItem.Click += new System.EventHandler(this.borderToolStripMenuItem_Click);
            // 
            // localMaxToolStripMenuItem
            // 
            this.localMaxToolStripMenuItem.Name = "localMaxToolStripMenuItem";
            this.localMaxToolStripMenuItem.Size = new System.Drawing.Size(181, 25);
            this.localMaxToolStripMenuItem.Text = "Локальні максимуми";
            this.localMaxToolStripMenuItem.Click += new System.EventHandler(this.localMaxToolStripMenuItem_Click);
            // 
            // clusterToolStripMenuItem
            // 
            this.clusterToolStripMenuItem.Name = "clusterToolStripMenuItem";
            this.clusterToolStripMenuItem.Size = new System.Drawing.Size(126, 25);
            this.clusterToolStripMenuItem.Text = "Кластерізація";
            this.clusterToolStripMenuItem.Click += new System.EventHandler(this.clusterToolStripMenuItem_Click);
            // 
            // probaToolStripMenuItem
            // 
            this.probaToolStripMenuItem.Name = "probaToolStripMenuItem";
            this.probaToolStripMenuItem.Size = new System.Drawing.Size(208, 25);
            this.probaToolStripMenuItem.Text = "Пошук цільових об\'єктів";
            this.probaToolStripMenuItem.Click += new System.EventHandler(this.probaToolStripMenuItem_Click);
            // 
            // visualToolStripMenuItem
            // 
            this.visualToolStripMenuItem.Name = "visualToolStripMenuItem";
            this.visualToolStripMenuItem.Size = new System.Drawing.Size(64, 25);
            this.visualToolStripMenuItem.Text = "Visual";
            this.visualToolStripMenuItem.Visible = false;
            this.visualToolStripMenuItem.Click += new System.EventHandler(this.visualToolStripMenuItem_Click);
            // 
            // localMinToolStripMenuItem
            // 
            this.localMinToolStripMenuItem.Name = "localMinToolStripMenuItem";
            this.localMinToolStripMenuItem.Size = new System.Drawing.Size(88, 25);
            this.localMinToolStripMenuItem.Text = "LocalMin";
            this.localMinToolStripMenuItem.Visible = false;
            this.localMinToolStripMenuItem.Click += new System.EventHandler(this.localMinToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(56, 25);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Visible = false;
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // diffToolStripMenuItem
            // 
            this.diffToolStripMenuItem.Name = "diffToolStripMenuItem";
            this.diffToolStripMenuItem.Size = new System.Drawing.Size(49, 25);
            this.diffToolStripMenuItem.Text = "Diff";
            this.diffToolStripMenuItem.Visible = false;
            this.diffToolStripMenuItem.Click += new System.EventHandler(this.diffToolStripMenuItem_Click);
            // 
            // anomalToolStripMenuItem
            // 
            this.anomalToolStripMenuItem.Name = "anomalToolStripMenuItem";
            this.anomalToolStripMenuItem.Size = new System.Drawing.Size(176, 25);
            this.anomalToolStripMenuItem.Text = "Вилучити аномальні";
            this.anomalToolStripMenuItem.Visible = false;
            this.anomalToolStripMenuItem.Click += new System.EventHandler(this.anomalToolStripMenuItem_Click);
            // 
            // climbingToolStripMenuItem
            // 
            this.climbingToolStripMenuItem.Name = "climbingToolStripMenuItem";
            this.climbingToolStripMenuItem.Size = new System.Drawing.Size(115, 25);
            this.climbingToolStripMenuItem.Text = "Сегментація";
            this.climbingToolStripMenuItem.Click += new System.EventHandler(this.climbingToolStripMenuItem_Click);
            // 
            // qualityToolStripMenuItem
            // 
            this.qualityToolStripMenuItem.Name = "qualityToolStripMenuItem";
            this.qualityToolStripMenuItem.Size = new System.Drawing.Size(73, 25);
            this.qualityToolStripMenuItem.Text = "Quality";
            this.qualityToolStripMenuItem.Visible = false;
            this.qualityToolStripMenuItem.Click += new System.EventHandler(this.qualityToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(56, 95);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(593, 410);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.zedGraphControl1.IsAutoScrollRange = true;
            this.zedGraphControl1.Location = new System.Drawing.Point(674, 62);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(827, 474);
            this.zedGraphControl1.TabIndex = 2;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            this.zedGraphControl1.Load += new System.EventHandler(this.splineToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(729, 594);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(55, 33);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "9";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(862, 592);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(55, 30);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "12";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(687, 598);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(818, 597);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mx";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(968, 594);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "My";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(1013, 589);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(55, 33);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "12";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(13, 594);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(636, 104);
            this.listBox1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(1102, 608);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "%";
            this.label5.Visible = false;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.Location = new System.Drawing.Point(1147, 604);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(55, 33);
            this.textBox5.TabIndex = 13;
            this.textBox5.Text = "90";
            this.textBox5.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(935, 644);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 29);
            this.textBox4.TabIndex = 15;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(735, 647);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "% інформативності";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 845);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Дипломна робота Жултинська А.К.";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem splineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clusterToolStripMenuItem;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem localMaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ToolStripMenuItem borderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localMinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem climbingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qualityToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem probaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anomalToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
    }
}


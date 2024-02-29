namespace Converter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            textBox2 = new TextBox();
            label3 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            groupBox1 = new GroupBox();
            Label4 = new Label();
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "GCJ02转BD09", "GCJ02转WGS84", "BD09转GCJ02", "BD09转WGS84", "WGS84转GCJ02", "WGS84转BD09" });
            comboBox1.Location = new Point(24, 245);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(188, 32);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 214);
            label1.Name = "label1";
            label1.Size = new Size(100, 24);
            label1.TabIndex = 2;
            label1.Text = "转换方法：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 18);
            label2.Name = "label2";
            label2.Size = new Size(0, 24);
            label2.TabIndex = 3;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(14, 142);
            button1.Name = "button1";
            button1.Size = new Size(182, 71);
            button1.TabIndex = 4;
            button1.Text = "转换";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.InactiveCaption;
            textBox2.Location = new Point(234, 45);
            textBox2.MinimumSize = new Size(0, 100);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(522, 363);
            textBox2.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(234, 14);
            label3.Name = "label3";
            label3.Size = new Size(86, 24);
            label3.TabIndex = 7;
            label3.Text = "转换结果:";
            // 
            // button2
            // 
            button2.Location = new Point(28, 35);
            button2.Name = "button2";
            button2.Size = new Size(184, 71);
            button2.TabIndex = 8;
            button2.Text = "导入坐标文件(.txt)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(30, 112);
            button3.Name = "button3";
            button3.Size = new Size(182, 52);
            button3.TabIndex = 9;
            button3.Text = "查看坐标文件示例";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(322, 8);
            button4.Name = "button4";
            button4.Size = new Size(209, 34);
            button4.TabIndex = 12;
            button4.Text = "复制转换结果到剪切板";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(17, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(211, 172);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "导入";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new Point(6, 109);
            Label4.Name = "Label4";
            Label4.Size = new Size(139, 24);
            Label4.TabIndex = 14;
            Label4.Text = "小数位数(3-14):";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(138, 106);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(58, 30);
            textBox1.TabIndex = 15;
            textBox1.Text = "7";
            textBox1.Leave += textBox1_Leave;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(Label4);
            groupBox2.Controls.Add(button1);
            groupBox2.Location = new Point(16, 182);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(212, 226);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "转换";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 428);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "坐标转换器";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Button button1;
        private TextBox textBox2;
        private Label label3;
        private Button button2;
        private Button button3;
        private Button button4;
        private GroupBox groupBox1;
        private Label Label4;
        private TextBox textBox1;
        private GroupBox groupBox2;
    }
}

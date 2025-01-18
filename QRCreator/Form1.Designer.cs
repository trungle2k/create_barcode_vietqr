namespace QRCreator
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtSTK = new TextBox();
            txtTenTaiKhoan = new TextBox();
            txtSoTien = new NumericUpDown();
            label4 = new Label();
            cb_template = new ComboBox();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            textBox1 = new TextBox();
            label5 = new Label();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)txtSoTien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 13);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 0;
            label1.Text = "Số tài khoản:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 73);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 1;
            label2.Text = "Tên tài khoản:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 140);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 2;
            label3.Text = "Số tiền:";
            // 
            // txtSTK
            // 
            txtSTK.Location = new Point(27, 35);
            txtSTK.Name = "txtSTK";
            txtSTK.Size = new Size(185, 23);
            txtSTK.TabIndex = 3;
            txtSTK.KeyPress += txtSTK_KeyPress;
            // 
            // txtTenTaiKhoan
            // 
            txtTenTaiKhoan.Location = new Point(27, 95);
            txtTenTaiKhoan.Name = "txtTenTaiKhoan";
            txtTenTaiKhoan.Size = new Size(185, 23);
            txtTenTaiKhoan.TabIndex = 4;
            // 
            // txtSoTien
            // 
            txtSoTien.Location = new Point(27, 162);
            txtSoTien.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            txtSoTien.Name = "txtSoTien";
            txtSoTien.Size = new Size(185, 23);
            txtSoTien.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 320);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 6;
            label4.Text = "QR Template:";
            // 
            // cb_template
            // 
            cb_template.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_template.FormattingEnabled = true;
            cb_template.Items.AddRange(new object[] { "compact", "compact2", "qr_only", "print" });
            cb_template.Location = new Point(27, 342);
            cb_template.Name = "cb_template";
            cb_template.Size = new Size(185, 23);
            cb_template.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(264, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(401, 387);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(466, 430);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 9;
            button1.Text = "Save image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonSaveImage_Click;
            // 
            // button2
            // 
            button2.Location = new Point(547, 430);
            button2.Name = "button2";
            button2.Size = new Size(118, 23);
            button2.TabIndex = 10;
            button2.Text = "Copy to clipboard";
            button2.UseVisualStyleBackColor = true;
            button2.Click += CopyImage_Click;
            // 
            // button3
            // 
            button3.Location = new Point(264, 412);
            button3.Name = "button3";
            button3.Size = new Size(75, 48);
            button3.TabIndex = 11;
            button3.Text = "Create QR";
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonCreateQR_Click;
            // 
            // button4
            // 
            button4.Location = new Point(27, 405);
            button4.Name = "button4";
            button4.Size = new Size(80, 23);
            button4.TabIndex = 12;
            button4.Text = "Load file";
            button4.UseVisualStyleBackColor = true;
            button4.Click += buttonCretateQRFromFile_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(27, 227);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(185, 81);
            textBox1.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 204);
            label5.Name = "label5";
            label5.Size = new Size(125, 15);
            label5.TabIndex = 13;
            label5.Text = "Nội dung chuyển tiền:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(27, 380);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(127, 19);
            checkBox1.TabIndex = 15;
            checkBox1.Text = "Create QR from file";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 472);
            Controls.Add(checkBox1);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(cb_template);
            Controls.Add(label4);
            Controls.Add(txtSoTien);
            Controls.Add(txtTenTaiKhoan);
            Controls.Add(txtSTK);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BIDV QR Creator";
            ((System.ComponentModel.ISupportInitialize)txtSoTien).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtSTK;
        private TextBox txtTenTaiKhoan;
        private NumericUpDown txtSoTien;
        private Label label4;
        private ComboBox cb_template;
        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox textBox1;
        private Label label5;
        private CheckBox checkBox1;
    }
}

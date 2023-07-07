namespace Lab5
{
    partial class Bai1
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
            tbFrom = new TextBox();
            tbTo = new TextBox();
            label3 = new Label();
            tbPassword = new TextBox();
            btnSend = new Button();
            label4 = new Label();
            tbSubject = new TextBox();
            BodyBox = new RichTextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 37);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "From:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 71);
            label2.Name = "label2";
            label2.Size = new Size(23, 15);
            label2.TabIndex = 1;
            label2.Text = "To:";
            // 
            // tbFrom
            // 
            tbFrom.Location = new Point(106, 34);
            tbFrom.Name = "tbFrom";
            tbFrom.Size = new Size(205, 23);
            tbFrom.TabIndex = 2;
            // 
            // tbTo
            // 
            tbTo.Location = new Point(106, 68);
            tbTo.Name = "tbTo";
            tbTo.Size = new Size(205, 23);
            tbTo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(373, 37);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 4;
            label3.Text = "Password:";
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(439, 31);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(205, 23);
            tbPassword.TabIndex = 5;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(673, 28);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(67, 58);
            btnSend.TabIndex = 6;
            btnSend.Text = "SEND";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 135);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 7;
            label4.Text = "Subject:";
            // 
            // tbSubject
            // 
            tbSubject.Location = new Point(106, 132);
            tbSubject.Name = "tbSubject";
            tbSubject.Size = new Size(634, 23);
            tbSubject.TabIndex = 8;
            // 
            // BodyBox
            // 
            BodyBox.Location = new Point(106, 179);
            BodyBox.Name = "BodyBox";
            BodyBox.Size = new Size(634, 259);
            BodyBox.TabIndex = 9;
            BodyBox.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(51, 179);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 10;
            label5.Text = "Body:";
            // 
            // Bai1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(BodyBox);
            Controls.Add(tbSubject);
            Controls.Add(label4);
            Controls.Add(btnSend);
            Controls.Add(tbPassword);
            Controls.Add(label3);
            Controls.Add(tbTo);
            Controls.Add(tbFrom);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Bai1";
            Text = "Bài 1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tbFrom;
        private TextBox tbTo;
        private Label label3;
        private TextBox tbPassword;
        private Button btnSend;
        private Label label4;
        private TextBox tbSubject;
        private RichTextBox BodyBox;
        private Label label5;
    }
}
namespace Lab5
{
    partial class Bai3
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            btnAttach = new System.Windows.Forms.Button();
            btnSend = new System.Windows.Forms.Button();
            txtBody = new System.Windows.Forms.RichTextBox();
            txtFrom = new System.Windows.Forms.TextBox();
            txtTo = new System.Windows.Forms.TextBox();
            txtPassword = new System.Windows.Forms.TextBox();
            Attach = new System.Windows.Forms.TextBox();
            txtSubject = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(42, 34);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "From:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(362, 34);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(42, 78);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(23, 15);
            label3.TabIndex = 2;
            label3.Text = "To:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(42, 120);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(49, 15);
            label4.TabIndex = 3;
            label4.Text = "Subject:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(42, 162);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(37, 15);
            label5.TabIndex = 4;
            label5.Text = "Body:";
            // 
            // btnAttach
            // 
            btnAttach.Location = new System.Drawing.Point(676, 78);
            btnAttach.Name = "btnAttach";
            btnAttach.Size = new System.Drawing.Size(87, 23);
            btnAttach.TabIndex = 5;
            btnAttach.Text = "Attachment";
            btnAttach.UseVisualStyleBackColor = true;
            btnAttach.Click += this.btnAttach_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new System.Drawing.Point(688, 415);
            btnSend.Name = "btnSend";
            btnSend.Size = new System.Drawing.Size(75, 23);
            btnSend.TabIndex = 6;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += this.btnSend_Click;
            // 
            // txtBody
            // 
            txtBody.Location = new System.Drawing.Point(42, 192);
            txtBody.Name = "txtBody";
            txtBody.Size = new System.Drawing.Size(721, 217);
            txtBody.TabIndex = 7;
            txtBody.Text = "";
            // 
            // txtFrom
            // 
            txtFrom.Location = new System.Drawing.Point(103, 34);
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new System.Drawing.Size(228, 23);
            txtFrom.TabIndex = 8;
            // 
            // txtTo
            // 
            txtTo.Location = new System.Drawing.Point(103, 78);
            txtTo.Name = "txtTo";
            txtTo.Size = new System.Drawing.Size(228, 23);
            txtTo.TabIndex = 9;
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(425, 31);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new System.Drawing.Size(228, 23);
            txtPassword.TabIndex = 10;
            // 
            // Attach
            // 
            Attach.Location = new System.Drawing.Point(425, 78);
            Attach.Name = "Attach";
            Attach.Size = new System.Drawing.Size(228, 23);
            Attach.TabIndex = 11;
            // 
            // txtSubject
            // 
            txtSubject.Location = new System.Drawing.Point(103, 117);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new System.Drawing.Size(660, 23);
            txtSubject.TabIndex = 12;
            // 
            // Bai3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(txtSubject);
            this.Controls.Add(Attach);
            this.Controls.Add(txtPassword);
            this.Controls.Add(txtTo);
            this.Controls.Add(txtFrom);
            this.Controls.Add(txtBody);
            this.Controls.Add(btnSend);
            this.Controls.Add(btnAttach);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Name = "Bai3";
            this.Text = "Bài 3";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnAttach;
        private Button btnSend;
        private RichTextBox txtBody;
        private TextBox txtFrom;
        private TextBox txtTo;
        private TextBox txtPassword;
        private TextBox Attach;
        private TextBox txtSubject;
    }
}
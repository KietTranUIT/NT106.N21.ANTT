namespace Lab5
{
    partial class Bai2
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btn_Login = new Button();
            label3 = new Label();
            label4 = new Label();
            label_Total = new Label();
            label_Recent = new Label();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 33);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 66);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(108, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(490, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(108, 63);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(490, 23);
            textBox2.TabIndex = 3;
            // 
            // btn_Login
            // 
            btn_Login.Location = new Point(640, 29);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(114, 57);
            btn_Login.TabIndex = 4;
            btn_Login.Text = "LOGIN";
            btn_Login.UseVisualStyleBackColor = true;
            btn_Login.Click += btn_Login_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 161);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 5;
            label3.Text = "Total:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(330, 161);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 6;
            label4.Text = "Recent:";
            // 
            // label_Total
            // 
            label_Total.AutoSize = true;
            label_Total.Location = new Point(85, 161);
            label_Total.Name = "label_Total";
            label_Total.Size = new Size(0, 15);
            label_Total.TabIndex = 7;
            // 
            // label_Recent
            // 
            label_Recent.AutoSize = true;
            label_Recent.Location = new Point(382, 161);
            label_Recent.Name = "label_Recent";
            label_Recent.Size = new Size(0, 15);
            label_Recent.TabIndex = 8;
            // 
            // listView1
            // 
            listView1.Location = new Point(38, 195);
            listView1.Name = "listView1";
            listView1.Size = new Size(716, 243);
            listView1.TabIndex = 9;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // Bai2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(label_Recent);
            Controls.Add(label_Total);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btn_Login);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Bai2";
            Text = "Bài 2";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btn_Login;
        private Label label3;
        private Label label4;
        private Label label_Total;
        private Label label_Recent;
        private ListView listView1;
    }
}
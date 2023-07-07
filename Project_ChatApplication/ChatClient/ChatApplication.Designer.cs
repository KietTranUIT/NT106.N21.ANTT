
namespace ChatClient
{
    partial class ChatApplication
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            ""}, 0, System.Drawing.Color.Empty, System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(113)))), ((int)(((byte)(253))))), new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("", 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("", 2);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("", 3);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("", 4);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("", 5);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatApplication));
            this.listUser = new System.Windows.Forms.ListView();
            this.NameDisplay = new System.Windows.Forms.Label();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toUser = new System.Windows.Forms.ListBox();
            this.checkPrivate = new System.Windows.Forms.RadioButton();
            this.checkPublic = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.listEmoji = new System.Windows.Forms.ListView();
            this.imageIcon = new System.Windows.Forms.ImageList(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.historyMessage = new System.Windows.Forms.Button();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.changePassword = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.DisplayName = new System.Windows.Forms.Label();
            this.LogOut = new System.Windows.Forms.Button();
            this.panelHistory = new System.Windows.Forms.Panel();
            this.listHistory = new System.Windows.Forms.ListView();
            this.Sender = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEmoji = new System.Windows.Forms.Button();
            this.ChatRoom = new System.Windows.Forms.RichTextBox();
            this.panelResetPassword = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textNewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelHistory.SuspendLayout();
            this.panelResetPassword.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listUser
            // 
            this.listUser.BackColor = System.Drawing.Color.White;
            this.listUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(59)))));
            this.listUser.HideSelection = false;
            this.listUser.Location = new System.Drawing.Point(0, 121);
            this.listUser.Name = "listUser";
            this.listUser.Size = new System.Drawing.Size(293, 308);
            this.listUser.TabIndex = 0;
            this.listUser.UseCompatibleStateImageBehavior = false;
            this.listUser.View = System.Windows.Forms.View.List;
            this.listUser.SelectedIndexChanged += new System.EventHandler(this.listUser_SelectedIndexChanged);
            // 
            // NameDisplay
            // 
            this.NameDisplay.AutoSize = true;
            this.NameDisplay.Location = new System.Drawing.Point(3, 0);
            this.NameDisplay.Name = "NameDisplay";
            this.NameDisplay.Size = new System.Drawing.Size(93, 25);
            this.NameDisplay.TabIndex = 1;
            this.NameDisplay.Text = "User Hello";
            // 
            // MessageBox
            // 
            this.MessageBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MessageBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(59)))));
            this.MessageBox.Location = new System.Drawing.Point(14, 701);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(624, 31);
            this.MessageBox.TabIndex = 4;
            // 
            // ButtonSend
            // 
            this.ButtonSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(113)))), ((int)(((byte)(253)))));
            this.ButtonSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSend.Image = global::ChatClient.Properties.Resources.icons8_send_30;
            this.ButtonSend.Location = new System.Drawing.Point(658, 698);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(51, 44);
            this.ButtonSend.TabIndex = 5;
            this.ButtonSend.UseVisualStyleBackColor = false;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(113)))), ((int)(((byte)(253)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 80);
            this.panel1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(92, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 54);
            this.label5.TabIndex = 18;
            this.label5.Text = "Chat App";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(113)))), ((int)(((byte)(253)))));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::ChatClient.Properties.Resources.icons8_wechat_64;
            this.pictureBox1.Location = new System.Drawing.Point(-3, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(0, 77);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(414, 74);
            this.panel5.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(50, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Connected";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(83, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 54);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mode";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(59)))));
            this.panel3.Controls.Add(this.toUser);
            this.panel3.Controls.Add(this.checkPrivate);
            this.panel3.Controls.Add(this.checkPublic);
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(0, 521);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(293, 221);
            this.panel3.TabIndex = 8;
            // 
            // toUser
            // 
            this.toUser.FormattingEnabled = true;
            this.toUser.ItemHeight = 28;
            this.toUser.Items.AddRange(new object[] {
            "Select user"});
            this.toUser.Location = new System.Drawing.Point(146, 118);
            this.toUser.Name = "toUser";
            this.toUser.Size = new System.Drawing.Size(144, 32);
            this.toUser.TabIndex = 13;
            this.toUser.SelectedIndexChanged += new System.EventHandler(this.toUser_SelectedIndexChanged);
            // 
            // checkPrivate
            // 
            this.checkPrivate.AutoSize = true;
            this.checkPrivate.Location = new System.Drawing.Point(36, 118);
            this.checkPrivate.Name = "checkPrivate";
            this.checkPrivate.Size = new System.Drawing.Size(104, 32);
            this.checkPrivate.TabIndex = 12;
            this.checkPrivate.TabStop = true;
            this.checkPrivate.Text = "Private";
            this.checkPrivate.UseVisualStyleBackColor = true;
            // 
            // checkPublic
            // 
            this.checkPublic.AutoSize = true;
            this.checkPublic.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkPublic.ForeColor = System.Drawing.Color.White;
            this.checkPublic.Location = new System.Drawing.Point(36, 59);
            this.checkPublic.Name = "checkPublic";
            this.checkPublic.Size = new System.Drawing.Size(95, 32);
            this.checkPublic.TabIndex = 11;
            this.checkPublic.TabStop = true;
            this.checkPublic.Text = "Public";
            this.checkPublic.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(113)))), ((int)(((byte)(253)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::ChatClient.Properties.Resources.icons8_paperclip_48;
            this.button1.Location = new System.Drawing.Point(785, 698);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 44);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listEmoji
            // 
            this.listEmoji.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(113)))), ((int)(((byte)(253)))));
            this.listEmoji.HideSelection = false;
            listViewItem1.UseItemStyleForSubItems = false;
            this.listEmoji.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.listEmoji.LabelEdit = true;
            this.listEmoji.LargeImageList = this.imageIcon;
            this.listEmoji.Location = new System.Drawing.Point(724, 521);
            this.listEmoji.Name = "listEmoji";
            this.listEmoji.Size = new System.Drawing.Size(48, 161);
            this.listEmoji.SmallImageList = this.imageIcon;
            this.listEmoji.TabIndex = 12;
            this.listEmoji.UseCompatibleStateImageBehavior = false;
            this.listEmoji.View = System.Windows.Forms.View.List;
            this.listEmoji.Visible = false;
            this.listEmoji.SelectedIndexChanged += new System.EventHandler(this.listEmoji_SelectedIndexChanged);
            // 
            // imageIcon
            // 
            this.imageIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageIcon.ImageStream")));
            this.imageIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageIcon.Images.SetKeyName(0, "grinning.png");
            this.imageIcon.Images.SetKeyName(1, "heart_eyes.png");
            this.imageIcon.Images.SetKeyName(2, "laughing.png");
            this.imageIcon.Images.SetKeyName(3, "open_mouth.png");
            this.imageIcon.Images.SetKeyName(4, "sob.png");
            this.imageIcon.Images.SetKeyName(5, "star-struck.png");
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(113)))), ((int)(((byte)(253)))));
            this.panel4.Controls.Add(this.historyMessage);
            this.panel4.Controls.Add(this.buttonSetting);
            this.panel4.Controls.Add(this.changePassword);
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Controls.Add(this.DisplayName);
            this.panel4.Controls.Add(this.LogOut);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(836, 80);
            this.panel4.TabIndex = 9;
            // 
            // historyMessage
            // 
            this.historyMessage.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.historyMessage.FlatAppearance.BorderSize = 3;
            this.historyMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.historyMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.historyMessage.ForeColor = System.Drawing.Color.White;
            this.historyMessage.Location = new System.Drawing.Point(472, 36);
            this.historyMessage.Name = "historyMessage";
            this.historyMessage.Size = new System.Drawing.Size(180, 41);
            this.historyMessage.TabIndex = 1;
            this.historyMessage.Text = "History Message";
            this.historyMessage.UseVisualStyleBackColor = true;
            this.historyMessage.Visible = false;
            this.historyMessage.Click += new System.EventHandler(this.historyMessage_Click);
            // 
            // buttonSetting
            // 
            this.buttonSetting.FlatAppearance.BorderSize = 0;
            this.buttonSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetting.Font = new System.Drawing.Font("Segoe UI", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.buttonSetting.ForeColor = System.Drawing.Color.White;
            this.buttonSetting.Image = global::ChatClient.Properties.Resources.icons8_setting_50;
            this.buttonSetting.Location = new System.Drawing.Point(658, 3);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(92, 74);
            this.buttonSetting.TabIndex = 15;
            this.buttonSetting.UseVisualStyleBackColor = true;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // changePassword
            // 
            this.changePassword.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.changePassword.FlatAppearance.BorderSize = 3;
            this.changePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changePassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.changePassword.ForeColor = System.Drawing.Color.White;
            this.changePassword.Location = new System.Drawing.Point(472, 0);
            this.changePassword.Name = "changePassword";
            this.changePassword.Size = new System.Drawing.Size(180, 42);
            this.changePassword.TabIndex = 0;
            this.changePassword.Text = "Change Password";
            this.changePassword.UseVisualStyleBackColor = true;
            this.changePassword.Visible = false;
            this.changePassword.Click += new System.EventHandler(this.changePassword_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ChatClient.Properties.Resources.icons8_user_50__1_;
            this.pictureBox3.Location = new System.Drawing.Point(3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(78, 75);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // DisplayName
            // 
            this.DisplayName.AutoSize = true;
            this.DisplayName.BackColor = System.Drawing.Color.Transparent;
            this.DisplayName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DisplayName.ForeColor = System.Drawing.Color.White;
            this.DisplayName.Location = new System.Drawing.Point(87, 19);
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.Size = new System.Drawing.Size(158, 41);
            this.DisplayName.TabIndex = 14;
            this.DisplayName.Text = "Username";
            // 
            // LogOut
            // 
            this.LogOut.FlatAppearance.BorderSize = 0;
            this.LogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOut.Image = global::ChatClient.Properties.Resources.icons8_logout_50;
            this.LogOut.Location = new System.Drawing.Point(756, 12);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(61, 54);
            this.LogOut.TabIndex = 15;
            this.LogOut.UseVisualStyleBackColor = true;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // panelHistory
            // 
            this.panelHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(113)))), ((int)(((byte)(253)))));
            this.panelHistory.Controls.Add(this.listHistory);
            this.panelHistory.Controls.Add(this.label4);
            this.panelHistory.Location = new System.Drawing.Point(14, 102);
            this.panelHistory.Name = "panelHistory";
            this.panelHistory.Size = new System.Drawing.Size(819, 382);
            this.panelHistory.TabIndex = 3;
            this.panelHistory.Visible = false;
            // 
            // listHistory
            // 
            this.listHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Sender,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listHistory.HideSelection = false;
            this.listHistory.Location = new System.Drawing.Point(0, 44);
            this.listHistory.Name = "listHistory";
            this.listHistory.Size = new System.Drawing.Size(819, 335);
            this.listHistory.TabIndex = 1;
            this.listHistory.UseCompatibleStateImageBehavior = false;
            this.listHistory.View = System.Windows.Forms.View.Details;
            // 
            // Sender
            // 
            this.Sender.Text = "Sender";
            this.Sender.Width = 160;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Receiver";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Content";
            this.columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            this.columnHeader3.Width = 190;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(337, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 41);
            this.label4.TabIndex = 0;
            this.label4.Text = "History";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // buttonEmoji
            // 
            this.buttonEmoji.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(113)))), ((int)(((byte)(253)))));
            this.buttonEmoji.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEmoji.Image = global::ChatClient.Properties.Resources.icons8_slightly_smiling_face_48;
            this.buttonEmoji.Location = new System.Drawing.Point(724, 698);
            this.buttonEmoji.Name = "buttonEmoji";
            this.buttonEmoji.Size = new System.Drawing.Size(48, 44);
            this.buttonEmoji.TabIndex = 11;
            this.buttonEmoji.UseVisualStyleBackColor = false;
            this.buttonEmoji.Click += new System.EventHandler(this.buttonEmoji_Click);
            // 
            // ChatRoom
            // 
            this.ChatRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(59)))));
            this.ChatRoom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ChatRoom.ForeColor = System.Drawing.Color.White;
            this.ChatRoom.Location = new System.Drawing.Point(0, 77);
            this.ChatRoom.Name = "ChatRoom";
            this.ChatRoom.Size = new System.Drawing.Size(833, 605);
            this.ChatRoom.TabIndex = 14;
            this.ChatRoom.Text = "";
            // 
            // panelResetPassword
            // 
            this.panelResetPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(113)))), ((int)(((byte)(253)))));
            this.panelResetPassword.Controls.Add(this.label7);
            this.panelResetPassword.Controls.Add(this.label6);
            this.panelResetPassword.Controls.Add(this.textNewPassword);
            this.panelResetPassword.Controls.Add(this.label3);
            this.panelResetPassword.Controls.Add(this.button2);
            this.panelResetPassword.Location = new System.Drawing.Point(472, 77);
            this.panelResetPassword.Name = "panelResetPassword";
            this.panelResetPassword.Size = new System.Drawing.Size(287, 149);
            this.panelResetPassword.TabIndex = 17;
            this.panelResetPassword.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(56, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "Fill new password!";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Chartreuse;
            this.label6.Location = new System.Drawing.Point(38, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Reset password success!";
            this.label6.Visible = false;
            // 
            // textNewPassword
            // 
            this.textNewPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(59)))));
            this.textNewPassword.Location = new System.Drawing.Point(29, 48);
            this.textNewPassword.Name = "textNewPassword";
            this.textNewPassword.Size = new System.Drawing.Size(239, 31);
            this.textNewPassword.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(73, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "New password";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(62, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reset Password";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(59)))));
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.listUser);
            this.panel6.Location = new System.Drawing.Point(1, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(293, 745);
            this.panel6.TabIndex = 19;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(113)))), ((int)(((byte)(253)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.label2);
            this.panel7.Location = new System.Drawing.Point(0, 435);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(293, 86);
            this.panel7.TabIndex = 7;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(59)))));
            this.panel8.Controls.Add(this.panel2);
            this.panel8.Controls.Add(this.panel4);
            this.panel8.Controls.Add(this.panelResetPassword);
            this.panel8.Controls.Add(this.button1);
            this.panel8.Controls.Add(this.listEmoji);
            this.panel8.Controls.Add(this.buttonEmoji);
            this.panel8.Controls.Add(this.panelHistory);
            this.panel8.Controls.Add(this.ButtonSend);
            this.panel8.Controls.Add(this.MessageBox);
            this.panel8.Controls.Add(this.ChatRoom);
            this.panel8.Location = new System.Drawing.Point(300, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(838, 745);
            this.panel8.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(113)))), ((int)(((byte)(253)))));
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(14, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 240);
            this.panel2.TabIndex = 17;
            this.panel2.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(59)))));
            this.textBox4.Location = new System.Drawing.Point(161, 182);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(314, 39);
            this.textBox4.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(59)))));
            this.textBox3.Location = new System.Drawing.Point(161, 122);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(314, 39);
            this.textBox3.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(59)))));
            this.textBox2.Location = new System.Drawing.Point(161, 66);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(314, 39);
            this.textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(59)))));
            this.textBox1.Location = new System.Drawing.Point(161, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(314, 39);
            this.textBox1.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(20, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 32);
            this.label11.TabIndex = 3;
            this.label11.Text = "Email:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(20, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 32);
            this.label10.TabIndex = 2;
            this.label10.Text = "Password:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(20, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 32);
            this.label9.TabIndex = 1;
            this.label9.Text = "Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(20, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 32);
            this.label8.TabIndex = 0;
            this.label8.Text = "Username:";
            // 
            // ChatApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1138, 744);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Name = "ChatApplication";
            this.Text = "ChatApplication";
            this.Load += new System.EventHandler(this.ChatApplication_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelHistory.ResumeLayout(false);
            this.panelHistory.PerformLayout();
            this.panelResetPassword.ResumeLayout(false);
            this.panelResetPassword.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listUser;
        private System.Windows.Forms.Label NameDisplay;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton checkPrivate;
        private System.Windows.Forms.RadioButton checkPublic;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button LogOut;
        private System.Windows.Forms.Label DisplayName;
        private System.Windows.Forms.Button buttonEmoji;
        private System.Windows.Forms.ListView listEmoji;
        private System.Windows.Forms.RichTextBox ChatRoom;
        private System.Windows.Forms.ImageList imageIcon;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.Panel panelResetPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textNewPassword;
        private System.Windows.Forms.Panel panelHistory;
        private System.Windows.Forms.ListView listHistory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader Sender;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button historyMessage;
        private System.Windows.Forms.Button changePassword;
        private System.Windows.Forms.ListBox toUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}
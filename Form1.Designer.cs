
namespace EncryptMail
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Account = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于EncryptMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AccountSetBtn = new System.Windows.Forms.Button();
            this.imapserver = new System.Windows.Forms.TextBox();
            this.smtpserver = new System.Windows.Forms.TextBox();
            this.passwd = new System.Windows.Forms.TextBox();
            this.myMail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MsgBox = new System.Windows.Forms.TextBox();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.FriendList = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开消息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空消息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加好友ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改昵称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更改密钥ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除好友ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFriend = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CurrentFriend = new System.Windows.Forms.Label();
            this.SendMail = new System.Windows.Forms.Button();
            this.AddAnnex = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.time = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1009, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.刷新ToolStripMenuItem.Text = "收件";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Account});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.设置ToolStripMenuItem.Text = "工具";
            // 
            // Account
            // 
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(152, 26);
            this.Account.Text = "账号设置";
            this.Account.Click += new System.EventHandler(this.Account_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem,
            this.关于EncryptMailToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于EncryptMailToolStripMenuItem
            // 
            this.关于EncryptMailToolStripMenuItem.Name = "关于EncryptMailToolStripMenuItem";
            this.关于EncryptMailToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.关于EncryptMailToolStripMenuItem.Text = "关于EncryptMail";
            this.关于EncryptMailToolStripMenuItem.Click += new System.EventHandler(this.关于EncryptMailToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.AccountSetBtn);
            this.groupBox1.Controls.Add(this.imapserver);
            this.groupBox1.Controls.Add(this.smtpserver);
            this.groupBox1.Controls.Add(this.passwd);
            this.groupBox1.Controls.Add(this.myMail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(682, 35);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(315, 512);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "账号设置";
            this.groupBox1.Visible = false;
            // 
            // AccountSetBtn
            // 
            this.AccountSetBtn.Location = new System.Drawing.Point(30, 455);
            this.AccountSetBtn.Name = "AccountSetBtn";
            this.AccountSetBtn.Size = new System.Drawing.Size(265, 36);
            this.AccountSetBtn.TabIndex = 8;
            this.AccountSetBtn.Text = "完成";
            this.AccountSetBtn.UseVisualStyleBackColor = true;
            this.AccountSetBtn.Click += new System.EventHandler(this.AccountSetBtn_Click);
            // 
            // imapserver
            // 
            this.imapserver.Location = new System.Drawing.Point(30, 400);
            this.imapserver.Name = "imapserver";
            this.imapserver.Size = new System.Drawing.Size(265, 34);
            this.imapserver.TabIndex = 7;
            this.imapserver.Text = "imap.qq.com";
            // 
            // smtpserver
            // 
            this.smtpserver.Location = new System.Drawing.Point(30, 300);
            this.smtpserver.Name = "smtpserver";
            this.smtpserver.Size = new System.Drawing.Size(265, 34);
            this.smtpserver.TabIndex = 6;
            this.smtpserver.Text = "smtp.qq.com";
            // 
            // passwd
            // 
            this.passwd.Location = new System.Drawing.Point(30, 200);
            this.passwd.Name = "passwd";
            this.passwd.PasswordChar = '*';
            this.passwd.Size = new System.Drawing.Size(265, 34);
            this.passwd.TabIndex = 5;
            this.passwd.Text = "xobugariurrrbaif";
            // 
            // myMail
            // 
            this.myMail.Location = new System.Drawing.Point(30, 100);
            this.myMail.Name = "myMail";
            this.myMail.Size = new System.Drawing.Size(265, 34);
            this.myMail.TabIndex = 4;
            this.myMail.Text = "785348525@qq.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 355);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "IMAP服务器：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 255);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "SMTP服务器：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 155);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "邮箱密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "邮箱账号：";
            // 
            // MsgBox
            // 
            this.MsgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MsgBox.Location = new System.Drawing.Point(12, 72);
            this.MsgBox.Multiline = true;
            this.MsgBox.Name = "MsgBox";
            this.MsgBox.ReadOnly = true;
            this.MsgBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MsgBox.Size = new System.Drawing.Size(663, 327);
            this.MsgBox.TabIndex = 2;
            // 
            // InputBox
            // 
            this.InputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputBox.Location = new System.Drawing.Point(12, 419);
            this.InputBox.Multiline = true;
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(467, 124);
            this.InputBox.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.FriendList);
            this.groupBox2.Controls.Add(this.AddFriend);
            this.groupBox2.Location = new System.Drawing.Point(682, 35);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(327, 508);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "好友列表";
            // 
            // FriendList
            // 
            this.FriendList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FriendList.ContextMenuStrip = this.contextMenuStrip1;
            this.FriendList.FormattingEnabled = true;
            this.FriendList.ItemHeight = 23;
            this.FriendList.Location = new System.Drawing.Point(7, 40);
            this.FriendList.Name = "FriendList";
            this.FriendList.Size = new System.Drawing.Size(308, 395);
            this.FriendList.TabIndex = 9;
            this.FriendList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FriendList_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开消息ToolStripMenuItem,
            this.清空消息ToolStripMenuItem,
            this.添加好友ToolStripMenuItem,
            this.修改昵称ToolStripMenuItem,
            this.更改密钥ToolStripMenuItem,
            this.删除好友ToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 196);
            // 
            // 打开消息ToolStripMenuItem
            // 
            this.打开消息ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.打开消息ToolStripMenuItem.Name = "打开消息ToolStripMenuItem";
            this.打开消息ToolStripMenuItem.Size = new System.Drawing.Size(164, 32);
            this.打开消息ToolStripMenuItem.Text = "打开消息";
            this.打开消息ToolStripMenuItem.Click += new System.EventHandler(this.FriendList_SelectedIndexChanged);
            // 
            // 清空消息ToolStripMenuItem
            // 
            this.清空消息ToolStripMenuItem.Name = "清空消息ToolStripMenuItem";
            this.清空消息ToolStripMenuItem.Size = new System.Drawing.Size(164, 32);
            this.清空消息ToolStripMenuItem.Text = "清空消息";
            this.清空消息ToolStripMenuItem.Click += new System.EventHandler(this.清空消息ToolStripMenuItem_Click);
            // 
            // 添加好友ToolStripMenuItem
            // 
            this.添加好友ToolStripMenuItem.Name = "添加好友ToolStripMenuItem";
            this.添加好友ToolStripMenuItem.Size = new System.Drawing.Size(164, 32);
            this.添加好友ToolStripMenuItem.Text = "添加好友";
            this.添加好友ToolStripMenuItem.Click += new System.EventHandler(this.AddFriend_Click);
            // 
            // 修改昵称ToolStripMenuItem
            // 
            this.修改昵称ToolStripMenuItem.Name = "修改昵称ToolStripMenuItem";
            this.修改昵称ToolStripMenuItem.Size = new System.Drawing.Size(164, 32);
            this.修改昵称ToolStripMenuItem.Text = "修改昵称";
            this.修改昵称ToolStripMenuItem.Click += new System.EventHandler(this.修改昵称ToolStripMenuItem_Click);
            // 
            // 更改密钥ToolStripMenuItem
            // 
            this.更改密钥ToolStripMenuItem.Name = "更改密钥ToolStripMenuItem";
            this.更改密钥ToolStripMenuItem.Size = new System.Drawing.Size(164, 32);
            this.更改密钥ToolStripMenuItem.Text = "更改密钥";
            this.更改密钥ToolStripMenuItem.Click += new System.EventHandler(this.更改密钥ToolStripMenuItem_Click);
            // 
            // 删除好友ToolStripMenuItem1
            // 
            this.删除好友ToolStripMenuItem1.Name = "删除好友ToolStripMenuItem1";
            this.删除好友ToolStripMenuItem1.Size = new System.Drawing.Size(164, 32);
            this.删除好友ToolStripMenuItem1.Text = "删除好友";
            this.删除好友ToolStripMenuItem1.Click += new System.EventHandler(this.删除好友ToolStripMenuItem1_Click);
            // 
            // AddFriend
            // 
            this.AddFriend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddFriend.Location = new System.Drawing.Point(7, 449);
            this.AddFriend.Name = "AddFriend";
            this.AddFriend.Size = new System.Drawing.Size(308, 56);
            this.AddFriend.TabIndex = 8;
            this.AddFriend.Text = "添加好友";
            this.AddFriend.UseVisualStyleBackColor = true;
            this.AddFriend.Click += new System.EventHandler(this.AddFriend_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "当前好友：";
            // 
            // CurrentFriend
            // 
            this.CurrentFriend.AutoSize = true;
            this.CurrentFriend.Location = new System.Drawing.Point(135, 45);
            this.CurrentFriend.Name = "CurrentFriend";
            this.CurrentFriend.Size = new System.Drawing.Size(0, 24);
            this.CurrentFriend.TabIndex = 6;
            // 
            // SendMail
            // 
            this.SendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendMail.Location = new System.Drawing.Point(481, 419);
            this.SendMail.Name = "SendMail";
            this.SendMail.Size = new System.Drawing.Size(194, 56);
            this.SendMail.TabIndex = 7;
            this.SendMail.Text = "发送消息";
            this.SendMail.UseVisualStyleBackColor = true;
            this.SendMail.Click += new System.EventHandler(this.SendMail_Click);
            // 
            // AddAnnex
            // 
            this.AddAnnex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddAnnex.Location = new System.Drawing.Point(481, 487);
            this.AddAnnex.Name = "AddAnnex";
            this.AddAnnex.Size = new System.Drawing.Size(194, 56);
            this.AddAnnex.TabIndex = 8;
            this.AddAnnex.Text = "添加附件";
            this.AddAnnex.UseVisualStyleBackColor = true;
            this.AddAnnex.Click += new System.EventHandler(this.AddAnnex_Click);
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(15, 551);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 24);
            this.status.TabIndex = 9;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // time
            // 
            this.time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(894, 6);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(70, 24);
            this.time.TabIndex = 10;
            this.time.Text = "00:00";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 610);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.time);
            this.Controls.Add(this.status);
            this.Controls.Add(this.AddAnnex);
            this.Controls.Add(this.SendMail);
            this.Controls.Add(this.CurrentFriend);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.MsgBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1080, 800);
            this.MinimumSize = new System.Drawing.Size(660, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EncryptMail";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Account;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AccountSetBtn;
        private System.Windows.Forms.TextBox imapserver;
        private System.Windows.Forms.TextBox smtpserver;
        private System.Windows.Forms.TextBox passwd;
        private System.Windows.Forms.TextBox myMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MsgBox;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label CurrentFriend;
        private System.Windows.Forms.Button SendMail;
        private System.Windows.Forms.Button AddAnnex;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Button AddFriend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox FriendList;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于EncryptMailToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开消息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加好友ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除好友ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 清空消息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改昵称ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更改密钥ToolStripMenuItem;
    }
}


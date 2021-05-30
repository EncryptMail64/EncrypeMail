using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Security.Cryptography;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;


namespace EncryptMail
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string annex = null;//附件
        private string piv = null;//加密配置文档使用的公共向量
        private string pkey = null;//加密配置文档使用的公共密钥
        private readonly List<Friend> Friends = new List<Friend>();
        
        private string ReadFile(string filename, int line)
        {
            int counter = 0;
            string output;
            StreamReader file = new StreamReader(filename);
            for (; ; )
            {
                output = file.ReadLine();
                counter++;
                if (counter == line) break;
                else if (output == null) break;
            }
            file.Close();
            return output;
        }//读取名为filename的文本文档，返回值为第line行的字符串。
        private bool CheckPwd()
        {
            try
            {
                Form2 fm = new Form2();
                fm.ShowDialog();
                string Key = Form2.passwd;
                string miwen = ReadFile("config.ini", 3);
                string iv = ReadFile("config.ini", 2);
                if (Key.Length < 16)
                    Key += iv.Substring(8, 16 - Key.Length);
                string text = AESDecrypt(miwen, Key, iv);
                if (text == "This is the Password check file.")
                {
                    pkey = Key;
                    return true;
                }
                else return false;
            }
            catch 
            {
                return false;
            }
        }//读取密文，用密码解密并对比
        private static string GetRandomString(int length)
        {
            byte[] b = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string str = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string s = null;
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }//随机字符生成
        private static string ToShort(string str,string cha)
        {
            int i = cha.Length;
            for (; ; )
            {
                string a = str.Substring(str.Length - i, i);
                if (a != cha) break;
                str = str.Substring(0, str.Length - i);
            }
            return str;
        }//将字符串str末尾的与字符串cha相同的部分去掉。
        private static string ToLong(string str, int length, char cha)
        {
            if (str.Length >= length) return str;
            int i = length - str.Length;
            for(;i>0 ; i--)
            {
                str += cha;
            }
            return str;
        }//将字符串str末尾用字符cha补齐至指定长度length
        private static string AESEncrypt(string toEncrypt, string key, string iv)
        {
            if (toEncrypt == null) return null;
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] ivArray = UTF8Encoding.UTF8.GetBytes(iv);
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.IV = ivArray;
            rDel.Mode = CipherMode.CBC;
            rDel.Padding = PaddingMode.Zeros;

            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }//AES加密
        private static string AESDecrypt(string toDecrypt, string key, string iv)
        {
            if (toDecrypt == null) return null;
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
            byte[] ivArray = UTF8Encoding.UTF8.GetBytes(iv);
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.IV = ivArray;
            rDel.Mode = CipherMode.CBC;
            rDel.Padding = PaddingMode.Zeros;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            string mingwen = UTF8Encoding.UTF8.GetString(resultArray);
            return ToShort(mingwen,"\0");
        }//AES解密
        private void WriteFile(string filename, int line, string str)
        {
            string[] array = File.ReadAllLines(filename);
            if (array.Length < line)
            {
                string[] m = new string[1];
                m[0] = str;
                File.AppendAllLines(filename, m);
                return;
            }
            array[line - 1] = str;
            File.WriteAllLines(filename, array, Encoding.UTF8);
            return;
        }//修改名为filename的文本文档，将其第line行内容修改为str。
        private void SaveMessage(string name, string msg)
        {
            string path = @".\message\" + name + ".dat";
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            byte[] buffer = Encoding.UTF8.GetBytes(msg);
            fs.Write(buffer, 0, buffer.Length);
            fs.Close();
            fs.Dispose();
        }//将消息msg储存入对应的文档中。
        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }//清空指定文件夹
        private void MailCommand(Friend fr, string command)
        {
            if ((command.Length > 47) && (command.Substring(0, 15) == "Change Password"))
            {
                Friend fr2 = new Friend(fr.Mailaddress, command.Substring(16), fr.Name);
                Friends.Remove(fr);
                Friends.Add(fr2);//更改list中的内容
                File.Delete(@".\message\" + fr2.Name + ".dat");//删除旧消息
                string[] array = File.ReadAllLines("friendlist.ini");
                int i = 0;
                foreach(string str in array)
                {
                    string m = AESDecrypt(str, pkey, piv);
                    if (ToShort(m.Substring(0, 20), "*") == fr2.Name) break;
                    i++;
                }
                array[i] = AESEncrypt(ToLong(fr2.Name, 20, '*') + fr2.Key + fr2.iv + fr2.Mailaddress, pkey, piv);
                File.WriteAllLines("friendlist.ini", array);//更改friendlist.ini文件
            }//按照邮件中的命令，更改通信密钥，删除旧的消息记录。
            return;
        }//接收并响应邮件指令
        private void SendCommand(Friend fr, string command)
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new System.Net.Mail.MailAddress(myMail.Text),
                Body = AESEncrypt("$$Command$$ "+command, fr.Key, fr.iv),
                SubjectEncoding = Encoding.UTF8,
                Subject = "EncryptMail",
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = false,
                Priority = MailPriority.Normal,
            };
            mailMessage.To.Add(fr.Mailaddress);
            #region
            int port = 25;
            int i = 0, j = 0;
            foreach (char a in myMail.Text)
            {
                i++;
                if (a == '@') break;
            }
            foreach (char a in myMail.Text)
            {
                j++;
                if (a == '.') break;
            }
            string servername = myMail.Text.Substring(i, j - i - 1);
            if ((servername == "live") || (servername == "gmail") || (servername == "yahoo")) port = 587;
            #endregion 
            //smtp地址以及端口号修正
            SmtpClient smtpClient = new SmtpClient(smtpserver.Text, port)
            {
                Credentials = new System.Net.NetworkCredential(myMail.Text, passwd.Text),//smtp用户名密码
                EnableSsl = true //启用ssl
            };
            smtpClient.Send(mailMessage);
            status.Text = "重置密码命令已发送！将清除旧的聊天信息。";
            mailMessage.Dispose();

        }//发送邮件指令

        private void Account_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }//账户设置按钮，未完成

        private void AccountSetBtn_Click(object sender, EventArgs e)
        {
            if (myMail.TextLength < 1)
            {
                status.Text = "邮箱不能为空！"; 
                return;
            }
            if (passwd.TextLength < 1)
            { 
                status.Text = "密码不能为空！"; 
                return; 
            }
            if (imapserver.TextLength < 1)
            { 
                status.Text = "IMAP服务器不能为空！"; 
                return;
            }
            if (smtpserver.TextLength < 1)
            {
                status.Text = "SMTP服务器不能为空！";
                return;
            }
            var client = new ImapClient();
            client.Connect(imapserver.Text);
            if (!client.IsConnected)
            {
                status.Text = "错误：无法连接服务器！";
                return;
            }
            else status.Text = "成功连接服务器!";
            client.Authenticate(myMail.Text, passwd.Text);
            if (!client.IsAuthenticated)
            {
                status.Text = "错误：登录失败，请检查邮箱地址和密码！";
                return;
            }
            else status.Text = "邮箱账号验证成功！";
            client.Disconnect(true);
            client.Dispose();
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            WriteFile("config.ini", 4, AESEncrypt(myMail.Text, pkey, piv));
            WriteFile("config.ini", 5, AESEncrypt(passwd.Text, pkey, piv));
            WriteFile("config.ini", 6, AESEncrypt(smtpserver.Text, pkey, piv));
            WriteFile("config.ini", 7, AESEncrypt(imapserver.Text, pkey, piv));
        }//账户设置按钮

        private void SendMail_Click(object sender, EventArgs e)
        {
            if (FriendList.SelectedItem == null) return;
            string n = FriendList.SelectedItem.ToString();
            Friend fr = null;
            fr = Friends.Find(item => item.Name.Equals(n));
            this.Cursor = Cursors.WaitCursor;
            // 实例化一个发送的邮件
            // 相当于与现实生活中先写信，程序中把信（邮件）抽象为邮件类了
            MailMessage mailMessage = new MailMessage
            {
                // 指明邮件发送的地址，主题，内容等信息
                // 发信人的地址为登录收发器的地址，这个收发器相当于我们平时Web版的邮箱或者是OutLook中配置的邮箱
                From = new System.Net.Mail.MailAddress(myMail.Text),
                Body = AESEncrypt(InputBox.Text,fr.Key,fr.iv),
                SubjectEncoding = Encoding.UTF8,
                Subject = "EncryptMail",
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = false,// 设置邮件正文不是Html格式的内容
                Priority = MailPriority.Normal ,// 设置邮件的优先级为普通优先级
            };
            mailMessage.To.Add(fr.Mailaddress);
            System.Net.Mail.Attachment attachment;// 封装发送的附件
            if (annex != null)
            {
                string fileNamePath = annex;
                string extName = Path.GetExtension(fileNamePath).ToLower();
                if (extName == ".rar" || extName == ".zip")
                {
                    attachment = new System.Net.Mail.Attachment(fileNamePath, MediaTypeNames.Application.Zip);
                }
                else
                {
                    attachment = new System.Net.Mail.Attachment(fileNamePath, MediaTypeNames.Application.Octet);
                }
                // 表示MIMEContent-Disposition标头信息
                // 对于ContentDisposition具体类的解释大家可以参考MSDN
                System.Net.Mime.ContentDisposition cd = attachment.ContentDisposition;
                cd.CreationDate = File.GetCreationTime(fileNamePath);
                cd.ModificationDate = File.GetLastWriteTime(fileNamePath);
                cd.ReadDate = File.GetLastAccessTime(fileNamePath);
                // 把附件对象加入到邮件附件集合中
                mailMessage.Attachments.Add(attachment);
            }
            // 发送写好的邮件
            int port = 25;
            int i = 0, j = 0;
            foreach (char a in myMail.Text)
            {
                i++;
                if (a == '@') break;
            }
            foreach (char a in myMail.Text)
            {
                j++;
                if (a == '.') break;
            }
            string servername = myMail.Text.Substring(i, j - i - 1);
            if ((servername == "live") || (servername == "gmail") || (servername == "yahoo")) port = 587;
            SmtpClient smtpClient = new SmtpClient(smtpserver.Text, port)
            {
                Credentials = new System.Net.NetworkCredential(myMail.Text, passwd.Text),//smtp用户名密码
                EnableSsl = true //启用ssl
            }; //smtp地址以及端口号
            try
            {
                smtpClient.Send(mailMessage);
                status.Text = "邮件发送成功！";
                MsgBox.Text += DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "\r\n";
                if ((InputBox.Text != null) || (InputBox.Text.Length != 0))
                {
                    MsgBox.Text += "我：" + InputBox.Text + "\r\n";
                    string realmsg = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n我：" + InputBox.Text;
                    SaveMessage(fr.Name, AESEncrypt(realmsg, fr.Key, fr.iv) + "\r\n");
                }
                if (annex != null)
                {
                    MsgBox.Text += "已发送附件：" + annex + "\r\n";
                    string realmsg = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n我：已发送附件：" + annex;
                    SaveMessage(fr.Name, AESEncrypt(realmsg, fr.Key, fr.iv) + "\r\n");
                }
                MsgBox.ScrollToCaret();
                InputBox.Text = null;
                annex = null;
                AddAnnex.Text = "添加附件";
            }
            catch (SmtpException smtpError)
            {
                MessageBox.Show("邮件发送失败：[" + smtpError.StatusCode + "]；[" + smtpError.Message + "];\r\n[" + smtpError.StackTrace + "].", "错误", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            finally
            {
                mailMessage.Dispose();
                this.Cursor = Cursors.Default;
            }
            return;
        }//发送邮件

        private void AddAnnex_Click(object sender, EventArgs e)
        {
            if (annex != null)
            {
                AddAnnex.Text = "添加附件";
                status.Text = "已取消附件：" + annex;
                annex = null;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                // 只接受有效的文件名
                ValidateNames = true,
                Multiselect = false,
                Filter = "所有文件(*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (openFileDialog.FileName.Length > 0)
            {
                annex = openFileDialog.FileName.ToString();
                status.Text = "已添加附件：" + annex;
                AddAnnex.Text = "删除附件";
            }
        }//发送附件

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("config.ini")) File.Create("config.ini");
            string[] array = File.ReadAllLines("config.ini");
            if ((array.Length < 1) || (array[0].Length < 20)) WriteFile("config.ini", 1, "这是Encryp2tMail的配置文件,不要更改此文件。");
            if ((array.Length < 2) || (array[1].Length < 16))//检查向量是否存在
            {
                piv = GetRandomString(16);
                WriteFile("config.ini", 2, piv);
            }
            else piv = array[1];
            if ((array.Length < 3) || (array[2].Length < 43))
            {
                Form3 fm = new Form3();
                fm.ShowDialog();
                pkey = Form3.setPasswd;
                if (pkey.Length < 16)
                    pkey += piv.Substring(8, 16 - pkey.Length);
                WriteFile("config.ini", 3, AESEncrypt("This is the Password check file.", pkey, piv));
            }
            bool j = false;
            for (int i=3; i > 0; i--)
            {
                j = CheckPwd();
                if (j) break;
                MessageBox.Show("密码错误！\r\n还剩" + (i-1).ToString() + "次机会。");
            }
            if (!j)
            {
                File.Delete("config.ini");
                File.Delete("friendlist.ini");
                File.Create("config.ini");
                DelectDir(@".\message\");
                DelectDir(@".\download\");
                string x = GetRandomString(16);
                WriteFile("config.ini", 1, "这是EncryptMail的配置文件,不要更改此文件。");
                WriteFile("config.ini", 2, x);
                this.Close();
            }
            myMail.Text = AESDecrypt(ReadFile("config.ini", 4), pkey, piv);
            passwd.Text = AESDecrypt(ReadFile("config.ini", 5), pkey, piv); ;
            smtpserver.Text = AESDecrypt(ReadFile("config.ini", 6), pkey, piv); 
            imapserver.Text = AESDecrypt(ReadFile("config.ini", 7), pkey, piv);
            if ((imapserver.Text == null)||(imapserver.TextLength<=8))
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                return;
            }
            try
            {
                string[] array2 = File.ReadAllLines("friendlist.ini");
                string n;
                foreach (string m in array2)
                {
                    n = AESDecrypt(m, pkey, piv);
                    if ((n == null) || (n.Length < 55)) break;
                    Friend f1 = new Friend(n.Substring(52), n.Substring(20, 32), ToShort(n.Substring(0, 20), "*"));
                    Friends.Add(f1);
                    FriendList.Items.Add(f1.Name);
                }
            }
            catch
            {
                File.Create("friendlist.ini");
            }
            return;

        }//加载配置文件和好友列表。

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadMessages(imapserver.Text, myMail.Text, passwd.Text);
            return;
        }//接收消息

        private void FriendList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FriendList.SelectedItem==null) return;
            MsgBox.Text = null;
            string name = FriendList.SelectedItem.ToString();
            CurrentFriend.Text = name;
            Friend fr = Friends.Find(item => item.Name.Equals(name));
            if (!File.Exists(@".\message\" + fr.Name + ".dat"))
            {
                status.Text = "没有找到你与" + fr.Name + "的聊天记录。";
                return;
            }
            string[] array = File.ReadAllLines(@".\message\" + fr.Name + ".dat");
            if (array.Length == 0)
            {
                status.Text = "没有找到你与" + fr.Name + "的聊天记录。";
                return;
            }
            foreach (string msg in array)
            {
                string realmsg = AESDecrypt(msg, fr.Key, fr.iv);

                MsgBox.Text += realmsg;
                MsgBox.Text += "\r\n";
                status.Text = "邮件刷新成功！";
            }
        }//选中好友列表中某项之后的动作

        private void AddFriend_Click(object sender, EventArgs e)
        {
            Form4 fm = new Form4();
            fm.ShowDialog();
            if ((Form4.Mail == null) || (Form4.Passwd == null)) return;
            Friend f1 = new Friend(Form4.Mail, Form4.Passwd, null);
            Friends.Add(f1);
            string mail = Form4.Mail;
            string m = ToLong(f1.Name, 20, '*');
            string n = AESEncrypt(m + Form4.Passwd + mail, pkey, piv);
            string[] x = new string[1];
            x[0] = n;
            File.AppendAllLines("friendlist.ini",x);
            FriendList.Items.Add(f1.Name);
            return;
        }//添加朋友

        public void DownloadMessages(string imapserver,string username,string password)
        {
            int numofmail = 0, numofatt = 0;
            var client = new ImapClient();
            client.Connect(imapserver, 993, SecureSocketOptions.SslOnConnect);
            if (!client.IsConnected)
            {
                status.Text = "错误：无法连接服务器！";
                return;
            }
            client.Authenticate(username, password);
            if (!client.IsAuthenticated)
            {
                status.Text = "错误：登录失败，请检查邮箱地址和密码！";
                return;
            }
            client.Inbox.Open(FolderAccess.ReadWrite);
            var uids = client.Inbox.Search((SearchQuery.NotSeen).And(SearchQuery.SubjectContains("EncryptMail")));
            foreach (var uid in uids)
            {
                var message = client.Inbox.GetMessage(uid);
                if (message.Subject != "EncryptMail") continue;
                string i = message.From.Mailboxes.First().Address;
                string txt = ToShort(message.TextBody, "\r\n");
                Friend fr = Friends.Find(item => item.Mailaddress.Equals(i));
                string realmsg = null;
                try
                {
                   realmsg = AESDecrypt(txt, fr.Key, fr.iv);
                }
                catch 
                {
                    status.Text = "发生异常：邮件解密失败！";
                    continue;
                }
                client.Inbox.AddFlags(uid, MessageFlags.Seen, true);
                if (realmsg.Substring(0,11)=="$$Command$$")
                {
                    MailCommand(fr, realmsg.Substring(12));
                    continue;
                }//检测开头字母，如果是命令，则跳转到MailCommand
                string y = message.Date.DateTime.ToString() + "\r\n对方：" + realmsg;
                SaveMessage(fr.Name, AESEncrypt(y, fr.Key, fr.iv) + "\r\n");
                numofmail++;
                if (message.Attachments.Count() == 0) continue;
                foreach (var attachment in message.Attachments)
                {
                    string fileName = @".\download\" + attachment.ContentDisposition.FileName;
                    FileStream stream = File.Create(fileName) ;
                    if (attachment is MimeKit.MessagePart)
                    {
                        var rfc822 = (MimeKit.MessagePart)attachment;
                        rfc822.Message.WriteTo(stream);
                    }
                    else
                    {
                        var part = (MimeKit.MimePart)attachment;
                        part.Content.DecodeTo(stream);
                    }
                    numofatt++;
                }
            }
            client.Disconnect(true);
            client.Dispose();
            status.Text = "收信完毕，共收到：" + numofmail.ToString() + "封邮件," + numofatt.ToString() + "封附件。";
            return;
        }//接收消息、附件

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("HH:mm:ss");
            return;
        }//时钟

        private void timer2_Tick(object sender, EventArgs e)
        {
            DownloadMessages(imapserver.Text, myMail.Text, passwd.Text);
            return;
        }//自动刷新消息

        private void 删除好友ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (FriendList.SelectedItem == null) return;
            string cntfriend = FriendList.SelectedItem.ToString();
            FriendList.Items.Remove(FriendList.SelectedItem);
            //移除FriendList中对应项
            Friend fri = null;
            fri = Friends.Find(item => item.Name.Equals(cntfriend));
            Friends.Remove(fri);
            //移除List项目Friends中对应项
            if (Friends.Count() > 0)
            {
                int i = 0;
                string[] array = new string[Friends.Count()];
                foreach (Friend fr in Friends)
                {
                    array[i] = AESEncrypt(ToLong(fr.Name, 20, '*') + fr.Key + fr.iv + fr.Mailaddress, pkey, piv);
                    i++;
                }
                File.WriteAllLines("friendlist.ini", array);
            }
            else File.WriteAllText("friendlist.ini", null);
            //把剩余项写回friendlist.ini
            File.Delete(@".\message\" + cntfriend + ".dat");
            //删除对应消息记录
            return;
        }//删除好友

        private void 清空消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FriendList.SelectedItem == null) return;
            File.Delete(@".\message\" + FriendList.SelectedItem + ".dat");
            return;
        }//清空消息

        private void 修改昵称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FriendList.SelectedItem == null) return;
            Form5 fm = new Form5();
            fm.ShowDialog();
            string nickname = Form5.nickname;
            if (nickname == null) return;
            string oldname = FriendList.SelectedItem.ToString();
            int k = FriendList.SelectedIndex;
            FriendList.Items.Remove(FriendList.SelectedItem);
            FriendList.Items.Insert(k, nickname);//移除friendlist中的对应项
            CurrentFriend.Text = nickname;//正在聊天重命名
            Friend fr = null;
            fr = Friends.Find(item => item.Name.Equals(oldname));
            Friend newname = new Friend(fr.Mailaddress, fr.Key + fr.iv, nickname);
            Friends.Remove(fr);
            Friends.Add(newname);//Friends集合重命名
            if(File.Exists(@".\message" + fr.Name + ".dat"))
            {
                FileInfo fi1 = new FileInfo(@".\message" + fr.Name + ".dat");
                fi1.MoveTo(@".\message" + newname.Name + ".dat");
            }//聊天记录重命名
            string[] array = File.ReadAllLines("friendlist.ini");
            int i = 0;
            foreach(string a in array)
            {
                if (oldname == ToShort(AESDecrypt(a, pkey, piv).Substring(0, 20), "*")) break;
                i++;
            }
            WriteFile("friendlist.ini", i + 1, AESEncrypt(ToLong(newname.Name,20,'*')+newname.Key+newname.iv+newname.Mailaddress,pkey,piv));//修改friendlist.ini文件
            return;
        }//修改昵称

        private void FriendList_MouseMove(object sender, MouseEventArgs e)
        {
            System.Drawing.Point point = FriendList.PointToClient(Cursor.Position);
            int index = FriendList.IndexFromPoint(point);
            if (index < 0) return;
            FriendList.SelectedIndex = index;
            return;
        }//动态选中FriendList中的项

        private void 更改密钥ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FriendList.SelectedItem == null) return;
            string newkeyword = GetRandomString(32);
            string name = FriendList.SelectedItem.ToString();
            Friend fr = null;
            fr = Friends.Find(item => item.Name.Equals(name));
            Friend fr2 = new Friend(fr.Mailaddress, newkeyword, fr.Name);
            SendCommand(fr, "Change Password" + newkeyword);//向对方发送重置命令
            Friends.Remove(fr);
            Friends.Add(fr2);//修改List中的密码
            File.Delete(@".\message\" + fr2.Name + ".dat");//删除旧消息
            string[] array = File.ReadAllLines("friendlist.ini");
            int i = 0;
            foreach (string str in array)
            {
                string m = AESDecrypt(str, pkey, piv);
                if (ToShort(m.Substring(0, 20), "*") == fr2.Name) break;
                i++;
            }
            array[i] = AESEncrypt(ToLong(fr2.Name, 20, '*') + fr2.Key + fr2.iv + fr2.Mailaddress, pkey, piv);
            File.WriteAllLines("friendlist.ini", array);//更改friendlist.ini文件
        }

        private void 关于EncryptMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About fm = new About();
            fm.Show();
            return;
        }
    }

    class Friend
    {
        private string _name;
        private string _Key;
        private string _iv;
        private string _mailaddress;
        public Friend(string Mailaddress, string KeyandIV,string Name)
        {
            this._mailaddress = Mailaddress;
            this._Key = KeyandIV.Substring(0, 16);
            this._iv= KeyandIV.Substring(16, 16);
            if (Name == null)
            {
                int i = 0;
                foreach (char a in Mailaddress)
                {
                    if (a == '@') break;
                    i++;
                }
                this._name = Mailaddress.Substring(0, i);
            }
            else this._name = Name;
        }
        public string Mailaddress
        {
            get { return _mailaddress; }
        }
        public string Name
        {
            get { return _name; }
        }
        public string Key
        {
            get { return _Key; }
        }
        public string iv
        {
            get { return _iv; }
        }
    }
}
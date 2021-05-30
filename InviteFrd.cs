using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EncryptMail
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public static string Mail = null;
        public static string Passwd = null;
        public static string GetRandomString(int length)
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

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Cyan;
            button2.BackColor = Color.Gainsboro;
            passwd.Text = GetRandomString(32);
            status.Text = "请将生成的密钥告知好友！";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Cyan;
            button1.BackColor = Color.Gainsboro;
            status.Text = "请输入好友提供的密钥！";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (passwd.Text == null)
            {
                status.Text = "请输入密钥！"; 
                return;
            }
            if (mail.Text == null)
            {
                status.Text = "请输入好友邮箱！";
                return;
            }
            if (passwd.TextLength < 32)
            {
                status.Text = "请检查密钥！";
                return;
            }
            Mail = mail.Text;
            Passwd = passwd.Text;
            Close();
            return;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 加密邮箱
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public static string nickname = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0) return;
            if(textBox1.TextLength>20)
            {
                MessageBox.Show("昵称长度不能大于20位！");
                return;
            }
            nickname = textBox1.Text;
            this.Close();
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }
    }
}

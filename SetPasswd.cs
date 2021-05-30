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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public static string setPasswd;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null) setPasswd = this.textBox1.Text;
            this.Close();
            return;
        }
    }
}

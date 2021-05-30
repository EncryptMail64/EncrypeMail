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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public static string passwd = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != null)
                passwd = textBox1.Text;
            this.Close();
            return;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }
    }
}

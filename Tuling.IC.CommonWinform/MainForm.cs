using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tuling.IC.CommonWinform
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示文本框内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Text, "提示");
        }
    }
}

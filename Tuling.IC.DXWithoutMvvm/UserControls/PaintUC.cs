using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tuling.IC.DXWithoutMvvm.UserControls
{
    public partial class PaintUC : DevExpress.XtraEditors.XtraUserControl
    {
        public PaintUC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// GDI 绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelControl1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var pen = new Pen(Color.Blue);

            //绘制一个宽 100 ,高 50 的矩形
            g.DrawRectangle(pen, new Rectangle(0, 0, 100, 50));

            //绘制一个半径为50的圆形
            int centerX = 100 + 50;
            int centerY = 50;
            g.DrawEllipse(pen, new Rectangle(centerX - 50, centerY - 50, 100, 100));

            //释放画笔资源
            pen.Dispose();
        }
    }
}

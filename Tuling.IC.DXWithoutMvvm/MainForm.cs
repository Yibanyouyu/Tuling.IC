using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tuling.IC.DXWithoutMvvm.UserControls;

namespace Tuling.IC.DXWithoutMvvm
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 分页日志控件
        /// </summary>
        private PageLogUC pageLogUC;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 更新UI
        /// </summary>
        /// <param name="action">更新操作</param>
        private void UpdateUI(Action action)
        {
            if (IsHandleCreated)
            {
                Invoke(action);
            }
        }

        /// <summary>
        /// 窗体加载后订阅事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            multiRefreshUC1.TransformRandomAction += (randomNumber) =>
            {
                UpdateUI(() =>
                {
                    labelControlTransform.Text = randomNumber;
                });
            };
        }

        /// <summary>
        /// 多线程刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            multiRefreshUC1.ToggleUpdateByRandom();
        }

        /// <summary>
        /// 显示分页日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            if (pageLogUC == null)
            {
                pageLogUC = new PageLogUC();
            }

            pageLogUC.Dock = DockStyle.Fill;
            panelControlMain.Controls.Clear();
            panelControlMain.Controls.Add(pageLogUC);
        }
    }
}

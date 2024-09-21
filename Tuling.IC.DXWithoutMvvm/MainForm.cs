using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        /// <summary>
        /// GDI 绘制控件
        /// </summary>
        private PaintUC paintUC;
        /// <summary>
        /// Python 调用
        /// </summary>
        private ForPythonUC forPythonUC;

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

        /// <summary>
        /// GDI 绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleButton3_Click(object sender, EventArgs e)
        {
            if (paintUC == null)
            {
                paintUC = new PaintUC();
            }

            paintUC.Dock = DockStyle.Fill;
            panelControlMain.Controls.Clear();
            panelControlMain.Controls.Add(paintUC);
        }

        /// <summary>
        /// Python 调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleButton4_Click(object sender, EventArgs e)
        {
            if (forPythonUC == null)
            {
                forPythonUC = new ForPythonUC();
            }

            forPythonUC.Dock = DockStyle.Fill;
            panelControlMain.Controls.Clear();
            panelControlMain.Controls.Add(forPythonUC);
        }

        /// <summary>
        /// 代码生成器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleButton5_Click(object sender, EventArgs e)
        {
            string templatePath = $"{AppDomain.CurrentDomain.BaseDirectory}Templates\\Program.template";
            string outputPath = "CodeGenerate\\Program.cs";
            string namespaceToReplace = "{Tuling.IC.DXWithoutMvvm}";
            string newNamespace = "Tuling.IC.DXWithoutMvvm.CodeGenerate";

            if (!File.Exists(templatePath))
            {
                MessageBox.Show("模板文件不存在！", "提示");
                return;
            }

            string content = File.ReadAllText(templatePath);
            content = content.Replace(namespaceToReplace, newNamespace);

            if (!Directory.Exists("CodeGenerate"))
            {
                Directory.CreateDirectory("CodeGenerate");
            }
            File.WriteAllText(outputPath, content);

            MessageBox.Show($"代码生成成功！位置：{outputPath}", "提示");
        }
    }
}

using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
            barStaticItem1.Caption = $"{Application.ProductName} 版本: V{Application.ProductVersion}";

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

        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleButton6_Click(object sender, EventArgs e)
        {
            AutoUpdater.Start("http://hongxianji.com/basictool/update.xml");
            // 若您不想在更新表单上显示“跳过”按钮，那个么只需在上面的代码中添加以下行即可。
            AutoUpdater.ShowSkipButton = false;

            // 如果要同步检查更新，请在启动更新之前将 Synchronous 设置为 true，如下所示。
            AutoUpdater.Synchronous = false;

            // 显示“以后提醒”按钮，那个么只需在上面的代码中添加以下一行即可。
            AutoUpdater.ShowRemindLaterButton = true;

            //如果要忽略先前设置的“以后提醒”和“跳过”设置，则可以将“强制”属性设置为 true。
            //它还将隐藏“跳过”和“稍后提醒”按钮。如果在代码中将强制设置为true，那么XML文件中的强制值将被忽略。
            AutoUpdater.Mandatory = false;

            //您可以通过添加以下代码来打开错误报告。如果执行此自动更新程序。NET 将显示错误消息，如果没有可用的更新或无法从 web 服务器获取 XML 文件。
            AutoUpdater.ReportErrors = true;

            // 如果服务器 xml 文件的版本大于 AssemblyInfo 中的版本则触发 CheckForUpdateEvent
            AutoUpdater.CheckForUpdateEvent += (args) =>
            {
                if (args.Error == null)
                {
                    // 检测到有可用的更新
                    if (args.IsUpdateAvailable)
                    {
                        DialogResult dialogResult;
                        if (args.Mandatory.Value)
                        {
                            dialogResult = MessageBox.Show($"当前有一个新版本{args.CurrentVersion}可用.你正在使用版本{args.InstalledVersion}.点击确认开始更新", "更新可用", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dialogResult =
                                MessageBox.Show($"当前有一个新版本{args.CurrentVersion}可用.你正在使用版本{args.InstalledVersion}.确认要更新吗?", "更新可用", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        }

                        if (dialogResult.Equals(DialogResult.Yes) || dialogResult.Equals(DialogResult.OK))
                        {
                            try
                            {
                                // 触发更新下载
                                if (AutoUpdater.DownloadUpdate(args))
                                {
                                    Application.Exit();
                                }
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                //更新错误
                else
                {
                    if (args.Error is WebException)
                    {
                        MessageBox.Show("连接更新服务器失败,请检查网络连接！", "更新检查失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(args.Error.Message, args.Error.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

        }
    }
}

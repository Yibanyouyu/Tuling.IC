using DevExpress.XtraEditors;
using Masuit.Tools;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tuling.IC.DXWithoutMvvm.UserControls
{
    public partial class ForPythonUC : DevExpress.XtraEditors.XtraUserControl
    {
        public ForPythonUC()
        {
            InitializeComponent();
        }

        private void ForPythonUC_Load(object sender, EventArgs e)
        {
            LoadPythgonEnv();
        }

        /// <summary>
        /// 加载 Python 环境
        /// </summary>
        private void LoadPythgonEnv()
        {
            var pythonEnv = "D:\\Anaconda3\\envs\\ForPython";
            var scriptPath = AppDomain.CurrentDomain.BaseDirectory + "Scripts";

            Runtime.PythonDLL = Path.Combine(pythonEnv, "python38.dll");
            PythonEngine.PythonHome = pythonEnv;
            PythonEngine.PythonPath = $"{pythonEnv}\\Lib\\site-packages;{pythonEnv}\\Lib;{pythonEnv}\\DLLs;{scriptPath}";

            //初始化 Python 环境
            PythonEngine.Initialize();
        }

        /// <summary>
        /// Hello
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleButtonHello_Click(object sender, EventArgs e)
        {
            try
            {
                using (Py.GIL())
                {
                    dynamic py = Py.Import("hello");

                    dynamic result = py.hello();

                    memoEdit1.Text = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 两数之和
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleButtonSum_Click(object sender, EventArgs e)
        {
            try
            {
                //double.TryParse(textEditNumber1.Text.Trim(), out double number1);
                //double.TryParse(textEditNumber2.Text.Trim(), out double number2);
                //使用 Masuit.Tools.Net 工具库格式化值
                var number1 = textEditNumber1.Text.Trim().ToDouble();
                var number2 = textEditNumber2.Text.Trim().ToDouble();

                using (Py.GIL())
                {
                    dynamic py = Py.Import("hello");

                    dynamic result = py.add(number1, number2);

                    memoEdit1.Text = $"{number1} + {number2} = {result}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 调用 Numpy 包
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleButtonNumpy_Click(object sender, EventArgs e)
        {
            try
            {
                using (Py.GIL())
                {
                    dynamic np = Py.Import("numpy");
                    dynamic result = np.cos(np.pi * 2);
                    memoEdit1.Text = $"{result}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

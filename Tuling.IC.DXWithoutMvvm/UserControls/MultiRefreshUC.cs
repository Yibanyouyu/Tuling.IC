using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tuling.IC.DXWithoutMvvm.UserControls
{
    public partial class MultiRefreshUC : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 是否开始刷新
        /// </summary>
        private bool _start;
        /// <summary>
        /// 随机刷新线程
        /// </summary>
        private Thread _randomThread;
        /// <summary>
        /// 取消令牌
        /// </summary>
        private CancellationTokenSource _cts;
        /// <summary>
        /// 随机数刷新
        /// </summary>
        public Action<string> TransformRandomAction;

        public MultiRefreshUC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 随机更新 UI 数据
        /// </summary>
        public void ToggleUpdateByRandom()
        {
            _start = !_start;

            //开始刷新
            if (_start)
            {
                if (_cts == null)
                {
                    _cts = new CancellationTokenSource();
                }

                GenerateRandomByThread();
                GenerateRandomByTask();
            }
            //停止刷新
            else
            {
                //使用 CancellationToken 方式关闭线程运行，Thread.Abort() 方式已不推荐
                //_randomThread?.Abort();

                _cts.Cancel();
                _cts = null;

                TransformRandomAction("已停止数据同步");
            }
        }

        /// <summary>
        /// 通过 Thread 刷新
        /// </summary>
        private void GenerateRandomByThread()
        {
            if (_randomThread == null)
            {
                _randomThread = new Thread(() =>
                {
                    while (_start && !_cts.IsCancellationRequested)
                    {
                        var randomNumber = new Random().Next(1, 500).ToString();

                        //直接更新数据会导致线程上下文不同步，无法更新异常
                        UpdateUI(() =>
                        {
                            textEditThread.Text = randomNumber;
                            TransformRandomAction?.Invoke(randomNumber);
                        });

                        Thread.Sleep(500);
                    }
                });
            }

            _randomThread.Start();
        }

        /// <summary>
        /// 通过 Task 刷新
        /// </summary>
        private void GenerateRandomByTask()
        {
            Task.Run(async () =>
            {
                while (_start && !_cts.IsCancellationRequested)
                {
                    var randomNumber = new Random().Next(1, 1000).ToString();

                    //直接更新数据会导致线程上下文不同步，无法更新异常
                    UpdateUI(() =>
                    {
                        textEditTask.Text = randomNumber;
                    });

                    await Task.Delay(500);
                }
            }, _cts.Token);
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
    }
}

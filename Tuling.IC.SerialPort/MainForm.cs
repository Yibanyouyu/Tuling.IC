using DevExpress.Utils.Extensions;
using Masuit.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tuling.IC.SerialPort.Helper;

namespace Tuling.IC.SerialPort
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 串口是否打开
        /// </summary>
        private bool _isOpen = false;
        /// <summary>
        /// 保存文件路径
        /// </summary>
        private string _saveFilePath;
        /// <summary>
        /// 保存文件令牌
        /// </summary>
        private CancellationTokenSource _saveFileCts;
        /// <summary>
        /// 循环发送令牌
        /// </summary>
        private CancellationTokenSource _cycleSendCts;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitData();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            comboBoxEditBaud.Properties.Items.AddRange(Faker.GetBauds());
            comboBoxEditParity.Properties.Items.AddRange(Enum.GetValues(typeof(Parity)));
            comboBoxEditDataBit.Properties.Items.AddRange(Faker.GetDataBits());
            comboBoxEditStopBit.Properties.Items.AddRange(Enum.GetValues(typeof(StopBits)));
            comboBoxEditBaud.SelectedIndex = 6;
            comboBoxEditParity.SelectedIndex = 0;
            comboBoxEditDataBit.SelectedIndex = 0;
            comboBoxEditStopBit.SelectedIndex = 0;

            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            comboBoxEditPort.Properties.Items.AddRange(ports);
            comboBoxEditPort.SelectedIndex = ports.Length > 0 ? 0 : -1;
            simpleButtonOpen.Enabled = ports.Length > 0;
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleButtonOpen_Click(object sender, EventArgs e)
        {
            if (_isOpen)
            {
                serialPort1?.Close();
                ChangeComboxEnable(true);
                simpleButtonOpen.Text = "打开";
                memoEditLog.AppendText("连接关闭".FormatStringLog());
                _isOpen = false;
            }
            else
            {
                try
                {
                    serialPort1.PortName = comboBoxEditPort.Text; //串口号
                    serialPort1.BaudRate = comboBoxEditBaud.Text.ToInt32(); //波特率
                    serialPort1.DataBits = comboBoxEditDataBit.Text.ToInt32(); //数据位
                    //校验位
                    if (Enum.TryParse(comboBoxEditParity.Text, out Parity parity))
                    {
                        if (parity != Parity.None) serialPort1.Parity = parity;
                    }
                    //停止位
                    if (Enum.TryParse(comboBoxEditStopBit.Text, out StopBits stopBits))
                    {
                        if (stopBits != StopBits.None) serialPort1.StopBits = stopBits;
                    }

                    serialPort1?.Open();
                    ChangeComboxEnable(false);
                    simpleButtonOpen.Text = "关闭";
                    memoEditLog.AppendText("连接打开".FormatStringLog());
                    _isOpen = true;
                }
                catch (Exception ex)
                {
                    simpleButtonOpen.Text = "打开";
                    memoEditLog.AppendText(ex.Message.FormatStringLog());
                    _isOpen = false;
                }
            }
        }

        /// <summary>
        /// 启用或关闭串口设置下拉框、发送按钮
        /// </summary>
        /// <param name="enable"></param>
        private void ChangeComboxEnable(bool enable)
        {
            comboBoxEditPort.Enabled = enable;
            comboBoxEditBaud.Enabled = enable;
            comboBoxEditParity.Enabled = enable;
            comboBoxEditDataBit.Enabled = enable;
            comboBoxEditStopBit.Enabled = enable;

            simpleButtonSend.Enabled = !enable;
        }

        /// <summary>
        /// 日志模式显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckEditRecLog_CheckedChanged(object sender, EventArgs e)
        {
            StringExtension.isCheckEditRecLog = checkEditRecLog.Checked;
        }

        /// <summary>
        /// 串口数据接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //获取数据长度
            var length = serialPort1.BytesToRead;
            //建立缓冲
            var buffer = new byte[length];
            //读取数据
            serialPort1.Read(buffer, 0, length);
            //转为简洁的数据消息
            string msg = Encoding.UTF8.GetString(buffer);

            //追加数据消息到数据消息中
            Invoke(new Action(() =>
            {
                //hex显示
                if (checkEditRecHex.Checked)
                    memoEditLog.AppendText(string.Join(" ", buffer.Select(x => x.ToString("X2")).ToArray()).FormatStringLog());
                //ASCII显示
                else
                    memoEditLog.AppendText(msg.FormatStringLog());
            }));
        }

        /// <summary>
        /// 串口发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleButtonSend_Click(object sender, EventArgs e)
        {
            SendAndLog();
        }

        /// <summary>
        /// 字符串转 16 进制 byte 数组
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private byte[] String2HexByte(string msg)
        {
            List<byte> bytes = new List<byte>();

            for (int i = 0; i < msg.Length; i += 2)
            {
                string hexPair = msg.Substring(i, Math.Min(2, msg.Length - i));

                hexPair = hexPair.PadLeft(2, '0');

                bytes.Add(Convert.ToByte(hexPair, 16));
            }

            return bytes.ToArray();
        }

        /// <summary>
        /// 检测设备状态,检测串口插入拔出
        /// </summary>
        /// <param name="msg"></param>
        protected override void WndProc(ref Message msg)
        {
            //设备改变
            if (msg.Msg == 0x219)
            {
                //设备已拔出
                if (msg.WParam.ToInt32() == 0x8004)
                {
                    memoEditLog.AppendText("设备已拔出!".FormatStringLog());
                }
                //设备已插入
                else if (msg.WParam.ToInt32() == 0x8000)
                {
                    memoEditLog.AppendText("设备已插入!".FormatStringLog());
                }

                string[] ports = System.IO.Ports.SerialPort.GetPortNames();

                comboBoxEditPort.Properties.Items.Clear();
                comboBoxEditPort.Properties.Items.AddRange(ports);

                simpleButtonOpen.Enabled = ports.Length > 0;
                if (ports.Length == 0) comboBoxEditPort.Text = "";

                //处理串口连接状态
                if (_isOpen)
                {
                    if (!ports.Contains(comboBoxEditPort.Text))
                    {
                        //释放串口资源
                        serialPort1?.Close();
                        serialPort1?.Dispose();

                        ChangeComboxEnable(true);
                        simpleButtonOpen.Text = "打开";
                        comboBoxEditPort.SelectedIndex = comboBoxEditPort.Properties.Items.Count > 0 ? 0 : -1;
                    }
                    else
                    {
                        comboBoxEditPort.SelectedIndex = comboBoxEditPort.Properties.Items.IndexOf(comboBoxEditPort.Text);
                    }
                }
                else
                {
                    comboBoxEditPort.SelectedIndex = comboBoxEditPort.Properties.Items.Count > 0 ? 0 : -1;
                }

                ChangeMemoEditToEnd();
            }

            base.WndProc(ref msg);
        }

        /// <summary>
        /// 滚动数据日志到最后一行
        /// </summary>
        private void ChangeMemoEditToEnd()
        {
            if (checkEditRecAuto.Checked)
            {
                memoEditLog.SelectionStart = memoEditLog.Text.Length;
                memoEditLog.ScrollToCaret();
            }
        }

        /// <summary>
        /// 接收保存到文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckEditRecSave_CheckedChanged(object sender, EventArgs e)
        {
            //保存文件
            if (checkEditRecSave.Checked)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.DefaultExt = "txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _saveFileCts = new CancellationTokenSource();
                    _saveFilePath = saveFileDialog.FileName;

                    //保存文件任务
                    Task.Run(async () =>
                    {
                        while (_saveFileCts != null && !_saveFileCts.IsCancellationRequested)
                        {
                            if (!string.IsNullOrWhiteSpace(_saveFilePath))
                            {
                                string logs = memoEditLog.Text;
                                File.WriteAllText(_saveFilePath, logs);
                            }

                            await Task.Delay(1000 * 5);
                        }
                    }, _saveFileCts.Token);
                }
            }
            //取消保存到文件
            else
            {
                _saveFileCts?.Cancel();
                _saveFileCts?.Dispose();
                _saveFileCts = null;

                _saveFilePath = string.Empty;
            }
        }

        /// <summary>
        /// 循环发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckEditSendCycle_CheckedChanged(object sender, EventArgs e)
        {
            //循环发送
            if (checkEditSendCycle.Checked)
            {
                int cycle = textEditSendCycle.Text.ToInt32();
                if (cycle > 0)
                {
                    textEditSendCycle.Enabled = false;
                    _cycleSendCts = new CancellationTokenSource();

                    //循环发送任务
                    Task.Run(async () =>
                    {
                        while (_cycleSendCts != null && !_cycleSendCts.IsCancellationRequested)
                        {
                            SendAndLog();

                            await Task.Delay(cycle);
                        }
                    }, _cycleSendCts.Token);
                }
            }
            //取消循环发送
            else
            {
                _cycleSendCts?.Cancel();
                _cycleSendCts?.Dispose();
                _cycleSendCts = null;

                textEditSendCycle.Enabled = true;
            }
        }

        /// <summary>
        /// 发送并记录日志
        /// </summary>
        private void SendAndLog()
        {
            var msg = memoEditSendLog.Text;
            if (msg.Length > 0)
            {
                Invoke(new Action(() =>
                {
                    if (checkEditSendHex.Checked)
                    {
                        byte[] buffer = String2HexByte(msg);
                        memoEditLog.AppendText(string.Join(" ", buffer.Select(x => x.ToString("X2")).ToArray()).FormatStringLog());
                        serialPort1.Write(buffer, 0, buffer.Length);
                    }
                    else
                    {
                        memoEditLog.AppendText(msg.FormatStringLog());
                        serialPort1.Write(msg);
                    }
                }));
            }
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleButtonClear_Click(object sender, EventArgs e)
        {
            memoEditLog.Text = "";
        }
    }
}

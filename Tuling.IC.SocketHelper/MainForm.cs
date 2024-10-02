using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
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
using TouchSocket.Core;
using TouchSocket.Sockets;
using Tuling.IC.SocketHelper.Enums;
using Tuling.IC.SocketHelper.Helper;

namespace Tuling.IC.SocketHelper
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// UDP 连接
        /// </summary>
        private UdpSession _udpSession = new UdpSession();
        /// <summary>
        /// TCP 客户端
        /// </summary>
        private TcpClient _tcpClient = new TcpClient();
        /// <summary>
        /// TCP 服务端
        /// </summary>
        private TcpService _tcpService = new TcpService();
        /// <summary>
        /// 网络协议是否打开
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
            comboBoxEditType.Properties.Items.Clear();
            comboBoxEditType.Properties.Items.AddRange(Faker.GetProtocolTypes());
            comboBoxEditIP.Properties.Items.Clear();
            comboBoxEditIP.Properties.Items.AddRange(Faker.GetIPs());

            comboBoxEditType.SelectedIndex = 0;
            comboBoxEditIP.SelectedIndex = 0;
        }

        /// <summary>
        /// 打开关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SimpleButtonOpen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comboBoxEditType.Text) && !string.IsNullOrWhiteSpace(comboBoxEditIP.Text) && !string.IsNullOrWhiteSpace(textEditPort.Text))
            {
                try
                {
                    string protocol = comboBoxEditType.Text;
                    string ip = comboBoxEditIP.Text;
                    string port = textEditPort.Text;

                    EProtocolType protocolType = EnumHelper.GetEnumFromDesciption<EProtocolType>(protocol);
                    if (protocolType == EProtocolType.UDP)
                    {
                        XtraMessageBox.Show("暂未实现", "提示");
                        //await StartOrStopUDP(ip, port);
                    }
                    else if (protocolType == EProtocolType.TCPClient)
                    {
                        await StartOrStopTCPClient(ip, port);
                    }
                    else if (protocolType == EProtocolType.TCPServer)
                    {
                        await StartOrStopTCPServer(ip, port);
                    }
                }
                catch (Exception ex)
                {
                    memoEditLog.AppendText(ex.Message.FormatStringLog());
                }
            }
            else
            {
                XtraMessageBox.Show("请先选择协议类型、IP 地址并输入端口！", "提示");
            }
        }

        /// <summary>
        /// 开启或关闭 UDP
        /// </summary>
        /// <param name="ip">IP</param>
        /// <param name="port">端口</param>
        private async Task StartOrStopUDP(string ip, string port)
        {

        }

        /// <summary>
        /// 开启或关闭 TCP Client
        /// </summary>
        /// <param name="ip">IP</param>
        /// <param name="port">端口</param>
        private async Task StartOrStopTCPClient(string ip, string port)
        {
            if (_isOpen)
            {
                _tcpClient?.Close();
                ChangeComboxEnable(true);
                simpleButtonOpen.Text = "打开";
                memoEditLog.AppendText("TCP 已断开连接".FormatStringLog());
                _isOpen = false;
            }
            else
            {
                _tcpClient?.Close();

                _tcpClient.Connecting = (client, e) =>
                {
                    Invoke(new Action(() =>
                    {
                        memoEditLog.AppendText($"{client.IP}:{client.Port}正在连接服务器...".FormatStringLog());
                    }));
                    return EasyTask.CompletedTask;
                };
                _tcpClient.Connected = (client, e) =>
                {
                    Invoke(new Action(() =>
                    {
                        memoEditLog.AppendText($"{client.IP}:{client.Port}连接成功".FormatStringLog());
                    }));
                    return EasyTask.CompletedTask;
                };
                _tcpClient.Closing = (client, e) =>
                {
                    Invoke(new Action(() =>
                    {
                        memoEditLog.AppendText($"{client.IP}:{client.Port}正在关闭连接...".FormatStringLog());
                    }));
                    return EasyTask.CompletedTask;
                };
                _tcpClient.Closed = (client, e) =>
                {
                    Invoke(new Action(() =>
                    {
                        memoEditLog.AppendText($"{client.IP}:{client.Port}关闭连接成功".FormatStringLog());
                    }));
                    return EasyTask.CompletedTask;
                };
                _tcpClient.Received = (client, e) =>
                {
                    var msg = e.ByteBlock.Span.ToString(Encoding.UTF8);
                    client.Logger.Info($"从{client.IP}:{client.Port}接收到信息：{msg}");

                    Invoke(new Action(() =>
                    {
                        //hex 显示
                        if (checkEditRecHex.Checked)
                            memoEditLog.AppendText(string.Join(" ", string.Join(" ", Encoding.UTF8.GetBytes(msg).Select(x => x.ToString("X2")).ToArray())).FormatStringLog());
                        //ASCII 显示
                        else
                            memoEditLog.AppendText($"收到 {client.IP}:{client.Port} 消息：{msg}".FormatStringLog());
                    }));
                    return Task.CompletedTask;
                };

                await _tcpClient.SetupAsync(new TouchSocketConfig()
                     .SetRemoteIPHost($"{ip}:{port}")
                     .ConfigureContainer(a =>
                     {
                         a.AddConsoleLogger();
                     })
                     .ConfigurePlugins(a =>
                     {
                         a.UseTcpReconnection();
                     }));

                Result result = await _tcpClient.TryConnectAsync();
                if (result.IsSuccess)
                {
                    ChangeComboxEnable(false);
                    simpleButtonOpen.Text = "关闭";
                    Invoke(new Action(() =>
                    {
                        memoEditLog.AppendText("TCP 客户端已连接".FormatStringLog());
                    }));
                    _isOpen = true;
                }
                else
                {
                    _tcpClient?.Close();
                    ChangeComboxEnable(true);
                    simpleButtonOpen.Text = "打开";
                    Invoke(new Action(() =>
                    {
                        memoEditLog.AppendText("TCP 客户端连接失败".FormatStringLog());
                    }));
                    _isOpen = false;
                }
            }
        }

        /// <summary>
        /// 开启或关闭 TCP Server
        /// </summary>
        /// <param name="ip">IP</param>
        /// <param name="port">端口</param>
        private async Task StartOrStopTCPServer(string ip, string port)
        {
            if (_isOpen)
            {
                _tcpService?.Stop();
                ChangeComboxEnable(true);
                simpleButtonOpen.Text = "打开";
                memoEditLog.AppendText("TCP 服务端已关闭".FormatStringLog());
                _isOpen = false;
            }
            else
            {
                _tcpService?.Stop();

                _tcpService.Connecting = (client, e) =>
                {
                    Invoke(new Action(() =>
                    {
                        memoEditLog.AppendText($"{client.IP}:{client.Port}正在连接...".FormatStringLog());
                    }));
                    return EasyTask.CompletedTask;
                };
                _tcpService.Connected = (client, e) =>
                {
                    Invoke(new Action(() =>
                    {
                        memoEditLog.AppendText($"{client.IP}:{client.Port}连接成功".FormatStringLog());
                    }));
                    return EasyTask.CompletedTask;
                };
                _tcpService.Closing = (client, e) =>
                {
                    Invoke(new Action(() =>
                    {
                        memoEditLog.AppendText($"{client.IP}:{client.Port}正在关闭连接...".FormatStringLog());
                    }));
                    return EasyTask.CompletedTask;
                };
                _tcpService.Closed = (client, e) =>
                {
                    Invoke(new Action(() =>
                    {
                        memoEditLog.AppendText($"{client.IP}:{client.Port}关闭连接成功".FormatStringLog());
                    }));
                    return EasyTask.CompletedTask;
                };
                _tcpService.Received = (client, e) =>
                {
                    var msg = e.ByteBlock.Span.ToString(Encoding.UTF8);
                    client.Logger.Info($"从{client.IP}:{client.Port}接收到信息：{msg}");

                    Invoke(new Action(() =>
                    {
                        //hex 显示
                        if (checkEditRecHex.Checked)
                            memoEditLog.AppendText(string.Join(" ", string.Join(" ", Encoding.UTF8.GetBytes(msg).Select(x => x.ToString("X2")).ToArray())).FormatStringLog());
                        //ASCII 显示
                        else
                            memoEditLog.AppendText($"收到 {client.IP}:{client.Port} 消息：{msg}".FormatStringLog());
                    }));
                    return Task.CompletedTask;
                };

                await _tcpService.SetupAsync(new TouchSocketConfig()
                     .SetListenIPHosts($"tcp://{ip}:{port}")
                     .ConfigureContainer(a =>
                     {
                         a.AddConsoleLogger();
                     }));

                await _tcpService.StartAsync();
                ChangeComboxEnable(false);
                simpleButtonOpen.Text = "关闭";
                Invoke(new Action(() =>
                {
                    memoEditLog.AppendText("TCP 服务端已开启".FormatStringLog());
                }));
                _isOpen = true;
            }
        }

        /// <summary>
        /// 启用或关闭设置下拉框、发送按钮
        /// </summary>
        /// <param name="enable"></param>
        private void ChangeComboxEnable(bool enable)
        {
            comboBoxEditType.Enabled = enable;
            comboBoxEditIP.Enabled = enable;

            simpleButtonSend.Enabled = !enable;
        }

        /// <summary>
        /// 日志模式显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckEditRecLog_CheckedChanged(object sender, EventArgs e)
        {
            SocketHelper.Helper.StringExtension.isCheckEditRecLog = checkEditRecLog.Checked;
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
        /// 发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleButtonSend_Click(object sender, EventArgs e)
        {
            SendAndLog();
        }

        /// <summary>
        /// 发送并记录日志
        /// </summary>
        private void SendAndLog()
        {
            var msg = memoEditSendLog.Text;
            if (_isOpen && msg.Length > 0)
            {
                Invoke(new Action(() =>
                {
                    EProtocolType protocolType = EnumHelper.GetEnumFromDesciption<EProtocolType>(comboBoxEditType.Text);
                    if (protocolType == EProtocolType.UDP)
                    {

                    }
                    else if (protocolType == EProtocolType.TCPClient)
                    {
                        _tcpClient?.SendAsync(msg);
                    }
                    else if (protocolType == EProtocolType.TCPServer)
                    {
                        _tcpService.Clients.GetIds().ToList().ForEach(id =>
                        {
                            if (_tcpService.Clients.ClientExist(id))
                            {
                                _tcpService.SendAsync(id, msg);
                            };
                        });
                    }

                    if (checkEditSendHex.Checked)
                    {
                        byte[] buffer = String2HexByte(msg);
                        memoEditLog.AppendText(string.Join(" ", buffer.Select(x => x.ToString("X2")).ToArray()).FormatStringLog());
                    }
                    else
                    {
                        memoEditLog.AppendText(msg.FormatStringLog());
                    }
                }));
            }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tuling.IC.SocketClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //await SocketTcpClient();

            //TcpClientTest();

            //await TcpListenerTest();

            //Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}运行结束!!!");
            Console.ReadLine();
        }

        /// <summary>
        /// Socket 方式建立 TcpClient
        /// </summary>
        /// <returns></returns>
        private static async Task SocketTcpClient()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                //连接至服务器
                await socket.ConnectAsync(IPAddress.Parse("127.0.0.1"), 9999);
                Console.WriteLine("连接至 TCP 服务器");

                //10 秒后取消
                CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));

                while (!cts.IsCancellationRequested)
                {
                    try
                    {
                        string msg = $"Hello {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                        //发送消息
                        socket.Send(Encoding.UTF8.GetBytes(msg));
                        Console.WriteLine($"发送消息：{Environment.NewLine}{msg}");

                        //接收消息
                        byte[] buffer = new byte[1024];
                        ArraySegment<byte> segment = new ArraySegment<byte>(buffer);
                        int bytesRead = await socket.ReceiveAsync(segment, SocketFlags.None);
                        if (bytesRead > 0)
                        {
                            string receiveMsg = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            Console.WriteLine($"接收到消息：{Environment.NewLine}{receiveMsg}");
                        }

                        //等待两秒再次发送
                        await Task.Delay(2000, cts.Token);
                    }
                    catch (TaskCanceledException ex)
                    {
                        Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}发送接收结束了!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"发送接收异常：{Environment.NewLine}{ex.Message}");
                    }
                }

                //关闭 Socket
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"程序异常：{Environment.NewLine}{ex.Message}");
            }
        }

        /// <summary>
        /// TcpClient 连接实例
        /// </summary>
        private static void TcpClientTest()
        {
            var tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 9999);

                var networkStream = tcpClient.GetStream();
                //发送消息
                if (networkStream.CanWrite)
                {
                    string msg = $"Hello {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                    byte[] bytes = Encoding.UTF8.GetBytes(msg);
                    //发送消息
                    networkStream.Write(bytes, 0, bytes.Length);
                    Console.WriteLine($"发送消息：{Environment.NewLine}{msg}");
                }

                //接收消息
                Task.Run(() =>
                {
                    while (networkStream.CanRead)
                    {
                        byte[] buffer = new byte[1024 * 1024];
                        int readLength = networkStream.Read(buffer, 0, buffer.Length);
                        if (readLength == 0)
                        {
                            Console.WriteLine("连接异常，数据长度为 0");
                            networkStream.Close();
                            break;
                        }
                        Console.WriteLine($"接收到消息：{Environment.NewLine}{Encoding.UTF8.GetString(buffer, 0, readLength)}");
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"程序异常：{Environment.NewLine}{ex.Message}");
                tcpClient.Close();
                tcpClient.Dispose();
            }
        }

        /// <summary>
        /// TcpListener 实例
        /// </summary>
        private async static Task TcpListenerTest()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);

            try
            {
                tcpListener.Start();

                Console.WriteLine("TcpListener 127.0.0.1:9999 已启动");

                while (true)
                {
                    TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                    Console.WriteLine($"{tcpClient.Client.RemoteEndPoint} 已连接...");

                    _ = Task.Run(async () =>
                    {
                        try
                        {
                            using (tcpClient)
                            {
                                NetworkStream networkStream = tcpClient.GetStream();

                                //发送消息
                                string msg = $"Hello {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                                byte[] bytes = Encoding.UTF8.GetBytes(msg);
                                networkStream.Write(bytes, 0, bytes.Length);
                                Console.WriteLine($"发送消息：{Environment.NewLine}{msg}");

                                //接收消息
                                var buffer = new byte[1024 * 1024];
                                int readLength;
                                while ((readLength = await networkStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                                {
                                    Console.WriteLine($"接收到消息：{Environment.NewLine}{Encoding.UTF8.GetString(buffer, 0, readLength)}");
                                }

                                Console.WriteLine("客户端已断开连接");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"处理客户端时发生异常：{ex.Message}");
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"程序异常：{Environment.NewLine}{ex.Message}");
            }
        }
    }
}

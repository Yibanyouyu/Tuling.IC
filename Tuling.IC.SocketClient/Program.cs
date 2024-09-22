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

            Console.ReadLine();
        }
    }
}

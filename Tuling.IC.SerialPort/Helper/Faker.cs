using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuling.IC.SerialPort.Helper
{
    public class Faker
    {
        /// <summary>
        /// 获取虚拟串口
        /// </summary>
        /// <returns></returns>
        public static List<string> GetPorts()
        {
            return new List<string>()
            {
                "COM1",
                "COM2",
                "COM3",
                "COM4"
            };
        }

        /// <summary>
        /// 获取虚拟波特率
        /// </summary>
        /// <returns></returns>
        public static List<int> GetBauds()
        {
            return new List<int>()
            {
                1382400,
                921600,
                460800,
                256000,
                230400,
                128000,
                115200,
                76800,
                57600,
                43000,
                38400,
                19200,
                14400,
                9600,
                4800,
                1200
            };
        }

        /// <summary>
        /// 获取虚拟数据位
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDataBits()
        {
            return new List<string>()
            {
                "8",
                "7",
                "6",
                "5"
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tuling.IC.SocketHelper.Enums;

namespace Tuling.IC.SocketHelper.Helper
{
    public class Faker
    {
        /// <summary>
        /// 获取协议类型
        /// </summary>
        /// <returns></returns>
        public static List<string> GetProtocolTypes()
        {
            var protocolTypes = new List<string>();

            foreach (var value in Enum.GetValues(typeof(EProtocolType)))
            {
                var field = typeof(EProtocolType).GetField(value.ToString());
                if (field != null)
                {
                    var attribute = field.GetCustomAttribute<EnumDescriptionAttribute>();
                    protocolTypes.Add(attribute?.Description ?? value.ToString());
                }
            }

            return protocolTypes;
        }

        /// <summary>
        /// 获取本机所有 IP 地址
        /// </summary>
        /// <returns></returns>
        public static List<string> GetIPs()
        {
            var ips = new List<string>
            {
                "0.0.0.0",
                "127.0.0.1"
            };

            //IPAddress[] ipAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            IPAddress[] ipAddresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            foreach (IPAddress ipAddress in ipAddresses)
            {
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ips.Add(ipAddress.ToString());
            }

            ips.Reverse();

            return ips;
        }
    }
}

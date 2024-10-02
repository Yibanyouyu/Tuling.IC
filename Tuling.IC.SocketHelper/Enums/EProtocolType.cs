using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuling.IC.SocketHelper.Enums
{
    /// <summary>
    /// 协议类型枚举
    /// </summary>
    public enum EProtocolType
    {
        /// <summary>
        /// TCP 客户端
        /// </summary>
        [EnumDescription("TCP 客户端")]
        TCPClient,
        /// <summary>
        /// TCP 服务端
        /// </summary>
        [EnumDescription("TCP 服务端")]
        TCPServer,
        /// <summary>
        /// UDP
        /// </summary>
        [EnumDescription("UDP")]
        UDP
    }
}

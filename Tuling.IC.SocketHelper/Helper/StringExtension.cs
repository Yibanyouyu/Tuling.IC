using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuling.IC.SocketHelper.Helper
{
    public static class StringExtension
    {
        /// <summary>
        /// 是否使用日志模式
        /// </summary>
        public static bool isCheckEditRecLog = true;

        /// <summary>
        /// 日志模式格式化
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string FormatStringLog(this string msg)
        {
            if (isCheckEditRecLog)
                return $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}]{Environment.NewLine}{msg}{Environment.NewLine}{Environment.NewLine}";
            else
                return msg + Environment.NewLine + Environment.NewLine;
        }
    }
}

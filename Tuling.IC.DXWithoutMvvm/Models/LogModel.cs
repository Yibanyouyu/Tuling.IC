using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuling.IC.DXWithoutMvvm.Models
{
    public class LogModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 操作内容
        /// </summary>
        public string Operate { get; set; }
        /// <summary>
        /// 操作IP
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperateTime { get; set; }
    }
}

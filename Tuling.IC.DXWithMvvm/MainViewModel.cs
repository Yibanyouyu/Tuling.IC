using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tuling.IC.DXWithMvvm
{
    [POCOViewModel()]
    public class MainViewModel
    {
        /// <summary>
        /// 文本内容
        /// </summary>
        public virtual string content { get; set; } = $"风继续吹，不忍远离";

        /// <summary>
        /// 修改内容
        /// </summary>
        public void ChangeContent()
        {
            content = $"落日与晚风，深情地相拥";
        }
    }
}

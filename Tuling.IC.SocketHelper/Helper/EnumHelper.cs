using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TouchSocket.Core;

namespace Tuling.IC.SocketHelper.Helper
{
    public class EnumHelper
    {
        /// <summary>
        /// 根据枚举描述获取枚举值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static T GetEnumFromDesciption<T>(string description)
        {
            foreach (var filed in typeof(T).GetFields())
            {
                EnumDescriptionAttribute attribute = (EnumDescriptionAttribute)Attribute.GetCustomAttribute(filed, typeof(EnumDescriptionAttribute));

                if ((attribute != null && attribute.Description == description) || filed.Name == description)
                {
                    return (T)filed.GetValue(null);
                }
            }

            throw new ArgumentException($"No enum value with the description {description} was found.");
        }
    }
}

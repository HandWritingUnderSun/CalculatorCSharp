using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    public class Common
    {
        /// <summary>
        /// 除去字符串中的小数点
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public string DeletePoint(string sourceString)
        {
            string targetString = "";
            if (sourceString.Contains("."))
            {
                int pointPosition = sourceString.IndexOf(".");
                targetString = sourceString.Substring(0, pointPosition);
            }
            else
            {
                targetString = sourceString;
            }
            return targetString;
        }

        /// <summary>
        /// 验证字符串中是否已含有小数点
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public bool CheckPoint(string sourceString)
        {
            if (sourceString.Contains("."))
            {
                return false;
            }
            else
                return true;
        }
    }
}

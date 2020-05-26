using System;
using System.Windows;

namespace Calculator
{
    public class Oper
    {
        #region . 属性声明 .
        private string _Name = "";//运算符名称
        private int _Level = 0;//运算符优先级

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int Level
        {
            get { return _Level; }
            set { _Level = value; }
        }
        #endregion

        #region . 构造器 .
        public Oper(string name)
        {
            this.Name = name;
        }
        #endregion

        #region . 函数 .

        /// <summary>
        /// 双目运算符
        /// </summary>
        /// <param name="numA"></param>
        /// <param name="numB"></param>
        /// <param name="oper">运算符</param>
        /// <returns></returns>
        public static double GetResult(double numA, double numB, string oper)
        {
            double result = 0d;
            switch (oper)
            {
                case "+":
                    result =numA + numB ;
                    break;
                case "-":
                    result =numA - numB ;
                    break;
                case "*":
                    result =numA * numB;
                    break;
                case "/":
                    result =numA / numB;
                    break;
                case "mod":
                    result = numA % numB;
                    break;
            }
            return result;
        }

        /// <summary>
        /// 单目运算符
        /// </summary>
        /// <param name="numA"></param>
        /// <param name="oper">运算符</param>
        /// <returns></returns>
        public static double GetResult(double numA, string oper)
        {
            double result = 0d;
            switch (oper)
            {
                case "Sqrt":
                    try 
                    {
                        result = Math.Sqrt(numA);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString ());
                    }
                    break;
                case "-/+":
                    break;
                case "1/X":
                    try
                    {
                        result = 1/numA;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    break;
                case "%":
                    try
                    {
                        result = numA*100;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    break;
            }
            return result;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knight.Operator
{
    class OperatorFactory
    {
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
                        result =Math.Sqrt(numA);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString ());
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
                        //MessageBox.Show(ex.ToString());
                    }
                    break;
                case "%":
                    try
                    {
                        result = numA*100;
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                    }
                    break;
            }
            return result;
        }

    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

namespace Calculator
{
    /**************最初的想法是利用wpf的地盘，加些特效，赶着学再加吧！！！
    /**下一步的改进：
     * 1、加入四则运算，好像叫正则表达式吧，是不是与语义分析有关，忘记了，就是能生成整个完全的表达式，带括号的那种；
     * 2、异常的处理；
     * 3、-/+这块还没想好啊，挺复杂的，主要是例如78.情况下如何变化；
     * 4、对计算的过程与结果能不能输出文件；
     * 5、2进制的运算，10进制转2进制，转8进制和十六进制，本身2进制的加减乘除（乘除次之），带符号位和不带符号位的移位运算，与或非运算等等
     * 2017年09月26日
     * 改变现有设计构想，将计算的输入录入到堆栈中
     * 
     * 
     **/ 


    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        #region . 变量声明 .

        bool numberInputFlag = true;  //是否输入新的数字,true:准备输入第二个数；false:不是
        bool constInputFlag = true;//记录是否可以输入一些特殊的常数，如pi和e等

        private Calc calc = new Calc();
        private DataTable dt = new DataTable();

        String testString = String.Empty;
        
        #endregion

        #region . 构造器 .

        public MainWindow()
        {
            InitializeComponent();
            InputText.DataContext = calc;
            RecordText.DataContext = calc;
            #region 测试
            /**
            double x = double.Parse(dt.Compute("1+3*5/6-7*8", null).ToString());
            MessageBox.Show(x.ToString());
             */
            #endregion
        }

        #endregion

        #region . 数字按键触发方法 .

        /// <summary>
        /// 数字输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DigitBtn_Click(object sender, RoutedEventArgs e)
        {
            calc.TempString += ((Button)sender).Content.ToString();
            calc.RecordString += ((Button)sender).Content.ToString();
            
        }

        /// <summary>
        /// 常量输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConstBtn_Click(object sender, RoutedEventArgs e)
        {
        }


        /// <summary>
        /// π,e等一些常量的输入
        /// </summary>
        /// <param name="midConst"></param>
        /// <returns></returns>
        private void InputConst(string midConst)
        {
        }

        /// <summary>
        /// 小数点输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointBtn_Click(object sender, RoutedEventArgs e)
        {
            if (true ==calc.TempString.Contains("."))
            {
                return;
            }
            else
            {
                if (calc.TempString != "")
                {
                    calc.TempString += ".";
                }
                else
                {
                    calc.TempString = "0.";
                }
            }
        }

        #endregion

        #region . 功能按键触发方法 .

        private void CEBtn_Click(object sender, RoutedEventArgs e)
        {
            InputText.Text = "0";
            numberInputFlag = true;
            constInputFlag = true;
        }

        private void BackSpaceBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region . 符号按键触发方法 .

        private void SingleOperBtn_Click(object sender, RoutedEventArgs e)
        {
            calc.RecordString += ((Button)sender).Content.ToString();
        }

        private string InputSingleOperation(Button SingleOperBtn)
        {
            string rtn = (Oper.GetResult(Convert.ToDouble(InputText.Text.ToString().Trim()), SingleOperBtn.Content.ToString().Trim())).ToString().Trim();
            return rtn;
        }

        private void DoubleOperBtn_Click(object sender, RoutedEventArgs e)
        {
            calc.RecordString += ((Button)sender).Content.ToString();
            calc.TempString = string.Empty;
        }

        /// <summary>
        /// 双目运算符录入
        /// </summary>
        /// <param name="DoubleOperBtn"></param>
        private void InputDoubleOperation(Button DoubleOperBtn)
        {
        }



        #endregion

        private void BEqualBtn_Click(object sender, RoutedEventArgs e)
        {
            InputText.Text= (calc.Calculate(calc.RecordString)).ToString();
        }
    }
}

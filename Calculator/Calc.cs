using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Calculator
{
    public class Calc : INotifyPropertyChanged
    {
        #region . 属性 .
        private Stack<float> _NumStack;   //用于存储数字
        private Stack<char> _OptStack;//用于存放计算符号
        public event PropertyChangedEventHandler PropertyChanged;

        private string _RecordString;

        public string RecordString
        {
            get 
            { 
                return _RecordString; 
            }
            set
            {
                _RecordString = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this,new PropertyChangedEventArgs("RecordString"));
                }
            }
        }

        private string _TempString;

        public string TempString
        {
            get 
            { 
                return _TempString; 
            }
            set 
            { 
                _TempString = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("TempString"));
                }
            }
        }

        private float _Result;
        public float Result
        {
            get { return _Result; }
            set { _Result = value; }
        }

        #endregion

        #region . 构造函数 .
        public Calc()
        {
            _NumStack=new Stack<float>();
            _OptStack=new Stack<char>();
            _TempString = string.Empty;
            _RecordString = string.Empty;
        }
        #endregion

        #region . 功能函数 .

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public float Calculate(string expression)
        {
            string lastNum = string.Empty;

            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsNumber(expression[i]) || expression[i].Equals('.'))
                {
                    lastNum += expression[i];
                }
                else
                {
                    if (lastNum != string.Empty)
                    {
                        Merger(float.Parse(lastNum));
                        lastNum = string.Empty;
                    }
                    AddOpt(expression[i]);
                }
            }
            if (lastNum != string.Empty)
            {
                Merger(float.Parse(lastNum));
            }
            while (_OptStack.Count > 0)
            {
                Merger(_OptStack.Pop());
            }
            return _NumStack.Pop();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="opt"></param>
        private void AddOpt(char opt)
        {
            if (_OptStack.Count == 0)
            {
                _OptStack.Push(opt);
                return;
            }
            if (opt.Equals(')'))
            {
                while (!_OptStack.Peek().Equals('('))
                {
                    Merger(_OptStack.Pop());
                }
                _OptStack.Pop();
                return;
            }
            char tempOpt = _OptStack.Peek();
            if ((opt.Equals('-') || opt.Equals('+')) && (opt.Equals('/') || opt.Equals('*')))
            {
                while (_OptStack.Count > 0)
                {
                    Merger(_OptStack.Pop());
                }
            }
            _OptStack.Push(opt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exp"></param>
        private void Merger(float exp)
        {
            _NumStack.Push(exp);
        }

        /// <summary>
        /// 运算
        /// </summary>
        /// <param name="exp">运算符</param>
        private void Merger(char exp)
        {
            float num1 = _NumStack.Pop();
            float num2 = _NumStack.Pop();
            float result = 0;
            switch (exp)
            {
                case '+':
                    result = num2 + num1;
                    break;
                case '-':
                    result = num2 - num1;
                    break;
                case '*':
                    result = num2 * num1;
                    break;
                case '/':
                    result = num2 / num1;
                    break;
            }
            _NumStack.Push(result);
        }
        #endregion

        #region 日志记录
        //public void output(string log)
        //{
        //    //如果日志信息长度超过100行,则自动清空
        //    if (tbxLog.GetLineFromCharIndex(tbxLog.Text.Length) > 100)
        //        tbxLog.Text = "";
        //    //添加日志
        //    tbxLog.AppendText(DateTime.Now.ToString("HH:mm:ss  ") + log + "\r\n");
        //    write(log);
        //}

        //public void write(string msg)
        //{
        //    //获取当前程序目录
        //    string logPath = Path.GetDirectoryName(Application.ExecutablePath);
        //    //新建文件
        //    System.IO.StreamWriter sw = System.IO.File.AppendText(logPath + "/日志.txt");
        //    //写入日志信息
        //    sw.WriteLine(DateTime.Now.ToString("HH:mm:ss  ") + msg);
        //    //关闭文件
        //    sw.Close();
        //    sw.Dispose();
        //}
        #endregion

    }
}

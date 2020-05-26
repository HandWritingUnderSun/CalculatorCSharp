using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knight.Operator
{
    abstract class AbstractAddOper:IAddOper
    {
        public abstract double Add(double a, double b);

        public abstract int Add(int a, int b);

        ///复数加法
    }
}

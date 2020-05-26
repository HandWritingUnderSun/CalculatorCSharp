using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knight.Operator
{
    abstract class AbstractSubOper:ISubOper
    {
        public abstract double Sub(double a, double b);
    }
}

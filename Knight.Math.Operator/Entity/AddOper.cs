using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Knight.Operator
{
     class AddOper:AbstractAddOper
    {
        public override double Add(double a, double b)
        {
            return a + b;
        }

        public override int Add(int a, int b)
        {
            return a + b;
        }
    }
}

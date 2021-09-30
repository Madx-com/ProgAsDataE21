using System;
using System.Collections.Generic;

namespace _1_4
{
     class CstI : Expr
    {
        public int value;

        public CstI(int value)
        {
            this.value = value;
        }

        public override int Eval(Dictionary<string, int> env)        {            return value;
        }

        public override Expr Simplify()
        {
            return this;
        }

        public override string ToString()
        {
            return "CstI " + value.ToString();
        }
    }
}

using System;
using System.Collections.Generic;

namespace _1_4
{
    class Var : Expr
    {
        string name;

        public Var(string name)
        {
            this.name = name;
        }

        public override int Eval(Dictionary<string, int> env)
        {
            int result;
            env.TryGetValue(this.name, out result);
            return result;
        }

        public override Expr Simplify()
        {
            return this;
        }

        public override string ToString()
        {
            return name;
        }
    }
}

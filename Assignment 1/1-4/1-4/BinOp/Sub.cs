using System;
using System.Collections.Generic;

namespace _1_4
{
    class Sub : BinOp
    {
        public Sub(Expr ex1, Expr ex2): base(ex1, ex2)
        {
        }

        public override int Eval(Dictionary<string, int> env)
        {
            return ex1.Eval(env) - ex2.Eval(env);
        }

        public override Expr Simplify()
        {
            if (ex1 is CstI || ex2 is CstI) // If one of Expr is CstI
            {
                if (ex1 is CstI && ex2 is CstI) // If both Expr is CstI
                {
                    CstI val1 = (CstI)ex1;
                    CstI val2 = (CstI)ex2;

                    return val1.value == 0 && val2.value == 0 ?
                        new CstI(0) : val1.value == 0 ?
                        ex2 : val2.value == 0 ?
                        ex1 : val1.value != 0 && val2.value != 0 ?
                        new CstI(val1.value - val2.value) : val1.value != 0 ?
                        ex1 : val2.value != 0 ?
                        ex2 : new Var("NaN"); // Should be NaN for CstI(NaN) but since it is not of the essence I will leave it be. 
                                              // Or you could extend the Type lib too contain an error Expr... 
                                              // which would be better.

                }

                return ex1 is CstI ?
                    new Sub(ex1, ex2.Simplify()) : new Sub(ex1.Simplify(), ex2);
            }
            else
            {
                Console.WriteLine("Sub both Expr is not of type CstI");
                return new Sub(ex1.Simplify(), ex2.Simplify()).Simplify(); // Recursive call so that it checks itself.
            }
        }

        public override string ToString()
        {
            return "Sub(" + ex1.ToString() + ", " + ex2.ToString() + ")";
        }
    }
}

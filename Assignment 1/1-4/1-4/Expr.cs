using System;
using System.Collections.Generic;
namespace _1_4
{
   abstract class Expr
    {
       public abstract int Eval(Dictionary<string, int> env);
       public abstract Expr Simplify();
    }
}
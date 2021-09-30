using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace _1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Expr e = new Add(new CstI(17), new Var("z"));
            Console.WriteLine(e.ToString());

            Expr e1 = new Mul(new Add(new CstI(2), new Var("FUCK_DIG")), new CstI(42));
            Console.WriteLine(e1.ToString());

            Expr e2 = new Sub(new Mul(new CstI(2), new CstI(666)), new CstI(42));
            Console.WriteLine(e2.ToString());

            Expr e3 = new Mul(new Add(new CstI(2), new Var("Cunt")), new Mul(new Var("S"), new Var("23654284523")));
            Console.WriteLine(e3.ToString());

            Expr e4 = new Add(new CstI(0), new CstI(1));
            Console.WriteLine("Before simplification. \n");
            Console.WriteLine(e4.ToString());

            Console.WriteLine("After simplification. \n");
            Console.WriteLine(e4.Simplify().ToString());

            Expr e5 = new Mul(new Add(new Sub(new CstI(0), new CstI(1)), new Add(new CstI(0), new CstI(1))), new CstI(1));
            Console.WriteLine("Before simplification. \n");
            Console.WriteLine(e5.ToString());

            Console.WriteLine("After simplification. \n");
            Console.WriteLine(e5.Simplify().ToString());

            

        }
    }
}

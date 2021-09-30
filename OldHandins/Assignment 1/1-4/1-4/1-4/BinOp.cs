
namespace _1_4
{
    abstract class BinOp : Expr
    {
        protected Expr ex1, ex2;

        public BinOp(Expr ex1, Expr ex2)
        {
            this.ex1 = ex1;
            this.ex2 = ex2;
        }
    }
}

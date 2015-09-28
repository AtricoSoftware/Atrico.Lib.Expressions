using Atrico.Lib.Expressions.Elements;
using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.zzImplementation.Parser.Tokens
{
    internal class DivisionOperatorToken : BinaryOperatorToken
    {
        public DivisionOperatorToken()
            : base(PrecedenceType.MultiplyDivide)
        {
        }

        public override Element CreateElement(Element lhs, Element rhs)
        {
            return new DivisionElement(lhs, rhs);
        }

        public override string ToString()
        {
            return "/";
        }
    }
}
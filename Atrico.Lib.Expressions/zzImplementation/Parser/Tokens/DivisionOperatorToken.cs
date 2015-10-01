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

        public override Element CreateElement(ElementPair elements)
        {
            return new DivisionElement(elements);
        }

        public override string ToString()
        {
            return "/";
        }
    }
}
using Atrico.Lib.Expressions.Elements;
using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.zzImplementation.Parser.Tokens
{
    internal class MultiplicationOperatorToken : BinaryOperatorToken
    {
        public MultiplicationOperatorToken()
            : base(PrecedenceType.MultiplyDivide)
        {
        }

        public override Element CreateElement(Element lhs, Element rhs)
        {
            return new MultiplicationElement(lhs, rhs);
        }

        public override string ToString()
        {
            return "*";
        }
    }
}
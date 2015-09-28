using Atrico.Lib.Expressions.Elements;
using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.zzImplementation.Parser.Tokens
{
    internal class SubtractionOperatorToken : BinaryOperatorToken
    {
        public SubtractionOperatorToken()
            : base(PrecedenceType.AddSubtract)
        {
        }

        public override Element CreateElement(Element lhs, Element rhs)
        {
            return new SubtractionElement(lhs, rhs);
        }

        public override string ToString()
        {
            return "-";
        }
    }
}
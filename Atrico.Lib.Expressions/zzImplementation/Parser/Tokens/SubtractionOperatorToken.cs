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

        public override Element CreateElement(ElementPair elements)
        {
            return new SubtractionElement(elements);
        }

        public override string ToString()
        {
            return "-";
        }
    }
}
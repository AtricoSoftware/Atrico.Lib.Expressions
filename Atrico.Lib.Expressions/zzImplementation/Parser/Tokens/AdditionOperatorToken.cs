using Atrico.Lib.Expressions.Elements;
using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.zzImplementation.Parser.Tokens
{
    internal class AdditionOperatorToken : BinaryOperatorToken
    {
        public AdditionOperatorToken()
            : base(PrecedenceType.AddSubtract)
        {
        }

        public override Element CreateElement(ElementPair elements)
        {
            return new AdditionElement(elements);
        }

        public override string ToString()
        {
            return "+";
        }
    }
}
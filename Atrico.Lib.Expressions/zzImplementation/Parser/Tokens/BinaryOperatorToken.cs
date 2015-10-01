using Atrico.Lib.Expressions.Elements;
using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.zzImplementation.Parser.Tokens
{
    internal abstract class BinaryOperatorToken : OperatorToken
    {
        public enum AssociativityTypes
        {
            Left,
            Right
        }

        public AssociativityTypes Associativity { get; private set; }

        protected BinaryOperatorToken(PrecedenceType precedence, AssociativityTypes associativity = AssociativityTypes.Left)
            : base(precedence)
        {
            Associativity = associativity;
        }

        public abstract Element CreateElement(ElementPair elements);
    }
}
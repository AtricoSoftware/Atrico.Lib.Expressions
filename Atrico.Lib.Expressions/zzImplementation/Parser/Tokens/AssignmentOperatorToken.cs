using Atrico.Lib.Expressions.Elements;
using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.zzImplementation.Parser.Tokens
{
    internal class AssignmentOperatorToken : BinaryOperatorToken
    {
        public AssignmentOperatorToken()
            : base(PrecedenceType.Assign, AssociativityTypes.Right)
        {
        }

        public override Element CreateElement(ElementPair elements)
        {
            return new AssignmentElement(elements);
        }

        public override string ToString()
        {
            return "=";
        }
    }
}
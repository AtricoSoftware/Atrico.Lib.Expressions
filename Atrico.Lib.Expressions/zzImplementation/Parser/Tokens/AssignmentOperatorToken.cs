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

        public override Element CreateElement(Element lhs, Element rhs)
        {
            return new AssignmentElement(lhs, rhs);
        }

        public override string ToString()
        {
            return "=";
        }
    }
}
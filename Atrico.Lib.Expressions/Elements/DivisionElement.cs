using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.Elements
{
    public sealed class DivisionElement : BinaryElement
    {
        public DivisionElement(Element lhs, Element rhs)
            : base(lhs, rhs)
        {
        }

        public override string ToString()
        {
            return "/";
        }
    }
}
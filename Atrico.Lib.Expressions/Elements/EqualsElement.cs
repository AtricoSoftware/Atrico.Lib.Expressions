using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.Elements
{
    public sealed class EqualsElement : BinaryElement
    {
        public EqualsElement(Element lhs, Element rhs)
            : base(lhs, rhs)
        {
        }

        public override string ToString()
        {
            return "=";
        }
    }
}
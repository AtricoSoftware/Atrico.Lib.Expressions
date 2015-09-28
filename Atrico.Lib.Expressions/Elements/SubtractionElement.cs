using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.Elements
{
    public sealed class SubtractionElement : BinaryElement
    {
        public SubtractionElement(Element lhs, Element rhs)
            : base(lhs, rhs)
        {
        }

        public override string ToString()
        {
            return "-";
        }
    }
}
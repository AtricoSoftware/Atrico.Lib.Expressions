using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.Elements
{
    public sealed class DivisionElement : OperatorElement
    {
        public DivisionElement(ElementPair elements)
            : base(elements)
        {
        }

        public override Element Invert(Element original, Element replacement)
        {
            ElementPair.Replacement result;
            var newElements = Elements.Replace(original, replacement, out result);
            return result == ElementPair.Replacement.Lhs ? new MultiplicationElement(newElements) : new DivisionElement(newElements) as Element;
        }

        protected override OperatorElement Clone(ElementPair elements)
        {
            return new DivisionElement(elements);
        }

        public override string ToString()
        {
            return "/";
        }
    }
}
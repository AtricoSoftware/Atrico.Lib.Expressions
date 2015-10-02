using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.Elements
{
    public sealed class SubtractionElement : OperatorElement
    {
        public SubtractionElement(ElementPair elements)
            : base(elements)
        {
        }

        public override string ToString()
        {
            return "-";
        }

        public override Element Invert(Element original, Element replacement)
        {
            ElementPair.Replacement result;
            var newElements = Elements.Replace(original, replacement, out result);
            return result == ElementPair.Replacement.Lhs ? new AdditionElement(newElements) : new SubtractionElement(newElements) as Element;
        }

        protected override OperatorElement Clone(ElementPair elements)
        {
            return new SubtractionElement(elements);
        }
    }
}
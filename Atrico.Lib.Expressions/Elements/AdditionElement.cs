using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.Elements
{
    public sealed class AdditionElement : OperatorElement
    {
        public AdditionElement(ElementPair elements)
            : base(elements)
        {
        }

        public override Element Invert(Element original, Element replacement)
        {
            return new SubtractionElement(Elements.ReplaceLhs(original, replacement));
        }

        protected override OperatorElement Clone(ElementPair elements)
        {
            return new AdditionElement(elements);
        }

        public override string ToString()
        {
            return "+";
        }
    }
}
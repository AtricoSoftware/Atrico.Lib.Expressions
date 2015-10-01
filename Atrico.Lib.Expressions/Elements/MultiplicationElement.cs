using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.Elements
{
    public sealed class MultiplicationElement : OperatorElement
    {
        public MultiplicationElement(ElementPair elements)
            : base(elements)
        {
        }

        public override Element Invert(Element original, Element replacement)
        {
            return new DivisionElement(Elements.ReplaceLhs(original, replacement));
        }

        protected override OperatorElement Clone(ElementPair elements)
        {
            return new MultiplicationElement(elements);
        }

        public override string ToString()
        {
            return "*";
        }
    }
}
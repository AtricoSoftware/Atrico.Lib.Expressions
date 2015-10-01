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
            throw new System.NotImplementedException();
        }

        protected override OperatorElement Clone(ElementPair elements)
        {
            return new SubtractionElement(elements);
        }
    }
}
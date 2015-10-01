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
            throw new System.NotImplementedException();
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
using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.Elements
{
    public sealed class AssignmentElement : OperatorElement
    {
        public AssignmentElement(ElementPair elements)
            : base(elements)
        {
        }

        public override Element Invert(Element original, Element replacement)
        {
            // Cannot perform this operation
            throw new System.NotImplementedException();
        }

        protected override OperatorElement Clone(ElementPair elements)
        {
            return new AssignmentElement(elements);
        }

        public override string ToString()
        {
            return "=";
        }
    }
}
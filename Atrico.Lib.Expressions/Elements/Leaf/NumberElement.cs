using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.Elements.Leaf
{
    public sealed class NumberElement : LeafElement<int>
    {
        public NumberElement(int value)
            : base(value)
        {
        }
    }
}
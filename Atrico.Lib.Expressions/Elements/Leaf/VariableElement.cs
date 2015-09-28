using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.Elements.Leaf
{
    public sealed class VariableElement : LeafElement<string>
    {

        public VariableElement(string name)
            : base(name)
        {
        }

     }
}
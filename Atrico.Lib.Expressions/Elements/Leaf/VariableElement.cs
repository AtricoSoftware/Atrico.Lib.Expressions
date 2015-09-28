using System.Collections.Generic;
using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.Elements.Leaf
{
    public sealed class VariableElement : LeafElement<string>
    {
        public VariableElement(string name)
            : base(name)
        {
        }

        public override IEnumerable<string> GetVariables()
        {
            return new[] {Value};
        }
    }
}
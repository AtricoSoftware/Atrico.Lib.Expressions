using System.Collections.Generic;
using System.Linq;
using Atrico.Lib.Common.Collections.Tree;
using Atrico.Lib.Expressions.Elements.Base;
using Atrico.Lib.Expressions.Elements.Leaf;

namespace Atrico.Lib.Expressions
{
    public partial class Expression
    {
        private readonly Element _expression;

        private Expression(Element expression)
        {
            _expression = expression;
            // Discover variables
            Variables = _expression.AllLeaves.OfType<VariableElement>().Select(vr => vr.Value);
        }

        public IEnumerable<string> Variables { get; private set; }

        public ITreeNodeContainer<string> ToTree()
        {
            var tree = Tree.Create<string>(true);
            _expression.ToTree(tree);
            return tree;
        }
    }
}
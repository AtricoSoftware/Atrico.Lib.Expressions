using System.Collections.Generic;
using Atrico.Lib.Common.Collections.Tree;
using Atrico.Lib.Expressions.Elements;
using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions
{
    public partial class Expression
    {
        private readonly Element _expression;

        private Expression(Element expression)
        {
            _expression = expression;
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
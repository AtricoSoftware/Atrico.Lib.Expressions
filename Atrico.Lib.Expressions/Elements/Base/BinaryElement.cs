using System.Collections.Generic;
using System.Linq;
using Atrico.Lib.Common.Collections.Tree;

namespace Atrico.Lib.Expressions.Elements.Base
{
    public abstract class BinaryElement : Element
    {
        internal readonly Element Lhs;
        internal readonly Element Rhs;

        protected BinaryElement(Element lhs, Element rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
        }

        public override IEnumerable<Element> AllLeaves
        {
            get { return Lhs.AllLeaves.Concat(Rhs.AllLeaves); }
        }

        public override Element FindVariable(string variable)
        {
            var found = Lhs.FindVariable(variable);
            return found ?? Rhs.FindVariable(variable);
        }

        public override void ToTree(ITreeNodeContainer<string> tree)
        {
            var node = tree.Add(ToString());
            Lhs.ToTree(node);
            Rhs.ToTree(node);
        }
    }
}
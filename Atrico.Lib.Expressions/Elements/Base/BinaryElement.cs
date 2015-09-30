using System.Collections.Generic;
using System.Linq;
using Atrico.Lib.Common.Collections.Tree;

namespace Atrico.Lib.Expressions.Elements.Base
{
    public abstract class BinaryElement : Element
    {
        internal Element Lhs
        {
            get { return Properties.Get<Element>(); }
            private set { Properties.Set(value); }
        }

        internal Element Rhs
        {
            get { return Properties.Get<Element>(); }
            private set { Properties.Set(value); }
        }

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

        internal override Element FindParentOf(Element child)
        {
            if (ReferenceEquals(Lhs, child) || ReferenceEquals(Rhs, child)) return this;
            var found = Lhs.FindParentOf(child);
            return found ?? Rhs.FindParentOf(child);
        }

        public override void ToTree(ITreeNodeContainer<string> tree)
        {
            var node = tree.Add(ToString());
            Lhs.ToTree(node);
            Rhs.ToTree(node);
        }

    }
}
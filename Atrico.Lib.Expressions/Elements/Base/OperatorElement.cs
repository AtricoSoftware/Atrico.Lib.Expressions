using System.Collections.Generic;
using System.Linq;
using Atrico.Lib.Common.Collections.Tree;

namespace Atrico.Lib.Expressions.Elements.Base
{
    public abstract class OperatorElement : Element
    {
        internal ElementPair Elements
        {
            get { return Properties.Get<ElementPair>(); }
            private set { Properties.Set(value); }
        }


        protected OperatorElement(ElementPair elements)
        {
            Elements = elements;
        }

        public override Element Replace(Element original, Element replacement)
        {
            return Clone(Elements.Replace(original, replacement));
        }

        public abstract Element Invert(Element original, Element replacement);

        protected abstract OperatorElement Clone(ElementPair elements);

        public override OperatorElement FindParent(Element target)
        {
            if (ReferenceEquals(Elements.Lhs, target) || ReferenceEquals(Elements.Rhs, target)) return this;
            return Elements.Lhs.FindParent(target) ?? Elements.Rhs.FindParent(target);
        }

        public override IEnumerable<Element> AllLeaves
        {
            get { return Elements.AllLeaves; }
        }

        public override Element FindVariable(string variable)
        {
            return Elements.FindVariable(variable);
        }

        public override void ToTree(ITreeNodeContainer<string> tree)
        {
            var node = tree.Add(ToString());
            Elements.Lhs.ToTree(node);
            Elements.Rhs.ToTree(node);
        }

    }
}
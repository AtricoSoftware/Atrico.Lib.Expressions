using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public override IEnumerable<OperatorElement> FindPath(Element target)
        {
            var pathHere = new[] {this};
            if (ReferenceEquals(Elements.Lhs, target) || ReferenceEquals(Elements.Rhs, target)) return pathHere;
            var pathFromHere = Elements.Lhs.FindPath(target) ?? Elements.Rhs.FindPath(target);
            return pathFromHere != null ? pathHere.Concat(pathFromHere) : null;
        }

        public override IEnumerable<Element> AllLeaves
        {
            get { return Elements.AllLeaves; }
        }

        public override Element FindVariable(string variable)
        {
            return Elements.FindVariable(variable);
        }

        public override string ToXmlString()
        {
            var xml = new StringBuilder();
            xml.AppendFormat("<op operator=\"{0}\"", ToString());
            xml.Append(Elements.Lhs.ToXmlString());
            xml.Append(Elements.Rhs.ToXmlString());
            xml.Append("</op");
            return xml.ToString();
        }

        public override void ToTree(ITreeNodeContainer<string> tree)
        {
            var node = tree.Add(ToString());
            Elements.Lhs.ToTree(node);
            Elements.Rhs.ToTree(node);
        }
    }
}
using Atrico.Lib.Common.Collections.Tree;

namespace Atrico.Lib.Expressions.Elements.Base
{
    public abstract class BinaryElement : Element
    {
        private readonly Element _lhs;
        private readonly Element _rhs;

        protected BinaryElement(Element lhs, Element rhs)
        {
            _lhs = lhs;
            _rhs = rhs;
        }

        public override void ToTree(ITreeNodeContainer<string> tree)
        {
            var node = tree.Add(ToString());
            _lhs.ToTree(node);
            _rhs.ToTree(node);
        }
    }
}
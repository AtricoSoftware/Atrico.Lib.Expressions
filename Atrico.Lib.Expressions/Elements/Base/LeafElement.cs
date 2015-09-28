using Atrico.Lib.Common.Collections.Tree;

namespace Atrico.Lib.Expressions.Elements.Base
{
    public abstract class LeafElement<T> : Element
    {
        private T Value
        {
            get { return Properties.Get<T>(); }
            set { Properties.Set(value); }
        }

        protected LeafElement(T value)
        {
            Value = value;
        }

        public override void ToTree(ITreeNodeContainer<string> tree)
        {
            tree.Add(Value.ToString());
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
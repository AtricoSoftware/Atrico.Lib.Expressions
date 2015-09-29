using System.Collections.Generic;
using Atrico.Lib.Common.Collections.Tree;

namespace Atrico.Lib.Expressions.Elements.Base
{
    public abstract class LeafElement<T> : Element
    {
        internal T Value
        {
            get { return Properties.Get<T>(); }
            private set { Properties.Set(value); }
        }

        protected LeafElement(T value)
        {
            Value = value;
        }

        public override IEnumerable<Element> AllLeaves
        {
            get { return new Element[] {this}; }
        }

        public override Element FindVariable(string variable)
        {
            return null;
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
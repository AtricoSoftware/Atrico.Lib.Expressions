using System.Collections.Generic;
using Atrico.Lib.Common.Collections.Tree;
using Atrico.Lib.Common.PropertyContainer;
using Atrico.Lib.DomainModel;

namespace Atrico.Lib.Expressions.Elements.Base
{
    public abstract class Element : ValueObject<Element>
    {
        protected readonly PropertyContainer Properties;

        protected Element()
        {
            Properties = new PropertyContainer(this);
            // Type for comparison
            Properties.Set(GetType());
        }

        public abstract IEnumerable<Element> AllLeaves { get; }

        public abstract void ToTree(ITreeNodeContainer<string> tree);

        public abstract Element FindVariable(string variable);

        #region Equality

        protected override int GetHashCodeImpl()
        {
            return Properties.GetHashCode();
        }

        protected override bool EqualsImpl(Element other)
        {
            return Properties.Equals(other.Properties);
        }

        #endregion
    }
}
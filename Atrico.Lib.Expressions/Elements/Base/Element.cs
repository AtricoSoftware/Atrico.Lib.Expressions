using System.Collections.Generic;
using Atrico.Lib.Common.Collections.Tree;
using Atrico.Lib.Common.PropertyContainer;

namespace Atrico.Lib.Expressions.Elements.Base
{
    public abstract class Element
    {
        protected readonly PropertyContainer Properties;

        protected Element()
        {
            Properties = new PropertyContainer(this);
        }

        public abstract IEnumerable<Element> AllLeaves { get; }

        /// <summary>
        /// Find the parent element of the element specified starting from here
        /// </summary>
        /// <param name="target">Target element to find parent of</param>
        /// <returns>Parent element or null</returns>
        public abstract OperatorElement FindParent(Element target);

        public abstract Element Replace(Element original, Element replacement);

        public abstract Element FindVariable(string variable);
        public abstract void ToTree(ITreeNodeContainer<string> tree);
    }
}
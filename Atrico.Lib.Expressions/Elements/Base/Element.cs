using System.Collections.Generic;
using System.Diagnostics;
using Atrico.Lib.Common.Collections.Tree;
using Atrico.Lib.Common.PropertyContainer;

namespace Atrico.Lib.Expressions.Elements.Base
{
    [DebuggerDisplay("{ToXmlString()}")]
    public abstract class Element
    {
        protected readonly PropertyContainer Properties;

        protected Element()
        {
            Properties = new PropertyContainer(this);
        }

        public abstract IEnumerable<Element> AllLeaves { get; }

        /// <summary>
        /// Find the route elements of the element specified starting from here
        /// </summary>
        /// <param name="target">Target element to find route to</param>
        /// <returns>List of route elements</returns>
        public abstract IEnumerable<OperatorElement> FindPath(Element target);

        public abstract Element Replace(Element original, Element replacement);

        public abstract Element FindVariable(string variable);

        public ITreeNodeContainer<string> ToTree()
        {
            var tree = Tree.Create<string>(false);
            ToTree(tree);
            return tree;
        }
        public abstract void ToTree(ITreeNodeContainer<string> tree);

        public abstract string ToXmlString();
    }
}
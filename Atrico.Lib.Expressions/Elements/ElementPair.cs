using System.Collections.Generic;
using System.Linq;
using Atrico.Lib.Common.Collections.Tree;
using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.Elements
{
    public class ElementPair
    {
        public Element Lhs { get; private set; }
        public Element Rhs { get; private set; }

        public ElementPair(Element lhs, Element rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
        }

        public IEnumerable<Element> AllLeaves
        {
            get { return Lhs.AllLeaves.Concat(Rhs.AllLeaves); }
        }

        public ElementPair Swap()
        {
            return new ElementPair(Rhs, Lhs);
            
        }

        public ElementPair Replace(Element original, Element replacement)
        {
            var newLhs = ReferenceEquals(Lhs, original) ? replacement : Lhs.Replace(original, replacement);
            var newRhs = ReferenceEquals(Rhs, original) ? replacement : Rhs.Replace(original, replacement);
            return new ElementPair(newLhs, newRhs);
        }

        public ElementPair ReplaceLhs(Element original, Element replacement)
        {
            if (ReferenceEquals(Lhs, original)) return new ElementPair(replacement, Rhs);
            if (ReferenceEquals(Rhs, original)) return new ElementPair(replacement, Lhs);
            return this;
        }

        public Element FindVariable(string variable)
        {
            return Lhs.FindVariable(variable) ?? Rhs.FindVariable(variable);
        }

     }
}
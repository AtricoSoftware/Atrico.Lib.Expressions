using System;
using System.Collections.Generic;
using System.Linq;
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

        [Flags]
        public enum Replacement
        {
            None = 0x00,
            Lhs = 0x01,
            Rhs = 0x02,
        }

        public ElementPair Replace(Element original, Element replacement, out Replacement result)
        {
            Element newLhs;
            Element newRhs;
            result = Replacement.None;
            if (ReferenceEquals(Lhs, original))
            {
                newLhs = replacement;
                result |= Replacement.Lhs;
            }
            else newLhs = Lhs.Replace(original, replacement);
            if (ReferenceEquals(Rhs, original))
            {
                newRhs = replacement;
                result |= Replacement.Rhs;
            }
            else newRhs = Rhs.Replace(original, replacement);
            return new ElementPair(newLhs, newRhs);
        }

        public ElementPair Replace(Element original, Element replacement)
        {
            Replacement dummy;
            return Replace(original, replacement, out dummy);
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
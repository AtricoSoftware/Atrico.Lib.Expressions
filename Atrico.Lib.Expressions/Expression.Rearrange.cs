using System.Collections.Generic;
using Atrico.Lib.Expressions.Elements;
using Atrico.Lib.Expressions.Elements.Base;
using Atrico.Lib.Expressions.Exceptions;

namespace Atrico.Lib.Expressions
{
    public partial class Expression
    {
        private readonly IDictionary<string, Expression> _arrangements = new Dictionary<string, Expression>();

        public Expression RearrangeFor(string variable)
        {
            // Check for already done
            if (_arrangements.ContainsKey(variable)) return _arrangements[variable];
            // Move target to Lhs (and get reference)
            Element varEl;
            var equals = MoveVariableToLhs(_expression as AssignmentElement, variable, out varEl);
            _arrangements[variable] = new Expression(Rearrange(equals, varEl));
            return _arrangements[variable];
        }

        private static AssignmentElement MoveVariableToLhs(AssignmentElement equals, string variable, out Element varEl)
        {
            if (ReferenceEquals(equals, null)) throw new MissingAssignmentException();
            varEl = equals.Lhs.FindVariable(variable);
            if (!ReferenceEquals(varEl, null)) return equals;
            varEl = equals.Rhs.FindVariable(variable);
            if (ReferenceEquals(varEl, null)) throw new UnrecognisedVariableException(variable);
            // Swap lhs/rhs
            return new AssignmentElement(equals.Rhs, equals.Lhs);
        }

        private Element Rearrange(AssignmentElement current, Element target)
        {
            // Check for no rearrange necessary
            if (current.Lhs == target) return current.Rhs;
            // Rearrange first part of tree
            var parent = target.FindParent(_expression);

            return null;
        }
    }
}
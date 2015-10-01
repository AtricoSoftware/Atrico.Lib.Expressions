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
            varEl = equals.Elements.Lhs.FindVariable(variable);
            if (!ReferenceEquals(varEl, null)) return equals;
            varEl = equals.Elements.Rhs.FindVariable(variable);
            if (ReferenceEquals(varEl, null)) throw new UnrecognisedVariableException(variable);
            // Swap lhs/rhs
            return new AssignmentElement(equals.Elements.Swap());
        }

        private Element Rearrange(AssignmentElement root, Element targetVar)
        {
            while (true)
            {
                // Check for no rearrange necessary
                if (root.Elements.Lhs == targetVar) return root.Elements.Rhs;
                // Rearrange first part of tree
                var lastOperation = root.Elements.Lhs.FindParent(targetVar);
                var newRoot = root.Replace(lastOperation, targetVar) as AssignmentElement;
                root = newRoot.Replace(newRoot.Elements.Rhs, lastOperation.Invert(targetVar, newRoot.Elements.Rhs)) as AssignmentElement;
            }
        }
    }
}
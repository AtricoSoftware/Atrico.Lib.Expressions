using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                var targetPath = root.Elements.Lhs.FindPath(targetVar).ToArray();
                var lastOperation = targetPath.First();
                var varBranch = targetPath.Skip(1).FirstOrDefault() ?? targetVar;
                var newRoot = root.Replace(lastOperation, varBranch) as AssignmentElement;
                var inversion = lastOperation.Invert(varBranch, newRoot.Elements.Rhs);
                root = newRoot.Replace(newRoot.Elements.Rhs, inversion) as AssignmentElement;
            }
        }
    }
}
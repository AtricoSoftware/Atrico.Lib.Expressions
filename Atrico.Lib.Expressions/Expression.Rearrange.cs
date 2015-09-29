using System.Collections.Generic;
using Atrico.Lib.Expressions.Elements;
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
            // Get assignment
            var equals = _expression as AssignmentElement;
            if (ReferenceEquals(@equals, null)) throw new MissingAssignmentException();
            // Find variable element
            var varEl = _expression.FindVariable(variable);
            if (ReferenceEquals(varEl, null)) throw new UnrecognisedVariableException(variable);
            Expression newExpression = null;
            // Check for no rearrange necessary
            if (@equals.Lhs == varEl) newExpression = new Expression(@equals.Rhs);
            else if (@equals.Rhs == varEl) newExpression = new Expression(@equals.Lhs);
            _arrangements[variable] = newExpression;
            return _arrangements[variable];
        }
    }
}
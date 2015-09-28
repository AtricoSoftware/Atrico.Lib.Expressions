using System.Collections.Generic;
using Atrico.Lib.Common.Collections.Tree;
using Atrico.Lib.Expressions.Elements.Base;
using Atrico.Lib.Expressions.Exceptions;

namespace Atrico.Lib.Expressions
{
    public partial class Expression
    {
        public Expression RearrangeFor(string variable)
        {
            throw new UnrecognisedVariableException(variable);
        }
    }
}

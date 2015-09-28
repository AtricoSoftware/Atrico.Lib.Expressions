using System;

namespace Atrico.Lib.Expressions.Exceptions
{
    public abstract class ExpressionsException : Exception
    {
        protected ExpressionsException(string msg)
            : base(msg)
        {
        }
    }
}
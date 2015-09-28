using System;

namespace Atrico.Lib.Expressions.Exceptions
{
    public abstract class ExpressionsException : Exception
    {
        protected ExpressionsException(string msg, params object[] args)
            : base(string.Format(msg, args))
        {
        }
    }
}
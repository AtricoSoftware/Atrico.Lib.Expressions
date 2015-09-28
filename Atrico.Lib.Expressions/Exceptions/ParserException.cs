namespace Atrico.Lib.Expressions.Exceptions
{
    public abstract class ParserException : ExpressionsException
    {
        protected ParserException(string msg)
            : base(msg)
        {
        }
    }
}
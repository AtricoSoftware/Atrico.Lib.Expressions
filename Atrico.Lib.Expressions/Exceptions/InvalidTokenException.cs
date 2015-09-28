namespace Atrico.Lib.Expressions.Exceptions
{
    public sealed class InvalidTokenException : ExpressionsException
    {
        public InvalidTokenException(string token)
            : base("Invalid token: {0}", token)
        {
        }
    }
}
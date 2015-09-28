namespace Atrico.Lib.Expressions.Exceptions
{
    public sealed class InvalidTokenException : ParserException
    {
        public InvalidTokenException(string token)
            : base(string.Format("Invalid token: {0}", token))
        {
        }
    }
}
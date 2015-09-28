namespace Atrico.Lib.Expressions.Exceptions
{
    public class UnrecognisedVariableException : ExpressionsException
    {
        public UnrecognisedVariableException(string variable)
            : base("Variable not recognised: {0}", variable)
        {
        }
    }
}
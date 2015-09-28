namespace Atrico.Lib.Expressions.zzImplementation.Parser.Tokens
{
    internal abstract class BraceToken : OperatorToken
    {
        protected BraceToken()
            : base(PrecedenceType.Braces)
        {
        }
    }
}
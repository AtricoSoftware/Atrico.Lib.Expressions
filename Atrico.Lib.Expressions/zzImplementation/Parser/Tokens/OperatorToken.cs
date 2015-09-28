namespace Atrico.Lib.Expressions.zzImplementation.Parser.Tokens
{
    internal abstract class OperatorToken : Token
    {
        public enum PrecedenceType
        {
            Assign,
            Braces,
            AddSubtract,
            MultiplyDivide,
        }

        public PrecedenceType Precedence { get; private set; }

        public static OperatorToken Create(string input)
        {
            if (input == "=") return new AssignmentOperatorToken();
            if (input == "+") return new AdditionOperatorToken();
            if (input == "-") return new SubtractionOperatorToken();
            if (input == "*") return new MultiplicationOperatorToken();
            if (input == "/") return new DivisionOperatorToken();
            if (input == "(" || input == "[") return new OpenBraceToken();
            if (input == ")" || input == "]") return new CloseBraceToken();
            return null;
        }

        protected OperatorToken(PrecedenceType precedence)
        {
            Precedence = precedence;
        }
    }
}
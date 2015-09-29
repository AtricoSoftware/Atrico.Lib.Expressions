namespace Atrico.Lib.Expressions.Exceptions
{
    public class MissingAssignmentException : ExpressionsException
    {
        public MissingAssignmentException()
            : base("Expression has no assignment")
        {
        }
    }
}
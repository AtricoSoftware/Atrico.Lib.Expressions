using Atrico.Lib.Expressions.Elements;

namespace Atrico.Lib.Expressions
{
    public partial class Expression
    {
        public static Expression Parse(string input, params string[] variables)
        {
            // TODO
            var lhs = new VariableElement("a");
            var rhs = new ConstantElement(1);
            var exp = new EqualsElement(lhs, rhs);
            return new Expression(exp) { Variables = variables };
        }
    }
}
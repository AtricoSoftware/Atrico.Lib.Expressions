using Atrico.Lib.Expressions.Elements;
using Atrico.Lib.Expressions.Elements.Base;
using Atrico.Lib.Expressions.Elements.Leaf;

namespace Atrico.Lib.Expressions
{
    public partial class Expression
    {
        private abstract class Token
        {
        }

        private abstract class ConstantToken : Token
        {
            public abstract Element CreateElement();
        }

        private abstract class OperatorToken : Token
        {
            public static OperatorToken Create(string input)
            {
                if (input == "=") return new EqualsOperatorToken();
                return null;
            }
        }

        private abstract class BinaryOperatorToken : OperatorToken
        {
            public abstract Element CreateElement(Element lhs, Element rhs);
        }

        private sealed class NumberToken : ConstantToken
        {
            private readonly int _value;

            private NumberToken(int value)
            {
                _value = value;
            }

            public static NumberToken Create(string part)
            {
                int value;
                return int.TryParse(part, out value) ? new NumberToken(value) : null;
            }

            public override Element CreateElement()
            {
                return new NumberElement(_value);
            }
        }

        private sealed class VariableToken : ConstantToken
        {
            private readonly string _name;

            public VariableToken(string name)
            {
                _name = name;
            }

            public override Element CreateElement()
            {
                return new VariableElement(_name);
            }
        }

        private class EqualsOperatorToken : BinaryOperatorToken
        {
            public override Element CreateElement(Element lhs, Element rhs)
            {
                return new EqualsElement(lhs, rhs);
            }
        }
    }
}
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

        #region Constants

        private abstract class ConstantToken : Token
        {
            public abstract Element CreateElement();
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
            public override string ToString()
            {
                return _value.ToString();
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
            public override string ToString()
            {
                return _name;
            }
        }

        #endregion

        #region Operators

        private enum Precedence
        {
            Assign,
            Braces,
            AddSubtract,
            MultiplyDivide,
        }

        private abstract class OperatorToken : Token
        {
            public Precedence Precedence { get; private set; }

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

            protected OperatorToken(Precedence precedence)
            {
                Precedence = precedence;
            }
        }

        private enum Associativity
        {
            Left,
            Right
        }

        private abstract class BinaryOperatorToken : OperatorToken
        {
            public Associativity Associativity { get; private set; }

            protected BinaryOperatorToken(Precedence precedence, Associativity associativity = Associativity.Left)
                : base(precedence)
            {
                Associativity = associativity;
            }

            public abstract Element CreateElement(Element lhs, Element rhs);
        }

        private class AssignmentOperatorToken : BinaryOperatorToken
        {
            public AssignmentOperatorToken()
                : base(Precedence.Assign, Associativity.Right)
            {
            }

            public override Element CreateElement(Element lhs, Element rhs)
            {
                return new EqualsElement(lhs, rhs);
            }

            public override string ToString()
            {
                return "=";
            }
        }

        private class AdditionOperatorToken : BinaryOperatorToken
        {
            public AdditionOperatorToken()
                : base(Precedence.AddSubtract)
            {
            }

            public override Element CreateElement(Element lhs, Element rhs)
            {
                return new AdditionElement(lhs, rhs);
            }
            public override string ToString()
            {
                return "+";
            }
        }

        private class SubtractionOperatorToken : BinaryOperatorToken
        {
            public SubtractionOperatorToken()
                : base(Precedence.AddSubtract)
            {
            }

            public override Element CreateElement(Element lhs, Element rhs)
            {
                return new SubtractionElement(lhs, rhs);
            }
            public override string ToString()
            {
                return "-";
            }
        }

        private class MultiplicationOperatorToken : BinaryOperatorToken
        {
            public MultiplicationOperatorToken()
                : base(Precedence.MultiplyDivide)
            {
            }

            public override Element CreateElement(Element lhs, Element rhs)
            {
                return new MultiplicationElement(lhs, rhs);
            }
            public override string ToString()
            {
                return "*";
            }
        }

        private class DivisionOperatorToken : BinaryOperatorToken
        {
            public DivisionOperatorToken()
                : base(Precedence.MultiplyDivide)
            {
            }

            public override Element CreateElement(Element lhs, Element rhs)
            {
                return new DivisionElement(lhs, rhs);
            }
            public override string ToString()
            {
                return "/";
            }
        }

        #endregion

        #region Braces

        private abstract class BraceToken : OperatorToken
        {
            protected BraceToken()
                : base(Precedence.Braces)
            {
            }
        }

        private sealed class OpenBraceToken : BraceToken
        {
            public override string ToString()
            {
                return "(";
            }
        }

        private sealed class CloseBraceToken : BraceToken
        {
            public override string ToString()
            {
                return ")";
            }
        }

        #endregion
    }
}
using System.Collections.Generic;
using Atrico.Lib.Expressions.Elements.Base;
using Atrico.Lib.Expressions.Exceptions;
using Atrico.Lib.Expressions.zzImplementation.Parser.Tokens;

namespace Atrico.Lib.Expressions.zzImplementation.Parser
{
    internal class ShuntingYard
    {
        private readonly Stack<Element> _stack = new Stack<Element>();
        private readonly Stack<OperatorToken> _operatorStack = new Stack<OperatorToken>();

        public Element CreateExpression(IEnumerable<Token> tokens)
        {
            _stack.Clear();
            _operatorStack.Clear();
            foreach (var token in tokens)
            {
                // Constants
                if (token is ConstantToken)
                {
                    AddConstant(token as ConstantToken);
                    continue;
                }
                // Operators
                if (token is BinaryOperatorToken)
                {
                    AddOperator(token as BinaryOperatorToken);
                    continue;
                }
                // Braces
                if (token is OpenBraceToken)
                {
                    _operatorStack.Push(token as OperatorToken);
                    continue;
                }
                if (token is CloseBraceToken)
                {
                    EvaluateToOpenBrace();
                    continue;
                }
                // Invalid
                throw new InvalidTokenException(token.GetType().Name);
            }
            // Empty operator stack
            while (_operatorStack.Count > 0)
            {
                EvaluateOperator();
            }
            return _stack.Pop();
        }

        private void AddConstant(ConstantToken token)
        {
            _stack.Push(token.CreateElement());
        }

        private void AddOperator(BinaryOperatorToken token)
        {
            while (_operatorStack.Count > 0)
            {
                var currentPrecedence = _operatorStack.Peek().Precedence;
                if (token.Precedence > currentPrecedence || (token.Associativity == BinaryOperatorToken.AssociativityTypes.Right && token.Precedence == currentPrecedence)) break;
                EvaluateOperator();
            }
            _operatorStack.Push(token);
        }

        private void EvaluateOperator()
        {
            var op = _operatorStack.Pop() as BinaryOperatorToken;
            var rhs = _stack.Pop();
            var lhs = _stack.Pop();
            _stack.Push(op.CreateElement(lhs, rhs));
        }

        private void EvaluateToOpenBrace()
        {
            while (_operatorStack.Count > 0)
            {
                if (_operatorStack.Peek() is OpenBraceToken)
                {
                    _operatorStack.Pop();
                    break;
                }
                EvaluateOperator();
            }
        }
    }
}
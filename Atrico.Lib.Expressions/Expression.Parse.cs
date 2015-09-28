using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atrico.Lib.Expressions.Elements;
using Atrico.Lib.Expressions.Elements.Base;
using Atrico.Lib.Expressions.Elements.Leaf;

namespace Atrico.Lib.Expressions
{
    public partial class Expression
    {
        public static Expression Parse(string input, params string[] variables)
        {
            var parts = Split(input);
            var tokens = Tokenise(parts, variables.Select(v => v.ToLower()));
            var expression = ShuntingYard(tokens);
            return new Expression(expression) {Variables = variables};
        }

        private enum CharType
        {
            None,
            Ignore,
            Number,
            Letter,
            Symbol
        }

        private static IEnumerable<string> Split(string input)
        {
            var parts = new List<string>();
            var currentPart = new StringBuilder();
            var lastChartype = CharType.None;
            foreach (var ch in input)
            {
                var charType = GetCharType(ch);
                if (charType == CharType.Ignore) continue;
                if (charType != lastChartype)
                {
                    if (currentPart.Length > 0)
                    {
                        parts.Add(currentPart.ToString());
                        currentPart.Clear();
                    }
                    lastChartype = charType;
                }
                currentPart.Append(ch);
            }
            if (currentPart.Length > 0)
            {
                parts.Add(currentPart.ToString());
            }
            return parts;
        }

        private static CharType GetCharType(char ch)
        {
            // Number
            if (char.IsDigit(ch)) return CharType.Number;
            // Letter
            if (char.IsLetter(ch)) return CharType.Letter;
            // Symbol
            if (char.IsSymbol(ch)) return CharType.Symbol;
            return CharType.Ignore;
        }

        private static IEnumerable<Token> Tokenise(IEnumerable<string> parts, IEnumerable<string> variables)
        {
            var tokens = new List<Token>();
            foreach (var part in parts)
            {
                // Number
                Token token = NumberToken.Create(part);
                // Operator
                if (token == null) token = OperatorToken.Create(part);
                // Variable
                if (token == null && variables.Contains(part.ToLower())) token = new VariableToken(part);
                // Invalid
                if (token == null) throw new Exception(string.Format("Token is invalid: {0}", part));
                tokens.Add(token);
            }
            return tokens;
        }

        private static Element ShuntingYard(IEnumerable<Token> tokens)
        {
            var stack = new Stack<Element>();
            var operatorStack = new Stack<OperatorToken>();
            Element element = null;
            foreach (var token in tokens)
            {
                // Constants
                if (token is ConstantToken)
                {
                    stack.Push((token as ConstantToken).CreateElement());
                    continue;
                }
                // Operators
                if (token is OperatorToken)
                {
                    operatorStack.Push(token as OperatorToken);
                    continue;
                }
                // Invalid
                throw new Exception(string.Format("Token is invalid: {0}", token));
            }
            // Empty operator stack
            while (operatorStack.Count > 0)
            {
                var op = operatorStack.Pop();
                if (op is BinaryOperatorToken)
                {
                    var rhs = stack.Pop();
                    var lhs = stack.Pop();
                    stack.Push((op as BinaryOperatorToken).CreateElement(lhs, rhs));
                }
            }
            return stack.Pop();
        }
    }
}
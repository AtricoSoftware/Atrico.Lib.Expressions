﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atrico.Lib.Expressions.Exceptions;
using Atrico.Lib.Expressions.zzImplementation.Parser;
using Atrico.Lib.Expressions.zzImplementation.Parser.Tokens;

namespace Atrico.Lib.Expressions
{
    public partial class Expression
    {
        private static readonly ISet<char> _symbols = new HashSet<char>("*/+-=");

        public static Expression Parse(string input)
        {
            var parts = Split(input);
            var tokens = Tokenise(parts);
            var expression = new ShuntingYard().CreateExpression(tokens);
            return new Expression(expression);
        }

        private enum CharType
        {
            None,
            Ignore,
            Number,
            Letter,
            Symbol,
            OpenBrace,
            CloseBrace
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
            if (_symbols.Contains(ch)) return CharType.Symbol;
            // Braces
            if (ch == '(') return CharType.OpenBrace;
            if (ch == ')') return CharType.CloseBrace;
            return CharType.Ignore;
        }

        private static IEnumerable<Token> Tokenise(IEnumerable<string> parts)
        {
            var tokens = new List<Token>();
            foreach (var part in parts)
            {
                // Number
                Token token = NumberToken.Create(part);
                // Operator
                if (token == null) token = OperatorToken.Create(part);
                // Variable
                if (token == null && part.All(char.IsLetter)) token = new VariableToken(part);
                // Invalid
                if (token == null) throw new InvalidTokenException(part);
                tokens.Add(token);
            }
            return tokens;
        }
    }
}
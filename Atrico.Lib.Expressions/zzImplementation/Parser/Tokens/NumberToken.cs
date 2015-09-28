using Atrico.Lib.Expressions.Elements.Base;
using Atrico.Lib.Expressions.Elements.Leaf;

namespace Atrico.Lib.Expressions.zzImplementation.Parser.Tokens
{
    internal sealed class NumberToken : ConstantToken
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
}
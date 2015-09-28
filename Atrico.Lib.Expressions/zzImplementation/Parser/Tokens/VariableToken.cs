using Atrico.Lib.Expressions.Elements.Base;
using Atrico.Lib.Expressions.Elements.Leaf;

namespace Atrico.Lib.Expressions.zzImplementation.Parser.Tokens
{
    internal sealed class VariableToken : ConstantToken
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
}
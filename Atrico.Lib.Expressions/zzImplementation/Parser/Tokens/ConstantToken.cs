using Atrico.Lib.Expressions.Elements.Base;

namespace Atrico.Lib.Expressions.zzImplementation.Parser.Tokens
{
    internal abstract class ConstantToken : Token
    {
        public abstract Element CreateElement();
    }
}
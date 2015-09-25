using System.Globalization;

namespace Atrico.Lib.Expressions.Elements
{
    public sealed class ConstantElement : LeafElement<int>
    {

        public ConstantElement(int value)
            : base(value)
        {
        }

     }
}
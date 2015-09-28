using System.Diagnostics;
using System.Linq;
using Atrico.Lib.Common.Collections.Tree;
using Atrico.Lib.Testing;

namespace Atrico.Lib.Expressions.Tests
{
    public class TestExpressionBase : TestFixtureBase
    {
        protected static void DisplayTree(string title, ITreeNodeContainer<string> tree)
        {
            Debug.WriteLine(title);
            var lines = tree.ToMultilineString().ToArray();
            foreach (var line in lines)
            {
                Debug.WriteLine(line);
            }
        }
    }
}
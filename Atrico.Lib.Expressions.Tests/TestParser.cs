using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Atrico.Lib.Assertions;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Common.Collections.Tree;
using Atrico.Lib.Expressions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;

namespace Atrico.Lib.Expressions.Tests
{
    [TestFixture]
    public class TestExpressionBase : TestFixtureBase
    {
        protected static void DisplayTree(ITreeNodeContainer<string> tree)
        {
            var lines = tree.ToMultilineString().ToArray();
            foreach (var line in lines)
            {
                Debug.WriteLine(line);
            }
        }
    }

    [TestFixture]
    public class TestParser : TestExpressionBase
    {
        [Test]
        public void TestAssignConstant()
        {
            const string input = "a = 1";
            var expected = new [] {"=", "a", "1"};

            // Arrange

            // Act
            var expression = Expression.Parse(input, "a");

            // Assert
            Assert.That(Value.Of(expression.Variables).Is().EquivalentTo(new []{"a"}));
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }
        [Test]
        public void TestAssignConstantReverse()
        {
            const string input = "2 = b";
            var expected = new [] {"=", "2", "b"};

            // Arrange

            // Act
            var expression = Expression.Parse(input, "b");

            // Assert
            Assert.That(Value.Of(expression.Variables).Is().EquivalentTo(new []{"b"}));
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }
    }
}
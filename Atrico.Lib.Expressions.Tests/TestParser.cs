using System.Collections.Generic;
using Atrico.Lib.Assertions;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing.TestAttributes.NUnit;

namespace Atrico.Lib.Expressions.Tests
{
    [TestFixture]
    public class TestParser : TestExpressionBase
    {
        [Test]
        public void TestAssignConstant()
        {
            const string input = "a = 1";
            var expected = new[] {"=", "a", "1"};

            // Arrange

            // Act
            var expression = Expression.Parse(input);

            // Assert
            Assert.That(Value.Of(expression.Variables).Is().EquivalentTo(new[] {"a"}));
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(input, expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestAssignConstantReverse()
        {
            const string input = "2 = b";
            var expected = new[] {"=", "2", "b"};

            // Arrange

            // Act
            var expression = Expression.Parse(input);

            // Assert
            Assert.That(Value.Of(expression.Variables).Is().EquivalentTo(new[] {"b"}));
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(input, expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestPlus()
        {
            const string input = "y = x + 1";
            var expected = new[] {"=", "y", "+", "x", "1"};

            // Arrange

            // Act
            var expression = Expression.Parse(input);

            // Assert
            Assert.That(Value.Of(expression.Variables).Is().EquivalentTo(new[] {"x", "y"}));
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(input, expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestMinus()
        {
            const string input = "y = x - 1";
            var expected = new[] {"=", "y", "-", "x", "1"};

            // Arrange

            // Act
            var expression = Expression.Parse(input);

            // Assert
            Assert.That(Value.Of(expression.Variables).Is().EquivalentTo(new[] {"x", "y"}));
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(input, expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestMultiply()
        {
            const string input = "y = x * 1";
            var expected = new[] {"=", "y", "*", "x", "1"};

            // Arrange

            // Act
            var expression = Expression.Parse(input);

            // Assert
            Assert.That(Value.Of(expression.Variables).Is().EquivalentTo(new[] {"x", "y"}));
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(input, expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestDivide()
        {
            const string input = "y = x / 1";
            var expected = new[] {"=", "y", "/", "x", "1"};

            // Arrange

            // Act
            var expression = Expression.Parse(input);

            // Assert
            Assert.That(Value.Of(expression.Variables).Is().EquivalentTo(new[] {"x", "y"}));
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(input, expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestPrecedence1()
        {
            const string input = "y = x + 1 * 2";
            var expected = new[] {"=", "y", "+", "x", "*", "1", "2"};

            // Arrange

            // Act
            var expression = Expression.Parse(input);

            // Assert
            Assert.That(Value.Of(expression.Variables).Is().EquivalentTo(new[] {"x", "y"}));
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(input, expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestPrecedence2()
        {
            const string input = "y = x * 1 + 2";
            var expected = new[] {"=", "y", "+", "*", "x", "1", "2"};

            // Arrange

            // Act
            var expression = Expression.Parse(input);

            // Assert
            Assert.That(Value.Of(expression.Variables).Is().EquivalentTo(new[] {"x", "y"}));
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(input, expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestPrecedenceBracesChange1()
        {
            const string input = "y = (x + 1) * 2";
            var expected = new[] {"=", "y", "*", "+", "x", "1", "2"};

            // Arrange

            // Act
            var expression = Expression.Parse(input);

            // Assert
            Assert.That(Value.Of(expression.Variables).Is().EquivalentTo(new[] {"x", "y"}));
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(input, expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestPrecedenceBracesChange2()
        {
            const string input = "y = x * (1 + 2)";
            var expected = new[] {"=", "y", "*", "x", "+", "1", "2"};

            // Arrange

            // Act
            var expression = Expression.Parse(input);

            // Assert
            Assert.That(Value.Of(expression.Variables).Is().EquivalentTo(new[] {"x", "y"}));
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(input, expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestPrecedenceBracesSame1()
        {
            const string input = "y = x + (1 * 2)";
            var expected = new[] {"=", "y", "+", "x", "*", "1", "2"};

            // Arrange

            // Act
            var expression = Expression.Parse(input);

            // Assert
            Assert.That(Value.Of(expression.Variables).Is().EquivalentTo(new[] {"x", "y"}));
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(input, expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestPrecedenceBracesSame2()
        {
            const string input = "y = (x * 1) + 2";
            var expected = new[] {"=", "y", "+", "*", "x", "1", "2"};

            // Arrange

            // Act
            var expression = Expression.Parse(input);

            // Assert
            Assert.That(Value.Of(expression.Variables).Is().EquivalentTo(new[] {"x", "y"}));
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(input, expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestAssociativity()
        {
            const string input = "y = x * 1 * 2 * 3";
            var expected = new[] {"=", "y", "*", "*", "*", "x", "1", "2", "3"};

            // Arrange

            // Act
            var expression = Expression.Parse(input);

            // Assert
            Assert.That(Value.Of(expression.Variables).Is().EquivalentTo(new[] {"x", "y"}));
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(input, expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        #region Errors

        #endregion
    }
}
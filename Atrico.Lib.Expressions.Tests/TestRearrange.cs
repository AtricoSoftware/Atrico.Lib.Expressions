using System.Collections.Generic;
using Atrico.Lib.Assertions;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Expressions.Exceptions;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;

namespace Atrico.Lib.Expressions.Tests
{
    [TestFixture]
    public class TestRearrange : TestExpressionBase
    {
        [Test]
        public void TestNoChange1()
        {
            const string input = "a = 1";
            var expected = new[] {"1"};

            // Arrange
            var master = Expression.Parse(input);

            // Act
            var expression = master.RearrangeFor("a");

            // Assert
            Assert.That(Value.Of(expression.Variables).Count().Is().EqualTo(0), "No variables");
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(input, expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestNoChange2()
        {
            const string input = "a = b";
            var expected = new[] {"a"};

            // Arrange
            var master = Expression.Parse(input);

            // Act
            var expression = master.RearrangeFor("b");

            // Assert
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree(input, expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestSimpleAddition()
        {
            const string input = "y = x + 1";
            var expected = new[] {"-", "y", "1"};

            // Arrange
            var master = Expression.Parse(input);
            DisplayTree(input, master.ToTree());

            // Act
            var expression = master.RearrangeFor("x");

            // Assert
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree("Rearranged for x", expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestSimpleAdditionReverse()
        {
            const string input = "y = 1 + x";
            var expected = new[] {"-", "y", "1"};

            // Arrange
            var master = Expression.Parse(input);
            DisplayTree(input, master.ToTree());

            // Act
            var expression = master.RearrangeFor("x");

            // Assert
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree("Rearranged for x", expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }
        [Test]
        public void TestSimpleSubtraction()
        {
            const string input = "y = x - 1";
            var expected = new[] {"+", "y", "1"};

            // Arrange
            var master = Expression.Parse(input);
            DisplayTree(input, master.ToTree());

            // Act
            var expression = master.RearrangeFor("x");

            // Assert
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree("Rearranged for x", expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestSimpleSubtractionReverse()
        {
            const string input = "y = 1 - x";
            var expected = new[] {"-", "1", "y"};

            // Arrange
            var master = Expression.Parse(input);
            DisplayTree(input, master.ToTree());

            // Act
            var expression = master.RearrangeFor("x");

            // Assert
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree("Rearranged for x", expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }
        [Test]
        public void TestSimpleMultiplication()
        {
            const string input = "y = x * 2";
            var expected = new[] {"/", "y", "2"};

            // Arrange
            var master = Expression.Parse(input);
            DisplayTree(input, master.ToTree());

            // Act
            var expression = master.RearrangeFor("x");

            // Assert
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree("Rearranged for x", expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestSimpleMultiplicationReverse()
        {
            const string input = "y = 2 * x";
            var expected = new[] {"/", "y", "2"};

            // Arrange
            var master = Expression.Parse(input);
            DisplayTree(input, master.ToTree());

            // Act
            var expression = master.RearrangeFor("x");

            // Assert
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree("Rearranged for x", expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }
        [Test]
        public void TestSimpleDivision()
        {
            const string input = "y = x / 2";
            var expected = new[] {"*", "y", "2"};

            // Arrange
            var master = Expression.Parse(input);
            DisplayTree(input, master.ToTree());

            // Act
            var expression = master.RearrangeFor("x");

            // Assert
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree("Rearranged for x", expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        [Test]
        public void TestSimpleDivisionReverse()
        {
            const string input = "y = 2 / x";
            var expected = new[] {"/", "2", "y"};

            // Arrange
            var master = Expression.Parse(input);
            DisplayTree(input, master.ToTree());

            // Act
            var expression = master.RearrangeFor("x");

            // Assert
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree("Rearranged for x", expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }
        [Test]
        public void TestMultipleOperations()
        {
            const string input = "y = x * 2 + 3";
            var expected = new[] {"/", "+", "y", "3", "2"};

            // Arrange
            var master = Expression.Parse(input);
            DisplayTree(input, master.ToTree());

            // Act
            var expression = master.RearrangeFor("x");

            // Assert
            var expTree = expression.ToTree();
            Assert.That(Value.Of(expTree).Is().Not().Null(), "Not null");
            DisplayTree("Rearranged for x", expTree);
            var expList = new List<string>();
            expTree.DepthFirst(el => expList.Add(el.Data));
            Assert.That(Value.Of(expList).Is().EqualTo(expected));
        }

        #region Errors

        [Test]
        public void TestUnrecognisedVariable()
        {
            const string input = "a = 1";

            // Arrange
            var expression = Expression.Parse(input);

            // Act
            var ex = Catch.Exception(() => expression.RearrangeFor("b"));

            // Assert
            Assert.That(Value.Of(ex).Is().TypeOf(typeof(UnrecognisedVariableException)), "Unknown variable");
        }

        #endregion
    }
}
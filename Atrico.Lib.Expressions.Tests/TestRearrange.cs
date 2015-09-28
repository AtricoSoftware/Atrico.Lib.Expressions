using System.Collections.Generic;
using Atrico.Lib.Assertions;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing.TestAttributes.NUnit;

namespace Atrico.Lib.Expressions.Tests
{
    [TestFixture]
    public class TestRearrange : TestExpressionBase
    {
        [Test]
        public void TestNoChange()
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

        #region Errors

        //[Test]
        //public void TestUnrecognisedVariable()
        //{
        //    const string input = "a = 1";

        //    // Arrange

        //    // Act
        //    var ex = Catch.Exception(() => Expression.Parse(input));

        //    // Assert
        //    Assert.That(Value.Of(ex).Is().TypeOf(typeof(InvalidTokenException)), "Token is invalid");
        //}

        #endregion
    }
}
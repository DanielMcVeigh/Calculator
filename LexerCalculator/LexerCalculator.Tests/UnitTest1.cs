using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LexerCalculator.ClassLibrary;
using Enum = System.Enum;

namespace LexerCalculator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SplittingCheck1()
        {
            // Arrange

            string stringInput = "(3+2)*5";
            List<string> expectedResult = new List<string>
            {
                "(","3","+","2",")","*","5"
            };

            // Act

            List<string> actualResult = TokenDefinition.SeparateCharacters(stringInput);

            // Assert

            bool match = expectedResult.SequenceEqual(actualResult);
            Assert.IsTrue(match);
        }

        [TestMethod]
        public void SplittingCheck2()
        {
            // Arrange

            string stringInput = "43+(7^2+3)";
            List<string> expectedResult = new List<string>
            {
                "4","3","+","(","7","^","2","+","3",")"
            };

            // Act

            List<string> actualResult = TokenDefinition.SeparateCharacters(stringInput);

            // Assert

            bool match = expectedResult.SequenceEqual(actualResult);
            Assert.IsTrue(match);
        }

        [TestMethod]
        public void RemoveWhitespaceCheck1()
        {
            // Arrange

            string stringInput = "4   + 3";
            string expectedResult = "4+3";

            // Act

            var actualResult = TokenDefinition.SanitizeString(stringInput);

            // Assert

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveWhitespaceCheck2()
        {
            // Arrange

            string stringInput = "(4 /3) +4";
            string expectedResult = "(4/3)+4";

            // Act

            var actualResult = TokenDefinition.SanitizeString(stringInput);

            // Assert

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SplittingWhitespaceCheck1()
        {
            // Arrange

            string stringInput = "( 3   + 2) *  3";
            List<string> expectedResult = new List<string>
            {
                "(","3","+","2",")","*","3"
            };

            // Act

            List<string> actualResult = TokenDefinition.SeparateCharacters(TokenDefinition.SanitizeString(stringInput));

            // Assert

            bool match = expectedResult.SequenceEqual(actualResult);
            Assert.IsTrue(match);
        }

        [TestMethod]
        public void SplittingWhitespaceCheck2()
        {
            // Arrange

            string stringInput = "4  3 + (     7^   2  +3 )";
            List<string> expectedResult = new List<string>
            {
                "4","3","+","(","7","^","2","+","3",")"
            };

            // Act

            List<string> actualResult = TokenDefinition.SeparateCharacters(TokenDefinition.SanitizeString(stringInput));

            // Assert

            bool match = expectedResult.SequenceEqual(actualResult);
            Assert.IsTrue(match);
        }

        [TestMethod]
        public void SanitizeStringCheck1()
        {
            // Arrange

            string stringInput = "4$+£3:;;/2";
            string expectedResult = "4+3/2";

            // Act

            string actualResult = TokenDefinition.SanitizeString(stringInput);

            // Assert

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SanitizeStringCheck2()
        {
            // Arrange

            string stringInput = "(4%/2$)^(1££/3@)";
            string expectedResult = "(4/2)^(1/3)";

            // Act

            string actualResult = TokenDefinition.SanitizeString(stringInput);

            // Assert

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CheckOperatorTokenType1()
        {
            // Arrange

            string stringInput = "+";
            
            // Act
            var actualResult = TokenDefinition.DefineTokenType(stringInput);

            // Assert

            Assert.AreEqual(ClassLibrary.Enum.TokenType.Operator, actualResult);
        }

        [TestMethod]
        public void CheckOperatorTokenType2()
        {
            // Arrange

            string stringInput = "^";

            // Act
            var actualResult = TokenDefinition.DefineTokenType(stringInput);

            // Assert

            Assert.AreEqual(ClassLibrary.Enum.TokenType.Operator, actualResult);
        }

        [TestMethod]
        public void CheckOperatorTokenType3()
        {
            // Arrange

            string stringInput = "/";

            // Act
            var actualResult = TokenDefinition.DefineTokenType(stringInput);

            // Assert

            Assert.AreEqual(ClassLibrary.Enum.TokenType.Operator, actualResult);
        }

        [TestMethod]
        public void CheckOperatorTokenType()
        {
            // Arrange

            string stringInput = "-";

            // Act
            var actualResult = TokenDefinition.DefineTokenType(stringInput);

            // Assert

            Assert.AreEqual(ClassLibrary.Enum.TokenType.Operator, actualResult);
        }

        [TestMethod]
        public void CheckNumberValueTokenType1()
        {
            // Arrange

            string stringInput = "3";

            // Act
            var actualResult = TokenDefinition.DefineTokenType(stringInput);

            // Assert

            Assert.AreEqual(ClassLibrary.Enum.TokenType.NumberValue, actualResult);
        }

        [TestMethod]
        public void CheckNumberValueTokenType2()
        {
            // Arrange

            string stringInput = "9";

            // Act
            var actualResult = TokenDefinition.DefineTokenType(stringInput);

            // Assert

            Assert.AreEqual(ClassLibrary.Enum.TokenType.NumberValue, actualResult);
        }

        [TestMethod]
        public void CheckBlockInTokenType1()
        {
            // Arrange

            string stringInput = "[";

            // Act
            var actualResult = TokenDefinition.DefineTokenType(stringInput);

            // Assert

            Assert.AreEqual(ClassLibrary.Enum.TokenType.BlockIn, actualResult);
        }

        [TestMethod]
        public void CheckBlockInTokenType2()
        {
            // Arrange

            string stringInput = "{";

            // Act
            var actualResult = TokenDefinition.DefineTokenType(stringInput);

            // Assert

            Assert.AreEqual(ClassLibrary.Enum.TokenType.BlockIn, actualResult);
        }

        [TestMethod]
        public void CheckBlockInTokenType3()
        {
            // Arrange

            string stringInput = "{";

            // Act
            var actualResult = TokenDefinition.DefineTokenType(stringInput);

            // Assert

            Assert.AreEqual(ClassLibrary.Enum.TokenType.BlockIn, actualResult);
        }

        [TestMethod]
        public void CheckBlockOutTokenType1()
        {
            // Arrange

            string stringInput = ")";

            // Act
            var actualResult = TokenDefinition.DefineTokenType(stringInput);

            // Assert

            Assert.AreEqual(ClassLibrary.Enum.TokenType.BlockOut, actualResult);
        }

        [TestMethod]
        public void CheckBlockOutTokenType2()
        {
            // Arrange

            string stringInput = "]";

            // Act
            var actualResult = TokenDefinition.DefineTokenType(stringInput);

            // Assert

            Assert.AreEqual(ClassLibrary.Enum.TokenType.BlockOut, actualResult);
        }

        [TestMethod]
        public void CheckBlockOutTokenType3()
        {
            // Arrange

            string stringInput = "}";

            // Act
            var actualResult = TokenDefinition.DefineTokenType(stringInput);

            // Assert

            Assert.AreEqual(ClassLibrary.Enum.TokenType.BlockOut, actualResult);
        }

        [TestMethod]
        public void CheckIllegalTokenType1()
        {
            // Arrange

            string stringInput = "£";
            bool pass = false;

            // Act
            try
            {
                var actualResult = TokenDefinition.DefineTokenType(stringInput);
                // Throws error if illegal symbol is attempted to be defined

            }
            catch (ArgumentException e)
            {
                pass = true;
            }

            // Assert

            Assert.IsTrue(pass);

        }

        [TestMethod]
        public void CheckIllegalTokenType2()
        {
            // Arrange

            string stringInput = "k";
            bool pass = false;

            // Act
            try
            {
                var actualResult = TokenDefinition.DefineTokenType(stringInput);
                // Throws error if illegal symbol is attempted to be defined

            }
            catch (ArgumentException e)
            {
                pass = true;
            }

            // Assert

            Assert.IsTrue(pass);

        }
    }
}

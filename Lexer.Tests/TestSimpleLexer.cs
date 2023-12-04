using Lexer.Tokenizer;
using Lexer.Tokens;

namespace Lexer.Tests
{
    [TestClass]
    public class TestSimpleLexer
    {
        /// <summary>
        /// An untested lexer.
        /// </summary>
        ILexer lexer;

        /// <summary>
        /// A tokenizer which has verified functionality.
        /// </summary>
        ITokenizer testedTokenizer;

        [TestInitialize]
        public void TestInitialize()
        {
            lexer = new SimpleLexer();
            testedTokenizer = new SimpleTokenizer();
        }

        [TestMethod]
        public void TestSimpleOperator()
        {
            string expression = "1+2";

            var tokenized = testedTokenizer.Tokenize(expression);
            LexicalToken[] lexedTokens = lexer.Lexer(tokenized).ToArray();

            Assert.IsInstanceOfType<IntegralToken>(lexedTokens[0]);
            Assert.AreEqual(1, ((IntegralToken)lexedTokens[0]).IntegralValue);

            Assert.IsInstanceOfType<OperatorToken>(lexedTokens[1]);
            Assert.AreEqual(MathOperator.Add, ((OperatorToken)lexedTokens[1]).OperatorType);

            Assert.IsInstanceOfType<IntegralToken>(lexedTokens[2]);
            Assert.AreEqual(2, ((IntegralToken)lexedTokens[2]).IntegralValue);
        }

        [TestMethod]
        public void TestMultipleOperators()
        {
            string expression = "1+2+3+4";

            var tokenized = testedTokenizer.Tokenize(expression);
            LexicalToken[] lexedTokens = lexer.Lexer(tokenized).ToArray();

            Assert.IsInstanceOfType<IntegralToken>(lexedTokens[0]);
            Assert.AreEqual(1, ((IntegralToken)lexedTokens[0]).IntegralValue);

            Assert.IsInstanceOfType<OperatorToken>(lexedTokens[1]);
            Assert.AreEqual(MathOperator.Add, ((OperatorToken)lexedTokens[1]).OperatorType);

            Assert.IsInstanceOfType<IntegralToken>(lexedTokens[2]);
            Assert.AreEqual(2, ((IntegralToken)lexedTokens[2]).IntegralValue);

            Assert.IsInstanceOfType<OperatorToken>(lexedTokens[3]);
            Assert.AreEqual(MathOperator.Add, ((OperatorToken)lexedTokens[3]).OperatorType);

            Assert.IsInstanceOfType<IntegralToken>(lexedTokens[4]);
            Assert.AreEqual(3, ((IntegralToken)lexedTokens[4]).IntegralValue);

            Assert.IsInstanceOfType<OperatorToken>(lexedTokens[5]);
            Assert.AreEqual(MathOperator.Add, ((OperatorToken)lexedTokens[5]).OperatorType);

            Assert.IsInstanceOfType<IntegralToken>(lexedTokens[6]);
            Assert.AreEqual(4, ((IntegralToken)lexedTokens[6]).IntegralValue);
        }

        [TestMethod]
        public void TestMultipleDigits()
        {
            string expression = "10+20";

            var tokenized = testedTokenizer.Tokenize(expression);
            LexicalToken[] lexedTokens = lexer.Lexer(tokenized).ToArray();

            Assert.IsInstanceOfType<IntegralToken>(lexedTokens[0]);
            Assert.AreEqual(10, ((IntegralToken)lexedTokens[0]).IntegralValue);

            Assert.IsInstanceOfType<OperatorToken>(lexedTokens[1]);
            Assert.AreEqual(MathOperator.Add, ((OperatorToken)lexedTokens[1]).OperatorType);

            Assert.IsInstanceOfType<IntegralToken>(lexedTokens[2]);
            Assert.AreEqual(20, ((IntegralToken)lexedTokens[2]).IntegralValue);
        }

        [TestMethod]
        public void TestManyDigits()
        {
            string expression = "123456789+23456789";

            var tokenized = testedTokenizer.Tokenize(expression);
            LexicalToken[] lexedTokens = lexer.Lexer(tokenized).ToArray();

            Assert.IsInstanceOfType<IntegralToken>(lexedTokens[0]);
            Assert.AreEqual(123456789, ((IntegralToken)lexedTokens[0]).IntegralValue);

            Assert.IsInstanceOfType<OperatorToken>(lexedTokens[1]);
            Assert.AreEqual(MathOperator.Add, ((OperatorToken)lexedTokens[1]).OperatorType);

            Assert.IsInstanceOfType<IntegralToken>(lexedTokens[2]);
            Assert.AreEqual(23456789, ((IntegralToken)lexedTokens[2]).IntegralValue);
        }
    }
}

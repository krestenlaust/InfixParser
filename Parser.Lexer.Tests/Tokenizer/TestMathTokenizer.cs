namespace Parser.Lexer.Tests.Tokenizer
{
    [TestClass]
    public class TestMathTokenizer
    {
        ITokenizer tokenizer;

        [TestInitialize]
        public void TestInitialize()
        {
            tokenizer = new SimpleTokenizer();
        }

        [TestMethod]
        public void TestSimpleOperator()
        {
            string expression = "1+2";

            string[] tokens = tokenizer.Tokenize(expression).ToArray();

            Assert.AreEqual("1", tokens[0]);
            Assert.AreEqual("+", tokens[1]);
            Assert.AreEqual("2", tokens[2]);
        }

        [TestMethod]
        public void TestMultipleOperators()
        {
            string expression = "1+2+3+4";

            string[] tokens = tokenizer.Tokenize(expression).ToArray();;

            Assert.AreEqual("1", tokens[0]);
            Assert.AreEqual("+", tokens[1]);
            Assert.AreEqual("2", tokens[2]);
            Assert.AreEqual("+", tokens[3]);
            Assert.AreEqual("3", tokens[4]);
            Assert.AreEqual("+", tokens[5]);
            Assert.AreEqual("4", tokens[6]);
        }

        [TestMethod]
        public void TestMultipleDigits()
        {
            string expression = "10+20+30+40";

            string[] tokens = tokenizer.Tokenize(expression).ToArray();;

            Assert.AreEqual("10", tokens[0]);
            Assert.AreEqual("+", tokens[1]);
            Assert.AreEqual("20", tokens[2]);
            Assert.AreEqual("+", tokens[3]);
            Assert.AreEqual("30", tokens[4]);
            Assert.AreEqual("+", tokens[5]);
            Assert.AreEqual("40", tokens[6]);
        }

        [TestMethod]
        public void TestManyDigits()
        {
            string expression = "123456789+23456789+3456789+456789";

            string[] tokens = tokenizer.Tokenize(expression).ToArray();;

            Assert.AreEqual("123456789", tokens[0]);
            Assert.AreEqual("+", tokens[1]);
            Assert.AreEqual("23456789", tokens[2]);
            Assert.AreEqual("+", tokens[3]);
            Assert.AreEqual("3456789", tokens[4]);
            Assert.AreEqual("+", tokens[5]);
            Assert.AreEqual("456789", tokens[6]);
        }

        [TestMethod]
        public void TestWithParenthesis()
        {
            string expression = "1+(2-3)";

            string[] tokens = tokenizer.Tokenize(expression).ToArray();;

            Assert.AreEqual("1", tokens[0]);
            Assert.AreEqual("+", tokens[1]);
            Assert.AreEqual("(", tokens[2]);
            Assert.AreEqual("2", tokens[3]);
            Assert.AreEqual("-", tokens[4]);
            Assert.AreEqual("3", tokens[5]);
            Assert.AreEqual(")", tokens[6]);
        }

        [TestMethod]
        public void TestWithParenthesisMultipleDigits()
        {
            string expression = "123+(23-3000)";

            string[] tokens = tokenizer.Tokenize(expression).ToArray();;

            Assert.AreEqual("123", tokens[0]);
            Assert.AreEqual("+", tokens[1]);
            Assert.AreEqual("(", tokens[2]);
            Assert.AreEqual("23", tokens[3]);
            Assert.AreEqual("-", tokens[4]);
            Assert.AreEqual("3000", tokens[5]);
            Assert.AreEqual(")", tokens[6]);
        }

        [TestMethod]
        public void TestWithWhitespaces()
        {
            string expression = "123 + 321";

            string[] tokens = tokenizer.Tokenize(expression).ToArray();;

            Assert.AreEqual("123", tokens[0]);
            Assert.AreEqual("+", tokens[1]);
            Assert.AreEqual("321", tokens[2]);
        }

        [TestMethod]
        public void TestWithWhitespacesWeird1()
        {
            string expression = "1 2 3 + 3 21";

            string[] tokens = tokenizer.Tokenize(expression).ToArray();;

            // We expect the tokenizer to strip spaces around tokens, but not inside.
            Assert.AreEqual("1 2 3", tokens[0]);
            Assert.AreEqual("+", tokens[1]);
            Assert.AreEqual("3 21", tokens[2]);
        }

        [TestMethod]
        public void TestWithWhitespacesWeird2()
        {
            string expression = "22 22 22 * 123 123 * 3";

            string[] tokens = tokenizer.Tokenize(expression).ToArray();;

            // We expect the tokenizer to strip spaces around tokens, but not inside.
            Assert.AreEqual("22 22 22", tokens[0]);
            Assert.AreEqual("*", tokens[1]);
            Assert.AreEqual("123 123", tokens[2]);
            Assert.AreEqual("*", tokens[3]);
            Assert.AreEqual("3", tokens[4]);
        }

        [TestMethod]
        public void TestInvalidExpression1()
        {
            string expression = "++--";

            string[] tokens = tokenizer.Tokenize(expression).ToArray();;

            // Invalid expressions should be tokenized as well, for the parser to be able to deem them invalid.
            Assert.AreEqual("+", tokens[0]);
            Assert.AreEqual("+", tokens[1]);
            Assert.AreEqual("-", tokens[2]);
            Assert.AreEqual("-", tokens[3]);
        }

        [TestMethod]
        public void TestInvalidExpression2()
        {
            string expression = "))((";

            string[] tokens = tokenizer.Tokenize(expression).ToArray();;

            // Invalid expressions should be tokenized as well, for the parser to be able to deem them invalid.
            Assert.AreEqual(")", tokens[0]);
            Assert.AreEqual(")", tokens[1]);
            Assert.AreEqual("(", tokens[2]);
            Assert.AreEqual("(", tokens[3]);
        }
    }
}

namespace Parser.Tests
{
    [TestClass]
    public class TestMathTokenizer
    {
        ITokenizer tokenizer;

        [TestInitialize]
        public void TestInitialize()
        {
            tokenizer = new Tokenizer();
        }

        [TestMethod]
        public void TestSimpleOperator()
        {
            string expression = "1+2";

            string[] tokens = tokenizer.Tokenize(expression);

            Assert.AreEqual("1", tokens[0]);
            Assert.AreEqual("+", tokens[1]);
            Assert.AreEqual("2", tokens[2]);
        }

        [TestMethod]
        public void TestMultipleOperators()
        {
            string expression = "1+2+3+4";

            string[] tokens = tokenizer.Tokenize(expression);

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

            string[] tokens = tokenizer.Tokenize(expression);

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

            string[] tokens = tokenizer.Tokenize(expression);

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

            string[] tokens = tokenizer.Tokenize(expression);

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

            string[] tokens = tokenizer.Tokenize(expression);

            Assert.AreEqual("123", tokens[0]);
            Assert.AreEqual("+", tokens[1]);
            Assert.AreEqual("(", tokens[2]);
            Assert.AreEqual("23", tokens[3]);
            Assert.AreEqual("-", tokens[4]);
            Assert.AreEqual("3000", tokens[5]);
            Assert.AreEqual(")", tokens[6]);
        }
    }
}

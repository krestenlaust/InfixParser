namespace Parser.Tests
{
    [TestClass]
    public class TestIntegerEvaluator
    {
        IMathEvaluator<int> evaluator;

        [TestInitialize]
        public void TestInitialize()
        {
            evaluator = new IntegerEvaluator();
        }

        [TestMethod]
        public void TestSimpleAddition()
        {
            string addition1 = "2+2";
            string addition2 = "100+200";

            int result1 = evaluator.Eval(addition1);
            int result2 = evaluator.Eval(addition2);

            Assert.AreEqual(2+2, result1);
            Assert.AreEqual(100+200, result2);
        }

        [TestMethod]
        public void TestSimpleSubtraction()
        {
            string addition1 = "2-2";
            string addition2 = "100-200";

            int result1 = evaluator.Eval(addition1);
            int result2 = evaluator.Eval(addition2);

            Assert.AreEqual(2 - 2, result1);
            Assert.AreEqual(100 - 200, result2);
        }

        [TestMethod]
        public void TestMultipleSubtraction()
        {
            string sub1 = "2-3-5";
            string sub2 = "300-100-200";

            int result1 = evaluator.Eval(sub1);
            int result2 = evaluator.Eval(sub2);

            Assert.AreEqual(2 - 3 - 5, result1);
            Assert.AreEqual(300 - 100 - 200, result2);
        }

        [TestMethod]
        public void TestMultipleAddition()
        {
            string sub1 = "15+10+20";
            string sub2 = "1000+1000+1500";

            int result1 = evaluator.Eval(sub1);
            int result2 = evaluator.Eval(sub2);

            Assert.AreEqual(15 + 10 + 20, result1);
            Assert.AreEqual(1000 + 1000 + 1500, result2);
        }

        [TestMethod]
        public void TestSimpleParenthesis()
        {
            string paren1 = "2-(5-3)";
            string paren2 = "(2-5)-3";

            int result1 = evaluator.Eval(paren1);
            int result2 = evaluator.Eval(paren2);

            Assert.AreEqual(2 - (5 - 3), result1);
            Assert.AreEqual((2 - 5) - 3, result2);
        }

        [TestMethod]
        public void TestSimpleMultiplication()
        {
            string addition1 = "2*2";
            string addition2 = "100*200";

            int result1 = evaluator.Eval(addition1);
            int result2 = evaluator.Eval(addition2);

            Assert.AreEqual(2 * 2, result1);
            Assert.AreEqual(100 * 200, result2);
        }

        [TestMethod]
        public void TestMultipleMultiplication()
        {
            string addition1 = "2*2*2";
            string addition2 = "100*200*300";

            int result1 = evaluator.Eval(addition1);
            int result2 = evaluator.Eval(addition2);

            Assert.AreEqual(2 * 2 * 2, result1);
            Assert.AreEqual(100 * 200 * 300, result2);
        }

        [TestMethod]
        public void TestSimpleDivisionIntegers()
        {
            string addition1 = "2/2";
            string addition2 = "200/100";

            int result1 = evaluator.Eval(addition1);
            int result2 = evaluator.Eval(addition2);

            Assert.AreEqual(2 / 2, result1);
            Assert.AreEqual(200 / 100, result2);
        }

        [TestMethod]
        public void TestSimpleDivisionWithRemainders()
        {
            string addition1 = "5/3";
            string addition2 = "225/100";

            int result1 = evaluator.Eval(addition1);
            int result2 = evaluator.Eval(addition2);

            Assert.AreEqual(1, result1);
            Assert.AreEqual(2, result2);
        }

        [TestMethod]
        public void TestMultipleDivision()
        {
            string addition1 = "5/5/5";
            string addition2 = "300/20/3";

            int result1 = evaluator.Eval(addition1);
            int result2 = evaluator.Eval(addition2);

            Assert.AreEqual(1, result1);
            Assert.AreEqual(300 / 20 / 3, result2);
        }

        [TestMethod]
        public void TestMixedPrecedence()
        {
            string addition1 = "5+5*5";
            string addition2 = "5*5+5";

            int result1 = evaluator.Eval(addition1);
            int result2 = evaluator.Eval(addition2);

            Assert.AreEqual(5 + 5 * 5, result1);
            Assert.AreEqual(5 * 5 + 5, result2);
        }
    }
}
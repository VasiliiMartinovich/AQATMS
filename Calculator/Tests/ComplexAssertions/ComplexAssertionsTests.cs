using Calculator.Hooks;
using Calculator.TestData;
using NUnit.Framework.Legacy;

namespace Calculator.Tests.ComplexAssertions;

[TestFixture]
[Parallelizable(ParallelScope.Children)]
public class ComplexAssertionsTests : BaseTest
{
    [Test]
    public void GetResultAsStringShouldContainText()
    {
        var result = Calculator.GetResultAsString(5, 8);

        StringAssert.Contains("Add result", result);
    }

    [Test]
    public void GetResultAsStringStartWithText()
    {
        var result = Calculator.GetResultAsString(55, 33);

        StringAssert.StartsWith("Add", result);
    }
    
    [Test]
    public void GetResultAsStringContainsText()
    {
        var result = Calculator.GetResultAsString(51, 1);

        StringAssert.Contains("result", result);
    }

    [Test]
    public void MultiplicationResultsEquality()
    {
        var actualResults = Calculator.GetMultiplicationResults(5);
        var expectedResults = new List<int>
        {
            5,
            10,
            15,
            20
        };
        CollectionAssert.AreEqual(actualResults, expectedResults);
    }

    [Test]
    public void MultiplicationResultsContainsValue()
    {
        var actualResults = Calculator.GetMultiplicationResults(5);
        CollectionAssert.Contains(actualResults, 20);
    }

    [Test]
    public void AddMultipleAssertions()
    {
        var result = Calculator.Add(14, 20);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(34));
            Assert.That(result, Is.GreaterThan(33));
            Assert.That(result, Is.Not.EqualTo(-34));
        });
    }

    [TestCaseSource(typeof(CalculatorTestData), nameof(CalculatorTestData.MultiplicationTests))]
    public void MultiplyTest(int n, int d, int q)
    {
        ClassicAssert.AreEqual(q, n * d);
    }

    [TestCaseSource(typeof(CalculatorTestData), nameof(CalculatorTestData.AdditionTests))]
    public void AddTest(int n, int d, int q)
    { 
        ClassicAssert.AreEqual(q, n + d);
    }
    
    [Test]
    public void DivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => { Calculator.Divide(10, 0); });
    }
}

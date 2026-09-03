namespace Calculator.TestData;

public static class CalculatorTestData
{
    public static IEnumerable<TestCaseData> AdditionTests()
    {
        yield return new TestCaseData(1, 1, 2);
        yield return new TestCaseData(5, 5, 10);
        yield return new TestCaseData(10, 20, 30);
        yield return new TestCaseData(-10, 10, 0);
        yield return new TestCaseData(100, 50, 150);
    }
    public static IEnumerable<TestCaseData> MultiplicationTests()
    {
        yield return new TestCaseData(2, 3, 6);
        yield return new TestCaseData(5, 5, 25);
        yield return new TestCaseData(10, 10, 100);
        yield return new TestCaseData(-2, 5, -10);
    }
}
using Calculator.Hooks;

namespace Calculator.Tests.SimpleAssertions;

[TestFixture]
[Parallelizable(ParallelScope.Children)]
public class SimpleAssertionsTests : BaseTest
{
    [Test]
    public void AddCheckout()
    {
        var result = Calculator.Add(5, 7);
        Assert.That(result, Is.EqualTo(12));
    }
    
    [Test]
    public void SubtractCheckout()
    {
        var result = Calculator.Subtract(6, 3);
        Assert.That(result, Is.GreaterThanOrEqualTo(3));
    }
    
    [Test]
    public void SubtractCheckoutNull()
    {
        var result = Calculator.Subtract(88, -88);
        Assert.That(result, Is.Not.Zero);
        Assert.That(result, Is.GreaterThanOrEqualTo(88));
    }
    
    [Test]
    public void MultiplyCheckout()
    {
        var result = Calculator.Multiply(12, 4);
        Assert.That(result, Is.Positive);
    }
    
    [Test]
    public void DivideCheckout()
    {
        var result = Calculator.Divide(12, 4);
        Assert.That(result, Is.Not.EqualTo(5));
    }
    
    [TestCase(12, -3,  9)]
    [TestCase(120, 0, 120)]
    [TestCase(-77, 4, -73)]
    public void AddDifferentNumbers(int firstNumber, int secondNumber, int expectedResult)
    {
        var result = Calculator.Add(firstNumber, secondNumber);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
    
    [TestCase(12, 12,  1)]
    [TestCase(120, 10, 12)]
    [TestCase(10, -2, -5)]
    public void DivideDifferentNumbers(int firstNumber, int secondNumber, int expectedResult)
    {
        var result = Calculator.Divide(firstNumber, secondNumber);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
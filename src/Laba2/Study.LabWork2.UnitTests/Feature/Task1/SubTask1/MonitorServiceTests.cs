using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask1;
using System.Linq;

namespace Study.LabWork2.Tests;

[TestFixture]
public class MonitorServiceTests
{
    private MonitorService _service;

    [SetUp]
    public void Setup()
    {
        _service = new MonitorService();
    }

    // Тест для IsPrime на небольших числах
    [TestCase(2, true)]
    [TestCase(3, true)]
    [TestCase(4, false)]
    [TestCase(5, true)]
    [TestCase(10, false)]
    [TestCase(13, true)]
    [TestCase(1, false)]
    [TestCase(0, false)]
    [TestCase(-5, false)]
    public void IsPrime_ReturnsCorrect(int number, bool expected)
    {
        var result = _service.IsPrime(number);
        Assert.That(result, Is.EqualTo(expected));
    }

    // Проверка, что CountPrimes возвращает правильное количество простых чисел
    // для диапазона от 1 до 100 при использовании 4 потоков
    [Test]
    public void CountPrimes_From1To100_With4Threads_Returns25()
    {
        // Эталонное количество простых чисел от 1 до 100 = 25
        const int expectedPrimeCount = 25;
        var result = _service.CountPrimes(1, 100, 4);
        Assert.That(result.PrimeCount, Is.EqualTo(expectedPrimeCount));
    }

    // Проверка для диапазона 1-1000 (168 простых чисел)
    [Test]
    public void CountPrimes_From1To1000_With8Threads_Returns168()
    {
        const int expectedPrimeCount = 168;
        var result = _service.CountPrimes(1, 1000, 8);
        Assert.That(result.PrimeCount, Is.EqualTo(expectedPrimeCount));
    }


    // Проверка корректности границ — если start > end, должно быть 0
    [Test]
    public void CountPrimes_StartGreaterThanEnd_ReturnsZero()
    {
        var result = _service.CountPrimes(100, 1, 4);
        Assert.That(result.PrimeCount, Is.EqualTo(0));
    }

    // Проверка, что время выполнения не отрицательное и разумное
    [Test]
    public void CountPrimes_ReturnsNonNegativeExecutionTime()
    {
        var result = _service.CountPrimes(1, 1000, 4);
        Assert.That(result.ExecutionTime.TotalMilliseconds, Is.GreaterThanOrEqualTo(0));
    }
}

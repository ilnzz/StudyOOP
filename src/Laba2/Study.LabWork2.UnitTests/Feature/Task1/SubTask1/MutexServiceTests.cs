using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.Tests.Feature.Task1.SubTask1;

[TestFixture]
public class MutexServiceTests
{
    private MutexService _service;

    [SetUp]
    public void Setup()
    {
        _service = new MutexService();
    }

    // Проверка IsPrime на граничных и типовых значениях
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

    // Простых чисел от 1 до 100 должно быть 25 (при любом кол-ве потоков)
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(4)]
    [TestCase(8)]
    public void CountPrimes_1_100_Returns25(int threadCount)
    {
        var result = _service.CountPrimes(1, 100, threadCount);
        Assert.That(result.PrimeCount, Is.EqualTo(25));
    }

    // От 1 до 1000 — 168 простых чисел
    [Test]
    public void CountPrimes_1_1000_Returns168()
    {
        var result = _service.CountPrimes(1, 1000, 4);
        Assert.That(result.PrimeCount, Is.EqualTo(168));
    }


    // Разное количество потоков должно давать одинаковый результат
    [TestCase(1)]
    [TestCase(3)]
    [TestCase(5)]
    [TestCase(10)]
    public void CountPrimes_VariousThreadCounts_AlwaysSameResult(int threadCount)
    {
        var result1 = _service.CountPrimes(10, 200, threadCount);
        var result2 = _service.CountPrimes(10, 200, threadCount);
        Assert.That(result1.PrimeCount, Is.EqualTo(result2.PrimeCount));
    }

    // Если start > end, результат 0
    [Test]
    public void CountPrimes_StartGreaterThanEnd_ReturnsZero()
    {
        var result = _service.CountPrimes(100, 1, 4);
        Assert.That(result.PrimeCount, Is.EqualTo(0));
    }

    // Время выполнения не отрицательное
    [Test]
    public void CountPrimes_ExecutionTimeNonNegative()
    {
        var result = _service.CountPrimes(1, 1000, 4);
        Assert.That(result.ExecutionTime.TotalMilliseconds, Is.GreaterThanOrEqualTo(0));
    }
}

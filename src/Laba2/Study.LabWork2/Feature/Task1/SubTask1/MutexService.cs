using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Версия 2. Использует Mutex для синхронизации (исправленная)
/// </summary>
public sealed class MutexService : IPrimeCounter
{
    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        int total = end - start + 1;
        int perThread = total / threadCount;
        int primeCounter = 0;
        var threads = new List<Thread>();

        using var mutex = new Mutex(); // автоматическое освобождение
        var sw = Stopwatch.StartNew();

        for (int i = 0; i < threadCount; i++)
        {
            int threadId = i;

            // Корректное вычисление границ для каждого потока
            int from = start + threadId * perThread;
            int to = (threadId == threadCount - 1) ? end : start + (threadId + 1) * perThread - 1;

            var thread = new Thread(() =>
            {
                for (int digit = from; digit <= to; digit++)
                {
                    // Для отладки, но можно убрать, если не нужно
                    // Console.WriteLine($"Thread: {threadId} - checks {digit}");

                    if (IsPrime(digit))
                    {
                        // Безопасный захват мьютекса
                        bool acquired = false;
                        try
                        {
                            mutex.WaitOne();
                            acquired = true;
                            primeCounter++;
                            Console.WriteLine($"Thread {threadId} found {digit}");
                        }
                        finally
                        {
                            if (acquired)
                                mutex.ReleaseMutex();
                        }
                    }
                }
            });

            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
            thread.Join();

        sw.Stop();

        return new PrimeCountResultDto
        {
            PrimeCount = primeCounter,
            ExecutionTime = TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds)
        };
    }

    public bool IsPrime(int digit)
    {
        if (digit < 2) return false;
        if (digit == 2) return true;
        if (digit % 2 == 0) return false;

        int limit = (int)Math.Sqrt(digit);
        for (int i = 3; i <= limit; i += 2)
            if (digit % i == 0)
                return false;
        return true;
    }

    public string GetVersionName() => "Mutex";
}

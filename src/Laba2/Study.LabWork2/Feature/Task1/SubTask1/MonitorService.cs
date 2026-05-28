using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Версия 1. Использует Monitor (lock) для синхронизации
/// </summary>
public sealed class MonitorService : IPrimeCounter
{
    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        var total = end - start + 1;
        var perThread = total / threadCount;
        var locker = new object();
        var primeCounter = 0;
        List<Thread> threads = new();

        var sw = Stopwatch.StartNew();

        for (int i = 0; i < threadCount; i++)
        {
            var threadId = i;


            var thread = new Thread(() =>
            {
                int from = start + threadId * perThread;
                int to = (threadId == threadCount - 1) ? end : start + (threadId + 1) * perThread - 1;
                for (int digit = from; digit <= to; digit++)
                {
                    Console.WriteLine($"Thread: {threadId} - checks {digit}");
                    if (IsPrime(digit))
                    {
                        lock (locker)
                        {
                            primeCounter++;
                        }

                        Console.WriteLine($"Thread {threadId} found {digit}");
                    }
                }
            });

            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        sw.Stop();


        return new PrimeCountResultDto { PrimeCount = primeCounter, ExecutionTime = TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds) };
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

    public string GetVersionName() => "Monitor";
}

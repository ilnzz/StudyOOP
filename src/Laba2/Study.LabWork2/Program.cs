using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2;

public static class Program
{
    public static void Main()
    {
        var monitorService = new MonitorService();
        var monitorResultDto = monitorService.CountPrimes(1, 10000, 10);

        

        Console.WriteLine("==========");

        var mutexService = new MutexService();
        var mutexResultDto = mutexService.CountPrimes(1, 10000, 10);



        Console.WriteLine("=============");

        var semService = new SemaphoreService();
        var semServiceDto = semService.CountPrimes(1, 10000, 10);

        Console.WriteLine($"Found {monitorResultDto.PrimeCount} digits in {monitorResultDto.ExecutionTime}ms");
        Console.WriteLine($"Found {mutexResultDto.PrimeCount} digits in {mutexResultDto.ExecutionTime}ms");
        Console.WriteLine($"Found {semServiceDto.PrimeCount} digits in {semServiceDto.ExecutionTime}ms");
    }
}

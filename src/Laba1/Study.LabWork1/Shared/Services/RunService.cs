using Study.LabWork1.Features.Task1;
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Реализация заданий Л/Р
/// </summary>
public class RunService : IRunService
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1()
    {
        MyVector a = new MyVector(1, 2);
        MyVector b = new MyVector(3, 4);

        Console.WriteLine($"a: {a}, b: {b}\n\n");

        Console.WriteLine($"Sum: {a + b}");
        Console.WriteLine($"Minus: {a - b}");
        Console.WriteLine($"Multiply: {a * b}");
        Console.WriteLine($"Is equal: {a == b}");
        Console.WriteLine($"Is not equal: {a != b}");
        Console.WriteLine($"Length: {+a}");
    }

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2() => throw new NotImplementedException();

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}

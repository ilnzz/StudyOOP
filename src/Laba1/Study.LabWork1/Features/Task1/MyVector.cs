namespace Study.LabWork1.Features.Task1;

public class MyVector(float x, float y)
{
    private readonly float _startX = 0;
    private readonly float _startY = 0;

    public float DirectionX { get; } = x;
    public float DirectionY { get; } = y;


    public static MyVector operator +(MyVector v1, MyVector v2)
    {
        return new MyVector(v1.DirectionX + v2.DirectionX, v1.DirectionY + v2.DirectionY);
    }

    public static MyVector operator -(MyVector v1, MyVector v2)
    {
        return new MyVector(v1.DirectionX - v2.DirectionX, v1.DirectionY - v2.DirectionY);
    }

    public static float operator *(MyVector v1, MyVector v2)
    {
        return v1.DirectionX * v2.DirectionX + v1.DirectionY * v2.DirectionY;
    }

    public static bool operator ==(MyVector v1, MyVector v2)
    {
        return (v1.DirectionX == v2.DirectionX && v1.DirectionY == v2.DirectionY);
    }

    public static bool operator !=(MyVector v1, MyVector v2)
    {
        return (v1.DirectionX != v2.DirectionX || v1.DirectionY != v2.DirectionY);
    }

    public static float operator +(MyVector v1)
    {
        return (float)Math.Sqrt(Math.Pow(v1.DirectionX, 2) + Math.Pow(v1.DirectionY, 2));
    }

    public override string ToString() => $"({DirectionX}, {DirectionY})";
}

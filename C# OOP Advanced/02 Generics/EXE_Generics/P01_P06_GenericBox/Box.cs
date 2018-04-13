using System;

public class Box<T> : IComparable<Box<T>>
where T : IComparable
{
    public Box(T item)
    {
        this.Value = item;
    }

    public T Value { get; set; }

    public int CompareTo(Box<T> other)
    {
        return this.Value.CompareTo(other.Value);
    }

    public override string ToString()
    {
        return $"{Value.GetType().FullName}: {Value}";
    }
}


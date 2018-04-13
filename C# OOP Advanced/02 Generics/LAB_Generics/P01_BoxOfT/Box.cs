using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    private List<T> box;

    public Box()
    {
        box = new List<T>();
    }

    public int Count => box.Count;

    public void Add(T element)
    {
        box.Add(element);
    }

    public T Remove()
    {
        var element = box.Last();
        box.RemoveAt(box.Count - 1);
        return element;
    }
}


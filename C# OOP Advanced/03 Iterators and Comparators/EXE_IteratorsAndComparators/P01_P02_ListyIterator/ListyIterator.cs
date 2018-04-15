using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T> : IEnumerable<T>
{
    public ListyIterator()
    {
        this.internalList = new List<T>();
        this.CurrentIndex = 0;
    }

    public ListyIterator(IEnumerable<T> items)
        :base()
    {
        this.internalList = items.ToList();
    }

    private IReadOnlyList<T> internalList { get; }

    private int CurrentIndex { get; set; }

    public bool HasNext()
    {
        return this.CurrentIndex + 1 < this.internalList.Count;
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            CurrentIndex++;
            return true;
        }

        return false;
    }

    public void Print()
    {
        if (!this.internalList.Any())
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine($"{this.internalList[this.CurrentIndex]}");
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.internalList.Count; i++)
        {
            yield return this.internalList[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

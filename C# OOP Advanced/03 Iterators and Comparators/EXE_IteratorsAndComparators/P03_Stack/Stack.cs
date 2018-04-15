using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Stack<T> : IEnumerable<T>
{
    private List<T> internalList;

    public Stack()
    {
        this.internalList = new List<T>();
    }

    public void Push(T item)
    {
        this.internalList.Add(item);
    }

    public T Pop()
    {
        if (this.internalList.Count == 0)
        {
            throw new InvalidOperationException("No elements");
        }

        var elementToBeRemoved = this.internalList.Last();
        this.internalList.RemoveAt(this.internalList.Count - 1);
        return elementToBeRemoved;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.internalList.Count - 1; i >= 0; i--)
        {
            yield return this.internalList[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

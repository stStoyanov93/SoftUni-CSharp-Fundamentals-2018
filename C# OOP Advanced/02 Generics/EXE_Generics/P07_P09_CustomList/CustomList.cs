using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class CustomList<T> : IEnumerable<T>
    where T : IComparable<T>
{
    private T[] internalArray;

   public CustomList()
    {
        this.internalArray = new T[4];
        this.Count = 0;
    }

    private int Size => this.internalArray.Length;

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            return this.internalArray[index];
        }
        set
        {
            this.internalArray[index] = value;
        }
    }

    public void Add(T item)
    {
        this.Count++;

        if (this.Count >= this.Size)
        {
            T[] newArr = new T[this.Size * 2];
            Array.Copy(this.internalArray, newArr, this.Size);
            this.internalArray = newArr;
        }

        this.internalArray[this.Count - 1] = item;
    }

    public T Remove(int index)
    {
        this.Count--;

        T element = this.internalArray[index];

        for (int i = index; i < this.Count; i++)
        {
            this.internalArray[i] = this.internalArray[i + 1];
        }

        this.internalArray[Count] = default(T);

        if (this.Count < this.Size / 3)
        {
            T[] newArr = new T[this.Size / 2];
            Array.Copy(this.internalArray, newArr, this.Count);
            this.internalArray = newArr;
        }

        return element;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (this.internalArray[i].Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        var element = this.internalArray[firstIndex];
        this.internalArray[firstIndex] = this.internalArray[secondIndex];
        this.internalArray[secondIndex] = element;
    }

    public int CountGreaterThan(T element)
    {
        var countOfBiggerElements = 0;

        for (int i = 0; i < this.Count; i++)
        {
            if (this.internalArray[i].CompareTo(element) > 0)
            {
                countOfBiggerElements++;
            }
        }

        return countOfBiggerElements;
    }

    public T Min()
    {
        T currentMinElement = this.internalArray[0];

        for (int i = 1; i < this.Count; i++)
        {
            if (this.internalArray[i].CompareTo(currentMinElement) < 0)
            {
                currentMinElement = this.internalArray[i];
            }
        }

        return currentMinElement;
    }

    public T Max()
    {
        T currentMaxElement = this.internalArray[0];

        for (int i = 1; i < this.Count; i++)
        {
            if (this.internalArray[i].CompareTo(currentMaxElement) > 0)
            {
                currentMaxElement = this.internalArray[i];
            }
        }

        return currentMaxElement;
    }

    public void Sort(IComparer<T> comparer = null)
    {
        Array.Sort(this.internalArray, 0, this.Count, comparer);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this.internalArray[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

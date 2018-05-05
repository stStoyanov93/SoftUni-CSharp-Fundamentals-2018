using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data = new List<string>();

    public void Push(string item)
    {
        data.Add(item);
    }

    public string Pop()
    {
        var result = string.Empty;

        if (!IsEmpty())
        {
            result = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);          
        }

        return result;
    }

    public string Peek()
    {
        var result = string.Empty;

        if (!IsEmpty())
        {
            result = data[data.Count - 1];
        }

        return result;
    }

    public bool IsEmpty()
    {
        return this.data.Count <= 0;
    }
}


using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    Random rng = new Random();

    public string RandomString()
    {
        string result = null;

        if (this.Count > 0)
        {
            var index = rng.Next(0, this.Count - 1);
            result = this[index];
            this.RemoveAt(index);
        }

        return result;
    }
}


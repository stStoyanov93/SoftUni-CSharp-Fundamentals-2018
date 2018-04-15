using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    private IReadOnlyList<int> stones;

    public Lake(IEnumerable<int> stones)
    {
        this.stones = new List<int>(stones);
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < stones.Count; i += 2)
        {
            if (i % 2 == 0)
            {
                yield return stones[i];
            }
        }

        for (int i = stones.Count - 1; i >= 0; i--)
        {
            if (i % 2 != 0)
            {
                yield return stones[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

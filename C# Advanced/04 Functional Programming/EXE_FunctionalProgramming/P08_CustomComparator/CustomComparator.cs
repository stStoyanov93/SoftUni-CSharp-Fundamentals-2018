using System.Collections.Generic;

namespace P08_CustomComparator
{
    public class CustomComparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }

            if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }

            if (x > y)
            {
                return 1;
            }

            if (x < y)
            {
                return -1;
            }

            return 0;
        }
    }
}

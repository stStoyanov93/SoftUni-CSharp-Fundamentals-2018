using System.Collections.Generic;

public class MyList : IMyList
{
    private readonly List<string> items;

    public MyList()
    {
        this.items = new List<string>();
    }

    public IReadOnlyCollection<string> Items => this.items.AsReadOnly();

    public int Used => this.Items.Count;

    public int Add(string item)
    {
        this.items.Insert(0, item);

        return this.items.IndexOf(item);
    }

    public string Remove()
    {
        var firstItem = this.items[0];
        this.items.Remove(firstItem);

        return firstItem;
    }
}
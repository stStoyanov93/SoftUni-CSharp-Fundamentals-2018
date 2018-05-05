using System.Collections.Generic;

public class AddRemoveCollection : IAddRemoveCollection
{
    private readonly List<string> items;

    public AddRemoveCollection()
    {
        this.items = new List<string>();
    }

    public IReadOnlyCollection<string> Items => this.items.AsReadOnly();

    public int Add(string item)
    {
        this.items.Insert(0, item);

        return this.items.IndexOf(item);
    }

    public string Remove()
    {
        var lastItem = this.items[this.Items.Count - 1];
        this.items.Remove(lastItem);

        return lastItem;
    }
}
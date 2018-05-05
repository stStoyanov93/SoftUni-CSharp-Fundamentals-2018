using System.Collections.Generic;

public class AddCollection : IAddCollection
{
    private readonly List<string> items;

    public AddCollection()
    {
        this.items = new List<string>();
    }

    public IReadOnlyCollection<string> Items => this.items.AsReadOnly();

    public int Add(string item)
    {
        this.items.Add(item);

        return this.Items.Count - 1;
    }
}
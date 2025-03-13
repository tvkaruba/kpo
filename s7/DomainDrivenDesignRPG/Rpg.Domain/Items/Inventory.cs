using System.Text;

namespace Rpg.Domain.Items;

public class Inventory
{
    private readonly List<Item> _items;

    public int Capacity { get; private init; }

    public Inventory(int capacity)
    {
        Capacity = capacity;

        _items = [];
    }

    public bool TryAddItem(Item item)
    {
        if (_items.Count >= Capacity)
            return false;

        _items.Add(item);
        return true;
    }

    public void AddItem(Item item)
        => _items.Add(item);

    public bool RemoveItem(Item item)
        => _items.Remove(item);

    public bool HasItem(string name)
        => _items.Any(i => i.Name == name);

    public Item PeekItem(string name)
        => _items.FirstOrDefault(i => i.Name == name);

    public override string ToString()
    {
        var sb = new StringBuilder("Inventory:");
        foreach (var item in _items.GroupBy(i => i.Name))
            sb.AppendLine($"- {item.Key} x{item.Count()}");
        return sb.ToString();
    }
}

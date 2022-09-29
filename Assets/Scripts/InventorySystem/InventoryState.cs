using System.Collections.Generic;
using UnityEngine;

public class InventoryState
{
    private Dictionary<ItemKind, int> items;

    public Dictionary<ItemKind, int> Items => items;

    public InventoryState()
    {
        items = new Dictionary<ItemKind, int>();
    }

    public void Add(ItemKind kind, int count)
    {
        if (items.ContainsKey(kind))
            items[kind] += count;
        else
        {
            items.Add(kind, count);
        }
    }

    public void Remove(ItemKind kind, int count)
    {
        if(items.ContainsKey(kind))
        {
            items[kind] -= count;
        }
        if(items[kind] <= 0)
            items.Remove(kind);
    }
}

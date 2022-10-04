using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopState
{
    private ShopData data;
    private Dictionary<ItemKind, int> items;
    public ShopData Data => data;

    public Dictionary<ItemKind,int> Items => items;

    public ShopState(ShopKind kind)
    {
        this.data = DownloadData(kind);
        this.items = new Dictionary<ItemKind, int>();

        foreach(var item in data.Items)
        {
            this.items.Add(item.Key, item.Value);
        }
    }

    public Dictionary<ItemKind,int> GetItems()
    {
        return this.items;
    }

    public void AddItem(ItemKind kind, int count)
    {
        if(items.ContainsKey(kind))
        {
            items[kind] += count;
        }
        else
        {
            items.Add(kind, count);
        }
    }

    public void RemoveItem(ItemKind kind, int count)
    {
        if (items.ContainsKey(kind))
        {
            items[kind] -= count;
        }
        if(items[kind] <= 0)
            items.Remove(kind);
    }

    private ShopData DownloadData(ShopKind kind)
    {
        var shopList = Resources.Load<ShopDataList>("ScriptableObjects/Shops/_ShopList");
        return shopList.DownloadData(kind);
    }
}

using System;
using UnityEngine;

[RequireComponent(typeof(ItemView))]
public class Item : ISaveable
{
    private ItemState state;
    private ItemView view;

    public ItemState State => state;

    public Item(Vector3 position, ItemKind kind, int count)
    {
        this.state = new ItemState(kind, count);
        this.view = new GameObject($"{kind}:{count}", typeof(ItemView)).GetComponent<ItemView>().Init(state.Data);
        this.view.gameObject.transform.position = position;
    }

    public void Save()
    {
        var dataForSave = ToJson(this);
    }

    public static string ToJson(Item item)
    {
        var data = item.State.Data;
        var state = item.State;
        var json = "{\"ItemKind\":" + data.Kind + ",\"Count\":" + state.Count + ",";
        json += string.Format($"\"Position\": {0};{1};{2}", item.view.transform.position.x, item.view.transform.position.y, 0);
        return json;
    }

    public static Item CreateFromJSON(string jsonString)
    {
        var s = jsonString.Split(',');

        var kind = (ItemKind) Enum.Parse(typeof(ItemKind), (s[0].Split(':')[1]));
        var count = int.Parse(s[1].Split(':')[1]);

        var posS = s[2].Split(':')[1].Split(';');
        var position = new Vector3(float.Parse(posS[0]), float.Parse(posS[1]), float.Parse(posS[2]));

        return new Item(position,kind,count);
    }
}

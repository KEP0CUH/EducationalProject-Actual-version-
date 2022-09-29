using UnityEngine;

public class ItemState
{
    private ItemData data;              
    private int count;

    public ItemData Data => data;
    public int Count => count;

    public ItemState(ItemData data,int count)
    {
        this.data = data;
        this.count = count;
    }

    public ItemState(ItemKind kind,int count)
    {
        var itemDataList = Resources.Load<ItemDataList>("ScriptableObjects/Items/_ItemList");

        this.data = itemDataList.DownloadData(kind);
        this.count=count;
        Debug.Log(this.Data.Title);
    }

    public void IncreaseCount()
    {
        count++;
    }
}

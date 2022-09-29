using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "_ItemList", menuName = "Storages/Items Data", order = 50)]
public class ItemDataList : ScriptableObject
{
    [SerializeField] private List<ItemData> items;
    public List<ItemData> Items => items;

    public ItemData DownloadData(ItemKind kind)
    {
        try
        {
            foreach (var item in items)
            {
                if(item.Kind == kind)
                    return item;
            }
            return null;
        }
        catch (Exception ex)
        {
            Debug.Log("Ошибка загрузки предмета." + ex.Message);
            return null;
        }
    }

    private void OnValidate()
    {
        if (items == null)
            items = new List<ItemData>();
        else
        {
            foreach (var item in Enum.GetValues(typeof(ItemKind)))
            {
                var itemForAdding = Resources.Load<ItemData>("ScriptableObjects/Items/" + item.ToString());
                if (items.Contains(itemForAdding))
                    continue;
                else
                {
                    if(itemForAdding != null)
                        items.Add(itemForAdding);
                }
            }
        }
    }
}
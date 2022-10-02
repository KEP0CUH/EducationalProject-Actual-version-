using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    menuName = "Storages/_ShopList",
    fileName = "_ShopList",
    order = 51)]
public class ShopDataList : ScriptableObject
{
    [SerializeField] private List<ShopData> shops;

    public List<ShopData> Ships => shops;

    public ShopData DownloadData(ShopKind kind)
    {
        try
        {
            foreach (var shop in shops)
            {
                if (shop.Kind == kind)
                    return shop;
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
        if (shops == null)
            shops = new List<ShopData>();
        else
        {
            foreach (var shop in Enum.GetValues(typeof(ShopKind)))
            {
                var shopForAdding = Resources.Load<ShopData>("ScriptableObjects/Shops/" + shop.ToString());
                if (shops.Contains(shopForAdding))
                    continue;
                else
                {
                    if (shopForAdding != null)
                        shops.Add(shopForAdding);
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private ShopData data;

    [SerializeField] private ShopContent shopContent;
    [SerializeField] private PlayerContent playerContent;

    public Shop Init(ShopKind kind)
    {
        this.data = DownloadData(kind);
        this.shopContent = shopContent.GetComponent<ShopContent>().Init(data);


        return this;
    }

    public void AddPlayerInventory(Inventory inventory)
    {
        playerContent.Init(inventory);
    }

    private ShopData DownloadData(ShopKind kind)
    {
        var shopList = Resources.Load<ShopDataList>("ScriptableObjects/Shops/_ShopList");
        return shopList.DownloadData(kind);
    }
}

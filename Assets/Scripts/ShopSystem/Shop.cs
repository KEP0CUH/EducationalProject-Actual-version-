using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private ShopData data;

    [SerializeField] private ShopContent shopContent;
    //[SerializeField] private playerContent;

    public Shop Init(ShopKind kind)
    {
        this.data = DownloadData(kind);
        this.shopContent = shopContent.GetComponent<ShopContent>().Init(data);


        return this;
    }

    private ShopData DownloadData(ShopKind kind)
    {
        var shopList = Resources.Load<ShopDataList>("ScriptableObjects/Shops/_ShopList");
        Debug.Log(shopList.DownloadData(kind).Kind);
        return shopList.DownloadData(kind);
    }
}

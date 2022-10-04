using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    menuName = "ScriptableObjects/Shops/new Shop",
    fileName = "newShop",
    order = 51)]
public class ShopData : ScriptableObject
{
    [SerializeField] private ShopKind kind;
    private Dictionary<ItemKind, int> items;

    public ShopKind Kind => kind;
    public Dictionary<ItemKind, int> Items => items;

    private void OnValidate()
    {
        items = new Dictionary<ItemKind, int>();
        switch (kind)
        {
            case ShopKind.shopResources1:
                items.Add(ItemKind.Mineral, 1000);
                items.Add(ItemKind.Titan, 720);
                break;
            case ShopKind.shopResources2:
                items.Add(ItemKind.Gold, 1000);
                items.Add(ItemKind.Ferrum, 800);
                break;

        }
    }

}

public enum ShopKind
{
    shopResources1,
    shopResources2,
}

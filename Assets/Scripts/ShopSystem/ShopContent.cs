using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopContent : MonoBehaviour
{
    private ShopData data;
    [SerializeField] private List<Slot> shopList;
    [SerializeField] private Slot slotPrefab;
    [SerializeField] private TradeWindow tradeWindow;

    public ShopContent Init(ShopData data)
    {
        this.data = data;
        Display();

        return this;
    }

    private void Display()
    {
        if(this.shopList == null)
        {
            this.shopList = new List<Slot>();
        }

        if(shopList.Count > 0)
        {
            foreach(Slot slot in shopList)
            {
                Object.Destroy(slot.gameObject);
            }
        }
        shopList.Clear();


        var items = data.Items;

        foreach (var item in items)
        {
            var slot = Instantiate(slotPrefab,this.transform)
                .GetComponent<Slot>()
                .Init(item.Key,item.Value,SlotKind.shopBuy);
            slot.SettingInteractive(CreateTradeWindow);
            shopList.Add(slot);
        }
    }

    private void CreateTradeWindow(ItemData data,int count)
    {
        tradeWindow.gameObject.SetActive(true);
        tradeWindow.GetComponent<TradeWindow>().Init(data.Kind, count, "КУПИТЬ?");

        Debug.Log("Замечен клик по предмету для покупки. Тут будет вызов окошка торговли.");
    }


}

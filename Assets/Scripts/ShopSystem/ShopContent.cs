using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopContent : MonoBehaviour
{
    private ShopState state;
    private Action<ItemKind,int> makeBuying;
    [SerializeField] private List<Slot> shopList;
    [SerializeField] private Slot slotPrefab;
    [SerializeField] private TradeWindow tradeWindow;

    public ShopContent Init(Action<ItemKind, int> makeBuying,Shop shop)
    {
        this.makeBuying = makeBuying;
        this.state = shop.State;
        Display();

        return this;
    }

    public void Display()
    {
        if(this.shopList == null)
        {
            this.shopList = new List<Slot>();
        }

        if(shopList.Count > 0)
        {
            foreach(Slot slot in shopList)
            {
                UnityEngine.Object.Destroy(slot.gameObject);
            }
        }
        shopList.Clear();


        var items = state.GetItems();

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
        tradeWindow.GetComponent<TradeWindow>().Init(makeBuying,data.Kind,data.Icon, count, "КУПИТЬ?");

        Debug.Log("Замечен клик по предмету для покупки. Тут будет вызов окошка торговли.");
    }


}

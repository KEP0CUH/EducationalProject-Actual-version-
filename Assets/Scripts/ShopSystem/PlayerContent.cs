using System;
using System.Collections.Generic;
using UnityEngine;
public class PlayerContent : MonoBehaviour
{
    private Inventory playerInventory;
    private Action<ItemKind, int> makeSelling;
    [SerializeField] private List<Slot> playerItems;
    [SerializeField] private Slot slotPrefab;
    [SerializeField] private TradeWindow tradeWindow;
    
    public Inventory PlayerInventory => playerInventory;

    public PlayerContent Init(Action<ItemKind,int> makeSelling,Inventory playerInventory)
    {
        this.makeSelling = makeSelling;
        this.playerInventory = playerInventory;
        Display();

        return this;
    }

    public void Display()
    {
        if(playerItems == null)
            playerItems = new List<Slot>();

        foreach(var slot in playerItems)
        {
            UnityEngine.Object.Destroy(slot.gameObject);
        }
        playerItems.Clear();

        var items = playerInventory.GetItems();

        foreach(var item in items)
        {
            var newSlot = Instantiate(slotPrefab,this.transform)
                .GetComponent<Slot>()
                .Init(item.Key,item.Value,SlotKind.shopSell);
            newSlot.SettingInteractive(CreateTradeWindow);
            playerItems.Add(newSlot);
        }
    }

    private void CreateTradeWindow(ItemData data,int count)
    {
        tradeWindow.gameObject.SetActive(true);

        tradeWindow.GetComponent<TradeWindow>().Init(makeSelling,data.Kind,data.Icon,count,"ПРОДАТЬ?");
        Debug.Log("Замечен клик по предмету для продажи. Тут будет вызов окошка торговли.");
    }
}

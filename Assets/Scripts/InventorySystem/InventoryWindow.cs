using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipInInventoryWindow))]
public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private GameObject slot;
    [SerializeField] private Transform itemSlots;

    [SerializeField] private ShipInInventoryWindow shipWindow;
    [SerializeField] private ConstantUI constantUI;

    public InventoryWindow Init(ConstantUI constantUI,ICanvas canvas,Ship ship)
    {
        this.constantUI = constantUI;
        canvas.AttachAsChild(this.gameObject);
        this.shipWindow = GetComponent<ShipInInventoryWindow>().Init(ship);

        constantUI.OnOpenInventory(this);
        Debug.Log("Инвентарь создан");
        return this;
    }

    public void UpdateItemsList(Dictionary<ItemKind,int> items)
    {
        foreach(Transform child in itemSlots.transform)
        {
            Destroy(child.gameObject);
        }

        foreach(var item in items)
        {
            var newSlot = Instantiate(slot,itemSlots.transform).GetComponent<Slot>().Init(item.Key,item.Value);
        }
    }

    public void Reswitch()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipInInventoryWindow))]
public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private GameObject slot;
    [SerializeField] private Transform itemSlots;

    [SerializeField] private ShipInInventoryWindow shipWindow;

    public InventoryWindow Init(ICanvas canvas,Ship ship)
    {
        canvas.AttachAsChild(this.gameObject);
        this.shipWindow = GetComponent<ShipInInventoryWindow>().Init(ship);
        Debug.Log("��������� ������");
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
            var newSlot = Instantiate(slot).GetComponent<Slot>().Init(item.Key,item.Value);
            newSlot.transform.SetParent(itemSlots.transform);
        }
    }

    public void Reswitch()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}

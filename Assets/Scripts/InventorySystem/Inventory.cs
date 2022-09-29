using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private InventoryState state;
    private InventoryWindow window;
    private Ship ship;

    public Inventory(ICanvas canvas,Ship ship)
    {
        this.ship = ship;
        this.state = new InventoryState();
        var windowPrefab = Resources
            .Load<GameObject>("Prefabs/InventoryWindow");
        this.window = GameObject.Instantiate(windowPrefab).GetComponent<InventoryWindow>().Init(canvas,ship);
    }

    public void AddItem(ItemKind kind, int count)
    {
        this.state.Add(kind, count);
        this.window.UpdateItemsList(state.Items);
    }

    public void RemoveItem(ItemKind kind,int count)
    {
        this.state.Remove(kind, count);
        this.window.UpdateItemsList(state.Items);
    }

    public void ReswitchWindow()
    {
        this.window.Reswitch();
    }
}

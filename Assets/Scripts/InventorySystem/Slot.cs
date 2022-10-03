using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Slot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text count;
    [SerializeField] private SlotKind slotKind;
    [SerializeField] private Button button;
    public Button Button => button;

    public Slot Init(ItemKind kind,int count,SlotKind slotKind)
    {
        var itemDataList = Resources.Load<ItemDataList>("ScriptableObjects/Items/_ItemList");
        var data = itemDataList.DownloadData(kind);
        this.icon.sprite = data.Icon;
        this.count.text = "<color=blue>Количество: " + count + "</color>";
        this.slotKind = slotKind;
        this.button = gameObject.GetComponent<Button>();

        return this;
    }

    public void SettingInteractive(Action action)
    {
        button.onClick.AddListener(() => action());
        /*switch (slotKind)
        {
            case SlotKind.inventory:
                button.onClick.AddListener(() => action());
                break;
            case SlotKind.shopSell:
                break;
            case SlotKind.shopBuy:
                break;
        }*/
    }
}

public enum SlotKind
{
    inventory,
    shopSell,
    shopBuy
}

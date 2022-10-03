using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Slot : MonoBehaviour
{
    private ItemData data;
    private int count;
    [SerializeField] private Image icon;
    [SerializeField] private Text countText;
    [SerializeField] private SlotKind slotKind;
    [SerializeField] private Button button;
    public Button Button => button;

    public Slot Init(ItemKind kind,int count,SlotKind slotKind)
    {
        var itemDataList = Resources.Load<ItemDataList>("ScriptableObjects/Items/_ItemList");
        this.data = itemDataList.DownloadData(kind);
        this.count = count;
        this.icon.sprite = data.Icon;
        this.countText.text = "<color=blue>Количество: " + count + "</color>";
        this.slotKind = slotKind;
        this.button = gameObject.GetComponent<Button>();

        return this;
    }

    public void SettingInteractive(Action<ItemData,int> action)
    {
        button.onClick.AddListener(() => action(data,count));
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

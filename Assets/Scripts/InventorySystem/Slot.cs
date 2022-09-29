using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text count;

    public Slot Init(ItemKind kind,int count)
    {
        var itemDataList = Resources.Load<ItemDataList>("ScriptableObjects/Items/_ListItem");
        var data = itemDataList.DownloadData(kind);
        this.icon.sprite = data.Icon;
        this.count.text = "<color=blue>Количество: " + count + "</color>"; 


        return this;
    }
}

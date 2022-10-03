using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeWindow : MonoBehaviour
{
    private ItemData data;
    [SerializeField] private Image icon;
    [SerializeField] private InputField count;
    [SerializeField] private Text action;
    [SerializeField] private Button confirm;
    [SerializeField] private Button cancel;

    public TradeWindow Init(ItemKind kind,int count,string action)
    {
        this.data = Resources.Load<ItemDataList>("ScriptableObjects/Items/_ItemList").DownloadData(kind);
        this.icon.sprite = data.Icon;
        this.count.text =  count.ToString().ToUpper();
        this.action.text = action;

        confirm.onClick.AddListener(ConfirmTransaction);
        cancel.onClick.AddListener(CancelTransaction);

        return this;
    }

    private void ConfirmTransaction()
    {
        this.gameObject.SetActive(false);
    }

    private void CancelTransaction()
    {
        this.gameObject.SetActive(false);
    }
}

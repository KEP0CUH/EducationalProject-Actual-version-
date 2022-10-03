using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemView : MonoBehaviour
{
    [SerializeField] private ItemData data;

    [SerializeField] private SpriteRenderer icon;

    public ItemView Init(ItemData itemData)
    {
        this.data = itemData;
        this.icon = gameObject.GetComponent<SpriteRenderer>();
        icon.sprite = itemData.Icon;

        this.GetComponent<Rigidbody>().isKinematic = true;
        this.GetComponent<BoxCollider>().isTrigger = true;

        return this;
    }

    private void ButtonClicked()
    {
        Debug.Log($"<color=red>{data.name}</color>");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent(typeof(IMobHandler)))
        {
            Debug.Log("MobHandler сработал");
            if(other.gameObject.GetComponent<IItemHandler>() != null)
            {
                other.gameObject.GetComponent<IItemHandler>().HandleItem(this,data);
            }
        }
    }
}

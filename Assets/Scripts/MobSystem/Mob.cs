using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour, IItemHandler
{
    private Inventory inventory;

    public void HandleItem(ItemView sender, ItemData item)
    {
        throw new System.NotImplementedException();
    }

    public void SetDamage(int damage)
    {
        Debug.Log($"Моб получает урон: {damage}");
    }

    public void TakeItem(ItemView item)
    {
        Debug.Log($"{item.name} was taken by mob.");
        Object.Destroy(item.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent(typeof(IMobHandler)))
        {
            Debug.Log("MobHandler сработал");
            other.gameObject.GetComponent<IMobHandler>().HandleMob(this);
        }
    }


}

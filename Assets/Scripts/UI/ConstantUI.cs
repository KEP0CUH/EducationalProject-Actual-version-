using UnityEngine;
using UnityEngine.UI;

public class ConstantUI : MonoBehaviour
{
    [SerializeField] private Text health;
    [SerializeField] private Text energy;
    [SerializeField] private Text credits;
    [SerializeField] private Button skills;
    [SerializeField] private Button inventory;
    [SerializeField] private Button quests;
    [SerializeField] private Button droids;

    public void OnOpenInventory(InventoryWindow window)
    {
        this.inventory.onClick.AddListener(window.Reswitch);
    }
}

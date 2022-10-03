using UnityEngine;

[CreateAssetMenu(
    menuName = "ScriptableObjects/Items/new Item",
    fileName = "newItem",
    order =51)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private ItemKind kind;
    [SerializeField]
    private Sprite icon;                
    [SerializeField]
    private string title;               
    [SerializeField]
    private string description;

    public ItemKind Kind => kind;
    public Sprite Icon => icon;
    public string Title => title;
    public string Description => description;

    private void OnValidate()
    {
        this.icon = Resources.Load<Sprite>("IconsItems/Minerals/" + kind.ToString());
        switch(kind)
        {
            case ItemKind.Ferrum:
                title = "Железо";
                break;
            case ItemKind.Gold:
                title = "Золото";
                break;
            case ItemKind.Titan:
                title = "Титан";
                break;
            case ItemKind.Mineral:
                title = "Минерал";
                break;
        }
        this.name = kind.ToString();
    }
}
public enum ItemKind
{
    Gold,
    Mineral,
    Ferrum,
    Titan
}

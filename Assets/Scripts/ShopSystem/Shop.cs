using UnityEngine;

public class Shop : MonoBehaviour
{
    private ShopState state;
    private Inventory inventory;

    [SerializeField] private ShopContent shopContent;
    [SerializeField] private PlayerContent playerContent;
    public ShopState State => state;

    public Shop Init(ShopKind kind)
    {
        if(this.state == null)
         this.state = new ShopState(kind);
        this.shopContent = shopContent.GetComponent<ShopContent>().Init(MakeBuying,this);

        return this;
    }

    public Shop Init(Shop shop)
    {
        this.state = shop.state;
        this.shopContent = shopContent.GetComponent<ShopContent>().Init(MakeBuying, this);

        return this;
    }

    public void MakeBuying(ItemKind kind, int count)
    {
        if(inventory != null)
        {
            RemoveItem(kind, count);
            inventory.AddItem(kind, count);

            shopContent.Display();
            playerContent.Display();
        }
    }

    public void MakeSelling(ItemKind kind,int count)
    {
        if(inventory != null)
        {
            AddItem(kind, count);
            inventory.RemoveItem(kind,count);

            shopContent.Display();
            playerContent.Display();
        }
    }

    public void AddItem(ItemKind kind, int count)
    {
        this.state.AddItem(kind, count);
    }

    public void RemoveItem(ItemKind kind,int count)
    {
        this.state.RemoveItem(kind, count);
    }

    public void AddPlayerInventory(Inventory inventory)
    {
        this.inventory = inventory;
        playerContent.Init(MakeSelling,inventory);
    }


}

using UnityEngine;
using UnityEngine.UI;

public class PlanetInside : MonoBehaviour
{
    private PlanetData data;
    private PlanetState state;

    [SerializeField] private Button riseButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Image background;
    [SerializeField] private Shop shop;
    public void Init(PlanetState state)
    {
        this.state = state;
        this.background.sprite = state.Data.IconBackground;
        this.gameObject.SetActive(true);

        this.riseButton.onClick.AddListener(Rise);
        this.shopButton.onClick.AddListener(OpenShop);

        if (shop != null)
        {
            shop.gameObject.SetActive(!shop.gameObject.activeInHierarchy);
            shop.Init(state.Shop);
        }
    }

    public void Init(PlanetData data)
    {
        this.data = data;
        this.background.sprite = state.Data.IconBackground;
        this.gameObject.SetActive(true);

        this.riseButton.onClick.AddListener(Rise);
        this.shopButton.onClick.AddListener(OpenShop);

        if (shop != null)
        {
            shop.gameObject.SetActive(!shop.gameObject.activeInHierarchy);
            shop.Init(data.ShopKind);
        }
    }

    public void AddPlayerInventory(Inventory inventory)
    {
        shop.AddPlayerInventory(inventory);
    }

    private void Rise()
    {
        this.riseButton.onClick.RemoveAllListeners();
        this.shopButton.onClick.RemoveAllListeners();
        this.gameObject.SetActive(false);
    }

    private void OpenShop()
    {
        if(shop != null)
        {
            shop.gameObject.SetActive(!shop.gameObject.activeInHierarchy);
            shop.Init(state.Shop);
        }
    }
}
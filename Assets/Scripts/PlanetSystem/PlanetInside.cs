using UnityEngine;
using UnityEngine.UI;

public class PlanetInside : MonoBehaviour
{
    [SerializeField] private Button rise;
    [SerializeField] private Button shop;
    [SerializeField] private Image background;
    public void Init(PlanetData data)
    {
        this.background.sprite = data.IconBackground;
        this.gameObject.SetActive(true);

        this.rise.onClick.AddListener(Rise);
    }

    private void Rise()
    {
        this.rise.onClick.RemoveAllListeners();
        this.gameObject.SetActive(false);
    }
}
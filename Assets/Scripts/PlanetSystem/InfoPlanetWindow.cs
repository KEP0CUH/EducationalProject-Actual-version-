using UnityEngine;
using UnityEngine.UI;

public class InfoPlanetWindow : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Image icon;
    [SerializeField] private Text size;
    [SerializeField] private Text organization;
    [SerializeField] private Button buttonLand;

    public InfoPlanetWindow Init(PlanetData data)
    {
        this.title.text = $"<color=grey>Название</color><color=green>    { data.Title}</color>";
        this.icon.sprite = data.Icon;
        this.buttonLand.onClick.AddListener(Land);

        return this;
    }

    private void Land()
    {

    }
}

using UnityEngine;
using UnityEngine.UI;

public class InfoPlanetWindow : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Image icon;
    [SerializeField] private Text size;
    [SerializeField] private Text organization;
    [SerializeField] private Button buttonLand;

    private PlanetState state;
    private PlanetInside planetInside;

    public InfoPlanetWindow Init(PlanetInside planetInside,PlanetState state)
    {
        this.planetInside = planetInside;
        this.state = state;
        this.title.text = $"<color=grey>Название</color><color=green>    { state.Data.Title}</color>";
        this.icon.sprite = state.Data.Icon;
        this.buttonLand.onClick.AddListener(Land);

        return this;
    }

    private void Land()
    {
        planetInside.Init(this.state);
        Object.Destroy(this.gameObject);
    }
}

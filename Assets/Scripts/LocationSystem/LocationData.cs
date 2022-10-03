using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newLocation", menuName ="ScriptableObjects/Locations/newLocation",order = 51)]
public class LocationData : ScriptableObject
{
    [SerializeField] private LocationKind kind;
    [SerializeField] private string title;
    [SerializeField] private SunKind sunKind;
    [SerializeField] private Sprite sunSprite;
    [SerializeField] private Vector2 globalPosition;
    [SerializeField] private List<PlanetKind> planets;

    public LocationKind Kind => kind;
    public string Title => title;
    public SunKind SunKind => sunKind;
    public Sprite SunSprite => sunSprite;
    public Vector2 GlobalPosition => globalPosition;
    public List<PlanetKind> Planets => planets;
 
    private void OnValidate()
    {
        planets = new List<PlanetKind>();
        switch (kind)
        {
            case LocationKind.Krinul:
                this.title = "Кринул";
                this.sunKind = SunKind.OrangeSun;
                this.globalPosition = new Vector2(10, 10);

                this.planets.Add(PlanetKind.Earth);
                this.planets.Add(PlanetKind.Mars);
                break;
        }

        sunSprite = Resources.Load<Sprite>("Icons/Suns/" + sunKind.ToString());
    }
}

public enum SunKind
{
    OrangeSun,
    BlueSun,
    YellowSun,
    WhiteSun,
    GreenSun,
}

public enum LocationKind
{
    Krinul,
}
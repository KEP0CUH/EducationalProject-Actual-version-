using UnityEngine;

[CreateAssetMenu(
    menuName = "ScriptableObjects/Planets/New Planet",
    fileName = "New Planet",
    order = 51)]
public class PlanetData : ScriptableObject
{
    [SerializeField] private PlanetKind kind;
    [SerializeField] private string title;
    [SerializeField] private PlanetIconKind iconKind;
    [SerializeField] private Sprite iconPlanet;
    [SerializeField] private Sprite iconBackground;
    [SerializeField] private Vector3 offsetFromSun;

    public PlanetKind Kind => kind; 
    public string Title => title;
    public Sprite Icon => iconPlanet;
    public Sprite IconBackground => iconBackground;
    public Vector3 OffsetFromSun => offsetFromSun;

    private void OnValidate()
    {
        switch(kind)
        {
            case PlanetKind.Earth:
                this.title = "Земля";
                this.iconKind = PlanetIconKind.PlanetType1;
                this.offsetFromSun = new Vector3(0,3,0);
                break;
            case PlanetKind.Mars:
                this.title = "Марс";
                this.iconKind = PlanetIconKind.PlanetType16;
                this.offsetFromSun = new Vector3(0, 6,0);
                break;
        }

        this.iconPlanet = Resources.Load<Sprite>("Icons/Planets/" + this.iconKind.ToString());
        this.iconBackground = Resources.Load<Sprite>("Icons/Cosmoports/" + this.iconKind.ToString());
    }
}


public enum PlanetIconKind
{
    //Storage,

    PlanetType1, PlanetType2, PlanetType3, PlanetType4, PlanetType5, PlanetType6, PlanetType7,  
    PlanetType8, PlanetType9, PlanetType10, PlanetType11, PlanetType12, PlanetType13, PlanetType14,
    PlanetType15, PlanetType16, PlanetType17
}

public enum PlanetKind
{
    Earth,
    Mars,
}
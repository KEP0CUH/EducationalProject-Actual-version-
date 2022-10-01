using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LocationView : MonoBehaviour
{
    private LocationData data;
    private SpriteRenderer iconSun;
    private PlanetSpawner planetSpawner;

    public LocationView Init(ICanvas canvas,PlanetInside planetInside,Transform parent,LocationData data)
    {
        this.transform.parent = parent;
        this.data = data;
        this.GetComponent<SpriteRenderer>().sprite = data.SunSprite;
        this.planetSpawner = new GameObject("PlanetSpawner",typeof(PlanetSpawner))
            .GetComponent<PlanetSpawner>().Init(canvas,planetInside,this.transform,data);

        return this;
    }
}

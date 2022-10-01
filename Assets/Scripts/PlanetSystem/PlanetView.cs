using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlanetView : MonoBehaviour
{
    private PlanetData data;
    private Transform parent;
    private InfoPlanetWindow infoWindow;
    private static GameObject infoWindowObject;
    private ICanvas canvas;
    PlanetInside planetInside;

    public PlanetView Init(ICanvas canvas,PlanetInside planetInside,Transform parent,PlanetData data)
    {
        this.canvas = canvas;
        this.planetInside = planetInside;
        this.parent = parent;
        this.data = data;
        this.transform.parent = parent;
        this.transform.localPosition += data.OffsetFromSun;
        transform.RotateAround(parent.position, parent.forward, Random.Range(0.0f, 360.0f));

        this.GetComponent<SpriteRenderer>().sprite = data.Icon;
        this.gameObject.AddComponent<SphereCollider>();

        this.infoWindow = Resources.Load<GameObject>("Prefabs/UI/InfoPlanetWindow")
            .GetComponent<InfoPlanetWindow>()
            .Init(planetInside,data);

        return this;
    }

    private void OnMouseDown()
    {
        if(infoWindowObject == null)
            infoWindowObject = Instantiate(infoWindow.gameObject);
        else
        {
            Object.Destroy(infoWindowObject);
            infoWindowObject = Instantiate(infoWindow.gameObject);
        }

        infoWindowObject.GetComponent<InfoPlanetWindow>().Init(planetInside,data);

        canvas.AttachAsChild(infoWindowObject.gameObject);
    }
    private void FixedUpdate()
    {
        SaveRotationAboutSun();
    }

    private void SaveRotationAboutSun()
    {
        transform.RotateAround(parent.position, parent.forward, Random.Range(2.5f,5.0f) * Time.fixedDeltaTime);
    }
}

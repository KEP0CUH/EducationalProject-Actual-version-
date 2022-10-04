using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlanetView : MonoBehaviour
{
    private PlanetState state;
    private Transform parent;
    private InfoPlanetWindow infoWindow;
    private static GameObject infoWindowObject;
    private ICanvas canvas;
    PlanetInside planetInside;

    public PlanetView Init(ICanvas canvas,PlanetInside planetInside,Transform parent, PlanetState state)
    {
        this.canvas = canvas;
        this.planetInside = planetInside;
        this.parent = parent;
        this.state = state;
        this.transform.parent = parent;
        this.transform.localPosition += state.Data.OffsetFromSun;
        transform.RotateAround(parent.position, parent.forward, Random.Range(0.0f, 360.0f));

        this.GetComponent<SpriteRenderer>().sprite = state.Data.Icon;
        this.gameObject.AddComponent<SphereCollider>().isTrigger = true;
        this.gameObject.AddComponent<Rigidbody>().isKinematic = true;

        this.infoWindow = Resources.Load<GameObject>("Prefabs/UI/InfoPlanetWindow")
            .GetComponent<InfoPlanetWindow>()
            .Init(planetInside, state);

        return this;
    }

    public void AddPlayerInventory(Inventory inventory)
    {
        planetInside.AddPlayerInventory(inventory);
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

        infoWindowObject.GetComponent<InfoPlanetWindow>().Init(planetInside, state);

        canvas.AttachAsChild(infoWindowObject.gameObject);
    }


    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.GetComponent<IPlanetHandler>() != null)
        {
            Debug.Log("Игрок пересекся с планетой");
            collider.gameObject.GetComponent<IPlanetHandler>().HandlePlanet(this);
        }
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

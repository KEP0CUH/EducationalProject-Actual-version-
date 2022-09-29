using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlanetView : MonoBehaviour
{
    private PlanetData data;
    private Transform parent;

    public PlanetView Init(Transform parent,PlanetData data)
    {
        this.parent = parent;
        this.transform.parent = parent;
        this.transform.localPosition += data.OffsetFromSun;
        transform.RotateAround(parent.position, parent.forward, Random.Range(0.0f, 360.0f));

        this.data = data;
        this.GetComponent<SpriteRenderer>().sprite = data.Icon;

        return this;
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

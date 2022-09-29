using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider))]
public class Entity : MonoBehaviour
{
    private EntityData data;

    private void Awake()
    {
        this.GetComponent<SpriteRenderer>().sprite = data.Sprite;
    }

    private void OnMouseDown()
    {
        Debug.Log($"{data.Title},{data.Description}");
    }
}

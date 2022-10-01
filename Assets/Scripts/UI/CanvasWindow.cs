using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasWindow : MonoBehaviour, ICanvas
{
    [SerializeField] ConstantUI constantUI;
    public ConstantUI ConstantUI => constantUI;
    public void AttachAsChild(GameObject obj, string layer = "UI")
    {
        obj.transform.SetParent(this.transform,false);
        obj.layer = LayerMask.NameToLayer(layer);
        var rect = obj.GetComponent<RectTransform>();
        //Debug.Log($"sizedelta.x = {rect.sizeDelta.x} sizedelta.y = {rect.sizeDelta.y}");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasWindow : MonoBehaviour, ICanvas
{
    public void AttachAsChild(GameObject obj, string layer = "UI")
    {
        obj.transform.SetParent(this.transform,false);
        obj.layer = LayerMask.NameToLayer(layer);
        var rect = obj.GetComponent<RectTransform>();
        Debug.Log($"sizedelta.x = {rect.sizeDelta.x} sizedelta.y = {rect.sizeDelta.y}");
        //rect.localPosition = new Vector2(rect.sizeDelta.x / 2, rect.sizeDelta.y / 2);
        //rect.anchoredPosition3D = this.gameObject.GetComponent<RectTransform>().anchoredPosition3D;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location
{
    private LocationData data;
    private LocationView view;

    public Location(Transform parent,LocationKind kind)
    {
        this.data = Resources.Load<LocationDataList>("ScriptableObjects/Locations/_LocationList").DownloadData(kind);
        this.view = new GameObject($"{kind}", typeof(LocationView)).GetComponent<LocationView>().Init(parent,data);
        this.view.gameObject.transform.position = data.GlobalPosition;
    }
}

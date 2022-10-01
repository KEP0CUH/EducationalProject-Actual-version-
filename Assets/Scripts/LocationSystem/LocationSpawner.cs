using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationSpawner : MonoBehaviour
{
    [SerializeField] private List<LocationData> locationsData;
    [SerializeField] private List<Location> spawnedLocations;
    [SerializeField] private CanvasWindow canvas;
    [SerializeField] private PlanetInside planetInside;

    private void Start()
    {
        locationsData = Resources.Load<LocationDataList>("ScriptableObjects/Locations/_LocationList").Locations;
        spawnedLocations = new List<Location>();

        foreach (var location in locationsData)
        {
             spawnedLocations.Add(new Location(canvas,planetInside,this.transform,location.Kind));
        }
    }
}

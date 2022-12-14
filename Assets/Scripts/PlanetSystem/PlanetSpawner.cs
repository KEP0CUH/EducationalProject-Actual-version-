using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    private List<Planet> spawnedPlanets;
    public PlanetSpawner Init(ICanvas canvas,PlanetInside planetInside,Transform parent,LocationData data)
    {
        this.transform.parent = parent;

        spawnedPlanets = new List<Planet>();
        var planetKinds = data.Planets;

        foreach(var kind in planetKinds)
        {
            spawnedPlanets.Add(new Planet(canvas,planetInside,this.transform,kind));
        }

        return this;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    menuName = "Storages/new PlanetsData",
    fileName = "_PlanetList",
    order = 51)]
public class PlanetDataList : ScriptableObject
{
    [SerializeField] private List<PlanetData> planets;
    public List<PlanetData> Planets => planets;

    public PlanetData DownloadData(PlanetKind kind)
    {
        try
        {
            foreach (var planet in planets)
            {
                if (planet.Kind == kind)
                    return planet;
            }
            return null;
        }
        catch (Exception ex)
        {
            Debug.Log("Ошибка загрузки планеты." + ex.Message);
            return null;
        }
    }

    private void OnValidate()
    {
        if (planets == null)
        {
            planets = new List<PlanetData>();
        }

        foreach (var planet in Enum.GetValues(typeof(PlanetKind)))
        {
            var planetForAdding = Resources.Load<PlanetData>("ScriptableObjects/Planets/" + planet.ToString());

            if (planets.Contains(planetForAdding))
                continue;
            else
            {
                if (planetForAdding != null)
                {
                    planets.Add(planetForAdding);
                }
            }
        }
    }
}

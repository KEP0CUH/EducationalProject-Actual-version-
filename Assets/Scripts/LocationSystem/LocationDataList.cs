using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_LocationList", menuName = "Storages/Locations Data")]
public class LocationDataList : ScriptableObject
{
    [SerializeField] private List<LocationData> locations;
    public List<LocationData> Locations => locations;

    public LocationData DownloadData(LocationKind kind)
    {
        try
        {
            foreach(var location in locations)
            {
                if(location.Kind == kind)
                    return location;
            }
            return null;
        }
        catch(Exception ex)
        {
            Debug.Log("Ошибка загрузки локации." + ex.Message);
            return null;
        }
    }

    private void OnValidate()
    {
        if (locations == null)
        {
            locations = new List<LocationData>();
        }

        foreach (var loc in Enum.GetValues(typeof(LocationKind)))
        {
            var locationForAdding = Resources.Load<LocationData>("ScriptableObjects/Locations/" + loc.ToString());

            if (locations.Contains(locationForAdding))
                continue;
            else
            {
                if (locationForAdding != null)
                {
                    locations.Add(locationForAdding);
                }
            }
        }
    }
}

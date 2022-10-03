using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="_ShipList",menuName="Storages/Ships Data",order=52)]
public class ShipDataList : ScriptableObject
{
    [SerializeField] private List<ShipData> ships;

    public List<ShipData> Ships => ships;

    public ShipData DownloadData(ShipKind kind)
    {
        try
        {
            foreach (var ship in ships)
            {
                if (ship.Kind == kind)
                    return ship;
            }
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка загрузки предмета." + ex.Message);
            return null;
        }
    }

    private void OnValidate()
    {
        if (ships == null)
            ships = new List<ShipData>();
        else
        {
            foreach (var ship in Enum.GetValues(typeof(ShipKind)))
            {
                var shipForAdding = Resources.Load<ShipData>("ScriptableObjects/Ships/" + ship.ToString());
                if (ships.Contains(shipForAdding))
                    continue;
                else
                {
                    if(shipForAdding != null)
                        ships.Add(shipForAdding);
                }
            }
        }
    }
}

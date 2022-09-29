using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipState
{
    private ShipData data;
    public ShipData Data => data;

    public ShipState(ShipKind kind)
    {
        var shipDataList = Resources.Load<ShipDataList>("ScriptableObjects/Ships/_ShipList");

        this.data = shipDataList.DownloadData(kind);
    }
}

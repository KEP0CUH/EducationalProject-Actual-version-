using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetState
{
    private PlanetData data;
    public PlanetData Data => data;

    public PlanetState(PlanetKind kind)
    {
        var planetDataList = Resources.Load<PlanetDataList>("ScriptableObjects/Planets/_PlanetList");

        this.data = planetDataList.DownloadData(kind);
    }
}

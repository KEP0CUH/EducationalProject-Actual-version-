using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetState
{
    private PlanetData data;
    private ShopState shopState;
    public PlanetData Data => data;
    public ShopState ShopState => shopState;

    public PlanetState(PlanetKind kind)
    {
        var planetDataList = Resources.Load<PlanetDataList>("ScriptableObjects/Planets/_PlanetList");

        this.data = planetDataList.DownloadData(kind);
        this.shopState = new ShopState(data.ShopKind);
    }
}

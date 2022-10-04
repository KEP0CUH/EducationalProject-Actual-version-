using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetState
{
    private PlanetData data;
    private Shop shop;
    public PlanetData Data => data;
    public Shop Shop => shop;

    public PlanetState(PlanetKind kind)
    {
        var planetDataList = Resources.Load<PlanetDataList>("ScriptableObjects/Planets/_PlanetList");
        
        this.data = planetDataList.DownloadData(kind);
        this.shop.Init(data.ShopKind);
    }
}

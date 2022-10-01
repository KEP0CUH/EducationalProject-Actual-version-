using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet 
{
    private PlanetState state;
    private PlanetView view;

    public Planet(ICanvas canvas,PlanetInside planetInside,Transform parent,PlanetKind kind)
    {
        state = new PlanetState(kind);
        view = new GameObject(kind.ToString(),typeof(PlanetView)).GetComponent<PlanetView>()
            .Init(canvas,planetInside,parent,state.Data);
    }
}

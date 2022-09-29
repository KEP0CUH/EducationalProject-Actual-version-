using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    private ShipState state;
    public ShipState State => state;
    public Ship(ShipKind kind)
    {
        this.state = new ShipState(kind);
    }
}

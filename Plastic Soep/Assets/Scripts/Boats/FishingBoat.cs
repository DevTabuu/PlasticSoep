using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBoat : Boat {

    public override bool CanCollect(ICollectable collectable)
    {
        return collectable is FishingArea;
    }

}

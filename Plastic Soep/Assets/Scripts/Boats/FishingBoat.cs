using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBoat : Boat {

    public override bool CanCollect(Collectable collectable)
    {
        return collectable is FishingArea;
    }

}

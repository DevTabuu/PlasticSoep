using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningBoat : Boat
{
    public override bool CanCollect(ICollectable collectable)
    {
        return collectable is TrashIsland;
    }
}

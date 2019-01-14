using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingBoat : Boat {

    protected override void Start()
    {
        base.Start();
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        DialogManager _dialogManager = manager.GetComponent<DialogManager>();
        _dialogManager.ShowDialog(transform, "I am a fishing boat; let me fish!", 5);
    }

    public override bool CanCollect(Collectable collectable)
    {
        return collectable is FishingArea;
    }

}

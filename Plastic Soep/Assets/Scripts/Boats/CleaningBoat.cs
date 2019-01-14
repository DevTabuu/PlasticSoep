using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningBoat : Boat
{
    protected override void Start()
    {
        base.Start();
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        DialogManager _dialogManager = manager.GetComponent<DialogManager>();
        _dialogManager.ShowDialog(transform, "I am a cleaning boat; let me clean the garbage!", 5);
    }

    public override bool CanCollect(Collectable collectable)
    {
        return collectable is TrashIsland;
    }
}

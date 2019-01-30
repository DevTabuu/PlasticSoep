using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashIsland : Collectable {

    private WaterManager _waterManager;

    private void Start()
    {
        _waterManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<WaterManager>();

        // _waterManager.AddToFishTimer(2.5f);
    }

    private void OnDestroy()
    {
        // _waterManager.RemoveFromFishTimer(2.5f);
    }
}

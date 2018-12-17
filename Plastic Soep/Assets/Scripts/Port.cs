using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port : Destination {

    ScoreManager _scoreManager;

    private void Start()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        _scoreManager = manager.GetComponent<ScoreManager>();
    }

    public override void OnArive(INavigatable navigatable)
    {
        if(navigatable is Boat)
        {
            Boat boat = navigatable as Boat;

            if(boat is FishingBoat)
            {
                int score = (int)Mathf.Ceil(boat.GetCargoWeight() * 100);        
                _scoreManager.AddScore(score);
            }

            boat.ClearCargo();
        }
    }
}

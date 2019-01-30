using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port : Destination {

    [SerializeField]
    Animator animator;

    ScoreManager _scoreManager;

    private void Start()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        _scoreManager = manager.GetComponent<ScoreManager>();

        DialogManager _dialogManager = manager.GetComponent<DialogManager>();
        _dialogManager.ShowDialog(transform, "Bring fish and garbage to me!", 5);
    }

    public override void OnArive(INavigatable navigatable)
    {
        if(navigatable is Boat)
        {
            animator.SetTrigger("Collecting");
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port : Destination {

    public override void OnArive(INavigatable navigatable)
    {
        if(navigatable is Boat)
        {
            Boat boat = navigatable as Boat;

            int score = (int) Mathf.Ceil(boat.GetCargoWeight() * 100);

            boat.ClearCargo();
        }
    }
}

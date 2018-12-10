using UnityEngine;

public class Port : MonoBehaviour, IDestination{

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public float GetRange()
    {
        return 2;
    }

    public void OnArive(INavigatable navigatable)
    {
        
        if(navigatable is BoatScript)
        {
            BoatScript boat = navigatable as BoatScript;

            if (boat.GetCargoWeight() > 0)
            {
                Debug.Log("Boat had " + boat.GetCargoWeight() + " cargo.");
                boat.ClearCargo();
            }
            else
                Debug.Log("Boat had no cargo.");
        }

    }
}

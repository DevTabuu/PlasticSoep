using UnityEngine;

public class Destination : MonoBehaviour, IDestination, ICollectable
{
    public float GetCollectingDuration()
    {
        return 3;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public float GetRange()
    {
        return 1;
    }

    public float GetWeight()
    {
        return 0.8f;
    }

    public void OnArive(INavigatable navigatable)
    {
        
    }
}

public interface ICollectable
{
    float GetCollectingDuration();

    float GetWeight();
}

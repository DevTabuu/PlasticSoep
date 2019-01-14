using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : Destination, ICollectable
{
    [SerializeField]
    private float _collectingDuration;

    [Range(0, 1)]
    [SerializeField]
    private float _weight;

    public float GetCollectingDuration()
    {
        return _collectingDuration;
    }

    public float GetWeight()
    {
        return _weight;
    }
}

public interface ICollectable
{
    float GetCollectingDuration();

    float GetWeight();
}

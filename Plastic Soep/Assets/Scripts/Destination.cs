using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Destination : Selectable, IDestination {

    [SerializeField]
    private Transform _destinationLocation;

    [SerializeField]
    private float _ariveRange;

    private void Start()
    {
        if (_destinationLocation == null)
            _destinationLocation = transform;
    }

    public Vector3 GetPosition()
    {
        if (_destinationLocation != null)
            return _destinationLocation.position;
        else
            return transform.position;
    }

    public float GetRange()
    {
        return _ariveRange;
    }

    public virtual void OnArive(INavigatable navigatable) { }
}

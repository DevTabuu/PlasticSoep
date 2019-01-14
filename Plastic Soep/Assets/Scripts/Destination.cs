using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public abstract class Destination : MonoBehaviour, IDestination {

    [SerializeField]
    SelectCircle _selectCircle;

    [SerializeField]
    private Transform _destinationLocation;

    [SerializeField]
    private float _ariveRange;

    private bool _selected;

    private void Start()
    {
        if (_destinationLocation == null)
            _destinationLocation = transform;
    }

    public void SetSelected(bool selected)
    {
        if(_selectCircle != null)
        {
            _selected = selected;
            _selectCircle.gameObject.SetActive(selected);
        }
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

    public bool IsSelected()
    {
        return _selected;
    }

    public virtual void OnArive(INavigatable navigatable) { }
}

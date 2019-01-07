using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public abstract class Destination : MonoBehaviour, IDestination {

    [SerializeField]
    Material _selectedMaterial;
    private Material _defaultMaterial;

    [SerializeField]
    private Transform _destinationLocation;

    [SerializeField]
    private float _ariveRange;

    private bool _selected;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _defaultMaterial = _renderer.material;
    }

    public void SetSelected(bool selected)
    {
        _selected = selected;
        _renderer.material = selected ? _selectedMaterial : _defaultMaterial;
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

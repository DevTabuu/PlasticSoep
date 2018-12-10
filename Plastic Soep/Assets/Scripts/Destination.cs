using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public abstract class Destination : MonoBehaviour, IDestination {

    [SerializeField]
    Material _selectedMaterial;
    private Material _defaultMaterial;

    [SerializeField]
    private Vector3 _destinationOffset;

    [SerializeField]
    private float _ariveRange;

    private bool _selected;
    private Renderer _renderer;

    private void Start()
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
        return transform.position + _destinationOffset;
    }

    public float GetRange()
    {
        return _ariveRange;
    }

    public virtual void OnArive(INavigatable navigatable) { }
}

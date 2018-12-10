using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public abstract class Collectable : MonoBehaviour, ICollectable, IDestination
{

    [Range(0, 1)]
    [SerializeField]
    private float _weight;

    [SerializeField]
    private float _collectingDuration;

    [SerializeField]
    private float _collectingRange;

    [SerializeField]
    private Material _selectedMaterial;

    private Material _defaultMaterial;
    private Renderer _renderer;
    private bool _selected;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _defaultMaterial = _renderer.material;
    }

    public float GetCollectingDuration()
    {
        return _collectingDuration;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public float GetRange()
    {
        return _collectingRange;
    }

    public float GetWeight()
    {
        return _weight;
    }

    public void SetSelected(bool selected)
    {
        _selected = selected;
        _renderer.material = selected ? _selectedMaterial : _defaultMaterial;
    }

    public virtual void OnArive(INavigatable navigatable) { }
}

public interface ICollectable
{
    float GetCollectingDuration();

    float GetWeight();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public abstract class Boat : MonoBehaviour, INavigatable {

    [SerializeField]
    private Material _selectedMaterial;
    private Material _defaultMaterial;

    [SerializeField]
    private float _movementSpeed;

    [SerializeField]
    private float _collectingSpeed;

    private float _cargoWeight = 0;

    private float _collectingTimer;
    private ICollectable _collecting;

    private IDestination _destination;
    private BoatState _state;

    private void Start()
    {
        _defaultMaterial = GetComponent<Renderer>().material;
        _state = BoatState.IDLE;
    }

    private void Update ()
    {
        switch (_state)
        {
            case BoatState.NAVIGATING:
                if (Vector3.Distance(_destination.GetPosition(), transform.position) <= _destination.GetRange())
                {
                    if (_destination is ICollectable)
                    {
                        SetState(BoatState.COLLECTING);
                        _collecting = _destination as ICollectable;
                        _collectingTimer = _collecting.GetCollectingDuration();
                    }                       
                    else
                        _state = BoatState.IDLE;

                    _destination.OnArive(this);
                    _destination.SetSelected(false);
                    SetSelected(false);
                    _destination = null;
                }
                break;

            case BoatState.COLLECTING:
                _collectingTimer -= Time.deltaTime * _collectingSpeed;
                if(_collectingTimer <= 0)
                {
                    _cargoWeight += _collecting.GetWeight();
                    GameObject gameObject = (_collecting as MonoBehaviour).gameObject;
                    Destroy(gameObject);
                    SetState(BoatState.IDLE);
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        if (_destination != null)
        {
            Vector3 position = _destination.GetPosition();
            position.y = transform.position.y;
            transform.LookAt(position);
            transform.Translate(Vector3.forward * Time.fixedDeltaTime * ((1 - GetCargoWeight()) * _movementSpeed));
        }
    }

    public void SetState(BoatState state)
    {
        _state = state;
    }

    public float GetCargoWeight()
    {
        return _cargoWeight;
    }

    public void ClearCargo()
    {
        _cargoWeight = 0f;
    }

    public void NavigateTo(IDestination destination)
    {
        if (CanNavigateTo(destination))
        {
            _destination = destination;
            SetState(BoatState.NAVIGATING);
        }
    }

    public void SetSelected(bool selected)
    {
        GetComponent<Renderer>().material = selected ? _selectedMaterial : _defaultMaterial;
    }

    public abstract bool CanCollect(ICollectable collectable);

    public bool CanNavigateTo(IDestination destination)
    {
        if (destination is ICollectable)
            return CanCollect(destination as ICollectable);
        return true;
    }
}

public enum BoatState
{
    IDLE,
    NAVIGATING,
    COLLECTING
}

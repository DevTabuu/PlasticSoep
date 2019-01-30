using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boat : Selectable, INavigatable {

    [SerializeField]
    private float _movementSpeed;

    [SerializeField]
    private float _collectingSpeed;

    [SerializeField]
    private Animator _animator;

    private float _cargoWeight = 0;

    private float _collectingTimer;
    private Collectable _collecting;

    private Destination _destination;
    private BoatState _state;

    protected virtual void Start()
    {
        _state = BoatState.IDLE;
    }

    private void Update ()
    {
        switch (_state)
        {
            case BoatState.NAVIGATING:
                if (Vector3.Distance(_destination.GetPosition(), transform.position) <= _destination.GetRange())
                {
                    if (_destination is Collectable)
                    {
                        SetState(BoatState.COLLECTING);
                        _collecting = _destination as Collectable;
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
            transform.Translate(Vector3.forward * Time.fixedDeltaTime * ((2 - GetCargoWeight()) * _movementSpeed));
        }
    }

    public void SetState(BoatState state)
    {
        _animator.SetInteger("State", (int) state);

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

    public void NavigateTo(Destination destination)
    {
        if (CanNavigateTo(destination))
        {
            _destination = destination;
            SetState(BoatState.NAVIGATING);
        }
    }

    public abstract bool CanCollect(Collectable collectable);

    public bool CanNavigateTo(Destination destination)
    {
        if (destination is Collectable)
            return CanCollect(destination as Collectable);
        return true;
    }

    public void OnArive(IDestination destination)
    {

    }
}

public enum BoatState
{
    IDLE,
    NAVIGATING,
    COLLECTING
}

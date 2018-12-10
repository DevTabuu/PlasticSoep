using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour, INavigatable {

    [SerializeField]
    private float _movementSpeed;

    [SerializeField]
    private float _collectingSpeed;

    private float _cargoWeight = 0;

    private float _collectingTimer;
    private ICollectable _collecting;

    private IDestination _destination;
    private BoatState _state = BoatState.IDLE;

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
                    {
                        _state = BoatState.IDLE;
                    }

                    _destination.OnArive(this);
                    _destination = null;

                    Debug.Log("Boat arived!");
                }

                break;

            case BoatState.COLLECTING:
                _collectingTimer -= Time.deltaTime * _collectingSpeed;
                if(_collectingTimer <= 0)
                {
                    _cargoWeight += _collecting.GetWeight();
                    Debug.Log("Collected!");
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
            transform.LookAt(_destination.GetPosition());
            transform.Translate(Vector3.forward * Time.fixedDeltaTime * ((1 - GetCargoWeight()) * _movementSpeed));
        }
    }

    public void SetState(BoatState state)
    {
        Debug.Log(_state + " > " + state);
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

    public void SetDestination(IDestination destination)
    {
        _destination = destination;
        SetState(BoatState.NAVIGATING);

        Debug.Log("This boat is going to " + destination.GetPosition());
    }
}

public enum BoatState
{
    IDLE,
    NAVIGATING,
    COLLECTING
}

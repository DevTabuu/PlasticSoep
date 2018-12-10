using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {


    private Dictionary<int, INavigatable> _controlling;

    private void Start()
    {
        _controlling = new Dictionary<int, INavigatable>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // reference:
            // var ss = FindObjectsOfType<MonoBehaviour>().OfType<INavigatable>();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject hitGameObject = hit.transform.gameObject;
                INavigatable navigatable = hitGameObject.GetComponent<INavigatable>();
                if (navigatable != null)
                {
                    // 0 is the player id, this needs to be the player id / finger id.
                    _controlling.Add(0, navigatable);
                }
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject hitGameObject = hit.transform.gameObject;
                IDestination destination = hitGameObject.GetComponent<IDestination>();
                if (destination != null && _controlling.ContainsKey(0))
                {
                    INavigatable navigatable = _controlling[0];
                    navigatable.SetDestination(destination);
                }
            }

            _controlling.Remove(0);
        }

    }
}

public interface INavigatable
{
    void SetDestination(IDestination destination);
}

public interface IDestination
{
    Vector3 GetPosition();

    float GetRange();

    void OnArive(INavigatable navigatable);
}

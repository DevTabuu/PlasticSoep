using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private Dictionary<int, INavigatable> _controlling;

    private void Start()
    {
        _controlling = new Dictionary<int, INavigatable>();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        foreach (ISelectable select in FindObjectsOfType<MonoBehaviour>().OfType<ISelectable>())
        {
            if (!(select is INavigatable && _controlling.ContainsValue(select as INavigatable)))
                select.SetSelected(false);
        }

        if (Physics.Raycast(ray, out hit, 100))
        {
            GameObject hitGameObject = hit.transform.gameObject;

            ISelectable selectable = hitGameObject.GetComponent<ISelectable>();
            if (selectable != null)
            {
                if (selectable is INavigatable && !_controlling.ContainsKey(0))
                    selectable.SetSelected(true);
                else if (selectable is IDestination && _controlling.ContainsKey(0) && _controlling[0].CanNavigateTo(selectable as IDestination))
                    selectable.SetSelected(true);
            }

            if (Input.GetMouseButtonDown(0))
            {
                INavigatable navigatable = hitGameObject.GetComponent<INavigatable>();
                if (navigatable != null)
                {
                    // 0 is the player id, this needs to be the player id / finger id.
                    _controlling.Add(0, navigatable);
                }
            }

            else if (Input.GetMouseButtonUp(0))
            {
                IDestination destination = hitGameObject.GetComponent<IDestination>();
                if (destination != null && _controlling.ContainsKey(0))
                {
                    INavigatable navigatable = _controlling[0];
                    if (navigatable.CanNavigateTo(destination))
                    {
                        navigatable.NavigateTo(destination);
                    }
                }
                _controlling.Remove(0);
            }
        }
    }
}

public interface INavigatable : ISelectable
{
    bool CanNavigateTo(IDestination destination);
    void NavigateTo(IDestination destination);
}

public interface IDestination : ISelectable
{
    Vector3 GetPosition();

    float GetRange();

    void OnArive(INavigatable navigatable);
}

public interface ISelectable
{
    void SetSelected(bool selected);
}

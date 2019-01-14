using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable : MonoBehaviour, ISelectable
{
    [SerializeField]
    private SelectCircle _selectCircle;

    private bool _selected;


    public void SetSelected(bool selected)
    {
        if (_selectCircle != null)
        {
            _selected = selected;
            _selectCircle.gameObject.SetActive(selected);
        }
    }
    public bool IsSelected()
    {
        return _selected;
    }
}

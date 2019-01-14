using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ProgressionCircle : MonoBehaviour {

    [SerializeField]
    private Color _color;

    private float _cutoff;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetCutoff(float cutoff)
    {
        _cutoff = cutoff;

        _renderer.material.SetColor("_Color", _color);
        _renderer.material.SetFloat("_Cutoff", _cutoff);
    }

    public float GetCutoff()
    {
        return _cutoff;
    }
}

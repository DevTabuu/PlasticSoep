using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SelectCircle : MonoBehaviour {

    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void SetColor(Color color)
    {
        _renderer.color = color;
    }
}

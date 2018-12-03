using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashIslandScript : MonoBehaviour {

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update ()
    {
        if (transform.position.y < _renderer.bounds.extents.y)
        {
            transform.position += (Vector3.up * Time.deltaTime);
        }

        Debug.Log(_renderer.bounds.extents.y);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashIslandScript : MonoBehaviour {

    private RectTransform _rectTransform ;

    private void Start()
    {
    }

    private void Update ()
    {
		if(transform.position.y < )
        {
            transform.position = Vector3.up;
        }

        Debug.Log(_bounds.max.y);
	}
}

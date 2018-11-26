using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour {

    private float _speed;



    private void Start () {
	}

    private void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
            }
        }

    }

    private void FixedUpdate()
    {
        
    }
}

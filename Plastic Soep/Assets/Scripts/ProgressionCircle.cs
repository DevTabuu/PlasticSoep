using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressionCircle : MonoBehaviour {

    [SerializeField]
    private GameObject _ObjectToFollow;

    private Image _image;

    public float _Completion = 0;

    private void Start()
    {
        _image = GetComponent<Image>();      
    }

    private void Update()
    {
        _image.fillAmount = (_Completion / 100);

        if(_ObjectToFollow != null)
        {
            transform.position = new Vector3(_ObjectToFollow.transform.position.x, transform.position.y, _ObjectToFollow.transform.position.z);
        }
    }

    public void Complete()
    {
        _Completion += (Time.deltaTime / 5);
    }
}

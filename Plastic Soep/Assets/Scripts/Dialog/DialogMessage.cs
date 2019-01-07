using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogMessage : MonoBehaviour {

    private Text _text;

    public void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void SetMessage(string message)
    {
        _text.text = message;
    }

    public void Close()
    {
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    [SerializeField]
    private GameObject _dialogPrefab;

    [SerializeField]
    private Canvas _canvas;

    Dictionary<DialogMessage, float> _timers;

    private void Awake()
    {
        _timers = new Dictionary<DialogMessage, float>();
    }

    public void ShowDialog(Transform target, string message, float time)
    {
        GameObject dialog = Instantiate(_dialogPrefab, _canvas.transform);
        DialogMessage dialogMessage = dialog.GetComponent<DialogMessage>();
        dialog.transform.position = Camera.main.WorldToScreenPoint(target.position);

        dialogMessage.SetMessage(message);

        _timers.Add(dialogMessage, time);
    }

    public void Update()
    {
        Dictionary<DialogMessage, float> clone = new Dictionary<DialogMessage, float>(_timers);

        foreach (KeyValuePair<DialogMessage, float> pair in clone)
        {
            float timer = pair.Value;
            DialogMessage message = pair.Key;
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                _timers.Remove(message);
                message.Close();
            }
            else
                _timers[message] = timer;
        }
    }
}

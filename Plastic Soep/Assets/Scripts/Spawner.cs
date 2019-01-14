using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private Transform _parent;

    [SerializeField]
    private GameObject _spawnedCollectable;

    private Transform[] _spawnLocations;

    private void Start()
    {
        _spawnLocations = GetComponentsInChildren<Transform>();
    }

    public GameObject Spawn()
    {
        System.Random r = new System.Random();
        foreach (int i in Enumerable.Range(0, _spawnLocations.Length).OrderBy(x => r.Next()))
        {
            Transform transform = _spawnLocations[i];
            if (transform.childCount == 0)
            {
                return Instantiate(_spawnedCollectable, transform);
            }
        }

        return null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Spawn();
    }
}

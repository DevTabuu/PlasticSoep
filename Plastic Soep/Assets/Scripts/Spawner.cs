using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private Transform _parent;

    [SerializeField]
    private GameObject _spawnedCollectable;

    [SerializeField]
    private float _minSpawnRange;

    [SerializeField]
    private float _maxSpawnRange;

    public void Spawn()
    {
        float range = _maxSpawnRange - _minSpawnRange;
        float x = Random.Range(-range, range);
        float z = Random.Range(-range, range);

        if(Random.value >= 0.5)
            x += x < 0 ? (_minSpawnRange * -1) : _minSpawnRange;
        else
            z += z < 0 ? (_minSpawnRange * -1) : _minSpawnRange;

        Vector3 spawnLocation = new Vector3(x, transform.position.y, z);
        Instantiate(_spawnedCollectable, spawnLocation, Quaternion.identity, _parent);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Spawn();
    }
}

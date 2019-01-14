using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour {

    [SerializeField]
    private float _fishValue, _trashValue;

    private List<GameObject> _fishSwarms;
    private List<GameObject> _trashIslands;

    [SerializeField]
    private Spawner _fishSpawner, _trashSpawner;

    private float _fishSpawnTimer, _trashSpawnTimer, _fishTimer, _trashTimer;

    private void Start()
    {
        _fishSwarms = new List<GameObject>();
        _trashIslands = new List<GameObject>();

        _fishSpawnTimer = 1;
        _trashSpawnTimer = 1;
        _fishTimer = 0;
        _trashTimer = 0;
    }

    void Update()
    {
        _fishTimer += Time.deltaTime;
        _trashTimer += Time.deltaTime;

        CalculateFishSpawnTime();

        if(_trashTimer >= _trashSpawnTimer)
        {
            AddTrashIsland(_trashSpawner.Spawn());
            _trashTimer = 0;
        }

        if(_fishTimer >= CalculateFishSpawnTime())
        {
            AddFishSwarm(_fishSpawner.Spawn());
            _fishTimer = 0;
        }

        for (int i = 0; i < _fishSwarms.Count; i++)
        {
            ProgressionCircle pc = _fishSwarms[i].GetComponent<ProgressionCircle>();

            pc.SetCutoff(_fishValue);
        }

        for (int i = 0; i < _trashIslands.Count; i++)
        {
            ProgressionCircle pc = _trashIslands[i].GetComponent<ProgressionCircle>();

            pc.SetCutoff(_trashValue);
        }
    }

    public void AddFishSwarm(GameObject go)
    {
        _fishSwarms.Add(go);
    }

    public void AddTrashIsland(GameObject go)
    {
        _trashIslands.Add(go);
    }

    private float CalculateFishSpawnTime()
    {
        foreach(GameObject trashIsland in _trashIslands)
        {
            _fishSpawnTimer *= 1.2f;
            return _fishSpawnTimer;
        }

        return _fishSpawnTimer;
    }
}


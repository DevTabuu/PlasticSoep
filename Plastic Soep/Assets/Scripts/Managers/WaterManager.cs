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

    private float _incrementValue;

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
        SpawnStuff();

        for (int i = 0; i < _fishSwarms.Count; i++)
        {
            ProgressionCircle pc;

            if (_fishSwarms[i] != null)
                pc = _fishSwarms[i].GetComponent<ProgressionCircle>();
            else
                pc = null;

            if (pc != null)
                pc.SetCutoff(_fishValue);
        }

        for (int i = 0; i < _trashIslands.Count; i++)
        {
            ProgressionCircle pc;

            if (_trashIslands[i] != null)
                pc = _trashIslands[i].GetComponent<ProgressionCircle>();
            else
                pc = null;

            if(pc != null)
                pc.SetCutoff(_trashValue);
        }
    }

    #region Spawning

    private void SpawnStuff()
    {
        _fishTimer += Time.deltaTime;
        _trashTimer += Time.deltaTime;

        if (_trashTimer >= _trashSpawnTimer)
        {
            AddTrashIsland(_trashSpawner.Spawn());
            _trashTimer = 0;
        }

        if (_fishTimer >= _fishSpawnTimer)
        {
            AddFishSwarm(_fishSpawner.Spawn());
            _fishTimer = 0;
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

    public void AddToFishTimer(float value)
    {
        _incrementValue = value / 10;

        _fishSpawnTimer *= (1 + _incrementValue);
    }
    

    public void RemoveFromFishTimer(float originalIncrementValue)
    {
        float decreaseValue = (100 / (100 + (originalIncrementValue * 10)));

        _fishSpawnTimer = (_fishSpawnTimer * decreaseValue);
    }

    #endregion

    #region Circle



    #endregion
}


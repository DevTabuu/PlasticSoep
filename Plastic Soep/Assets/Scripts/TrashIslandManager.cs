using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashIslandManager : MonoBehaviour {

    [SerializeField]
    private GameObject _trashIslandPrefab;

    [SerializeField]
    float _minX, _maxX, _minY, _maxY;

    private float _timer;

	private void Start () {
        _timer = 0;
	}
	
	private void Update () {
        _timer += Time.deltaTime;

        if(_timer >= 2f)
        {
            _timer = 0;
            SpawnTrashIsland();
        }
	}

    private void SpawnTrashIsland()
    {
        Instantiate(_trashIslandPrefab, new Vector3(Random.Range(_minX, _maxX), 0, Random.Range(_minY, _maxY)), Quaternion.identity);
    }
}

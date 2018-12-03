using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashIslandManager : MonoBehaviour {

    public GameObject _trashIslandPrefab;

    [SerializeField]
    float _minX, _maxX, _minY, _maxY;

    private float _timer;

    Renderer _trashRenderer;

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
        _trashRenderer = _trashIslandPrefab.GetComponent<Renderer>();

        Vector3 spawnPosition = new Vector3(Random.Range(_minX, _maxX), 0, Random.Range(_minY, _maxY));
        Vector3 radius = new Vector3(_trashRenderer.bounds.size.x, 0, _trashRenderer.bounds.size.z);

        if(Physics.CheckSphere(spawnPosition, radius.x) != true)
        {
            Instantiate(_trashIslandPrefab, spawnPosition, Quaternion.identity);
        }

        else
        {
            SpawnTrashIsland();
        }
    }
}

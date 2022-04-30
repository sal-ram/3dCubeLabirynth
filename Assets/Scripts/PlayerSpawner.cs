using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;
    public GameObject obj { get; set; }

    public void SpawnPlayer()
    {
        int size = MazeSpawner.length;
        float coeff = MazeSpawner.coeff;
        obj = Instantiate(_playerPrefab, new Vector3(Random.Range(1, size) * coeff, size * coeff + 0.3f, Random.Range(1, size) * coeff), _playerPrefab.transform.rotation);
    }

    public void OnDestroy()
    {
        Destroy(obj);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject obj { get; set; }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        int size = MazeSpawner.length;
        float coeff = MazeSpawner.coeff;
        obj = Instantiate(playerPrefab, new Vector3(Random.Range(1, size) * coeff, size * coeff + 0.3f, Random.Range(1, size) * coeff), playerPrefab.transform.rotation);
    }

    public void OnDestroy()
    {
        Destroy(obj);
    }
}

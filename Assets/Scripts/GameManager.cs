using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MazeSpawner mazeManager;
    private PlayerSpawner playerManager;

    [SerializeField]
    private GameObject _MazeSpawner;
    [SerializeField]
    private GameObject _PlayerSpawner;
    [SerializeField]
    private ViewManager _MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        mazeManager = _MazeSpawner.GetComponent<MazeSpawner>();
        playerManager = _PlayerSpawner.GetComponent<PlayerSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.IsFinished)
        {
            _MainMenu.FinishWindowActivate();
            PlayerController.IsFinished = false;
        }
    }

    public void StartGame(int size)
    {
        mazeManager.sizeCube = size;
        mazeManager.SpawnMaze();

        playerManager.SpawnPlayer();
    }

    public void OnDestroy()
    {
        mazeManager.OnDestroy();
        playerManager.OnDestroy();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MazeSpawner mazeManager;
    private PlayerSpawner playerManager;

    public GameObject MazeSpawner;
    public GameObject PlayerSpawner;
    public GameObject finishWindow;
    public GameObject MainMenuButton;
    // Start is called before the first frame update
    void Start()
    {
        mazeManager = MazeSpawner.GetComponent<MazeSpawner>();
        playerManager = PlayerSpawner.GetComponent<PlayerSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.IsFinished)
        {
            finishWindow.SetActive(true);
            MainMenuButton.SetActive(false);
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

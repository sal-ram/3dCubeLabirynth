using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    public CubeController cubeObj { get; set; }
    public PlayerController playerObj { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical") * Time.deltaTime;
        horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime;

        if (cubeObj != null && playerObj != null)
        {
            cubeObj.MoveCube(verticalInput, horizontalInput);
            playerObj.MovePlayer(verticalInput, horizontalInput);
        }
    }
}

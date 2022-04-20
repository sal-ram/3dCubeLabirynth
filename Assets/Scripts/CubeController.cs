using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    public int movementSpeed = 15;

    private Vector3 center;
    // Start is called before the first frame update
    void Start()
    {
        //здесь пытаюсь найти более менее адекватный центр куба лабиринта, чтобы потом относительно него вращать куб лабиринт
        float size = MazeSpawner.length + 5;
        center = new Vector3(size / 2f, size / 2f, size / 2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.RotateAround(center, Vector3.right, verticalInput);

        horizontalInput = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        transform.RotateAround(center, Vector3.forward, -horizontalInput);
    }
}

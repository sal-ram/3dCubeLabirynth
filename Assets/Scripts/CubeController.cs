using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private int movementSpeed = 45;
    private InputController controller;

    private Vector3 center;
    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<InputController>();
        controller.cubeObj = this;

        //здесь пытаюсь найти более менее адекватный центр куба лабиринта, чтобы потом относительно него вращать куб лабиринт
        float size = MazeSpawner.length + 5;
        center = new Vector3(size / 2f, size / 2f, size / 2f);
    }

    public void MoveCube(float vertical, float horizontal)
    {
        transform.RotateAround(center, Vector3.right, vertical * movementSpeed);
        transform.RotateAround(center, Vector3.forward, -horizontal * movementSpeed);
    }

}

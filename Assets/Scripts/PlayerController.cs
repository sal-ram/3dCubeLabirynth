using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float strength = 2f;
    private InputController controller;
    public static bool IsFinished { get; set; } = false;
    Rigidbody rg;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<InputController>();
        controller.playerObj = this;
        rg = gameObject.GetComponent<Rigidbody>();
    }

    public void MovePlayer(float vertical, float horizontal)
    {
        rg.AddForce(Vector3.right * strength * (-1) * vertical, ForceMode.Acceleration);
        rg.AddForce(Vector3.forward * strength * (-1) * horizontal, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ceiling") || other.gameObject.CompareTag("Wall"))
        {
            gameObject.transform.position = gameObject.transform.position;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            IsFinished = true;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float strength = 2f;
    private float verticalInput;
    private float horizontalInput;
    public static bool IsFinished = false; 
    Rigidbody rg;
    // Start is called before the first frame update
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");

        horizontalInput = Input.GetAxis("Horizontal");

        rg.AddForce(Vector3.right * strength *(-1)* Time.deltaTime * verticalInput, ForceMode.Acceleration);
        rg.AddForce(Vector3.forward * strength * (-1) * Time.deltaTime * horizontalInput, ForceMode.Acceleration);
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

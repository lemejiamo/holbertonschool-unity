using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // instance Rigidbody into rb
    private Rigidbody rb;
    // control de speed of movement
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // instances a GameObject
        rb = GetComponent<Rigidbody>();    
    }
    //Executed one time pre-frame
    void Update()
    {
        //Control movement in x Axis
        float xDirection = Input.GetAxis("Horizontal");
        //Control movement in z Axis
        float zDirection = Input.GetAxis("Vertical");

        //instance a vector3 
        Vector3 controller = new Vector3(xDirection, 0.0f, zDirection);

        //Aplies vector over GameObject
        rb.AddForce(controller * speed); 
    }
}

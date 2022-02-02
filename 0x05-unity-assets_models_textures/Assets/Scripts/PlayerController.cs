using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // objects to controll movement
    public float horizontalMove;
    public float verticalMove;
    public float speed;

    public Vector3 playerDirection;

    // objects to control the camera move
    private Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRigth;

    // stores the vector transfrom to applies the movement
    public Vector3 playerInput;

    // instance from required classes
    public CharacterController player;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        mainCamera = FindObjectOfType<Camera>(MainCamera);
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the input 
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        // Create the movement vector
        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        CameraDirection();

        playerDirection = playerInput.x * camRigth + playerInput.z * camForward;

        // applies the movement
        player.Move(playerDirection * speed * Time.deltaTime);
        print(mainCamera);
    }

    void CameraDirection()
    {
        camForward = mainCamera.transform.forward;
        camRigth = mainCamera.transform.right;

        camForward.y = 0;
        camRigth.y = 0;

        camForward = camForward.normalized;
        camRigth = camRigth.normalized;
    }


    private void FixedUpdate()
    {

    }
}

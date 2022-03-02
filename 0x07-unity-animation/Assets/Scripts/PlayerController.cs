using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public objs 
    // for debuging purposes
    public float horizontalMove;
    public float verticalMove;
    public float speed;
    public float jumpForce;
    public float gravityValue;
    public Vector3 playerInput; // stores the vector transfrom to applies the movement
    public Vector3 playerDirection; // stores the vector transfrom to applies the movement
    //public Quaternion playerRotation;

    // public objs 
    // Assign this Objects in Inspertor Window
    public Camera mainCamera;

    // private objs
    private float fallVelocity;

    // objects to control the camera
    private Vector3 camForward;
    private Vector3 camRigth;

    // instance from required classes
    public CharacterController player;

    // Start is called before the first frame update
    void Start()
    {
        // instance required objects
        player = GetComponent<CharacterController>();
        //find the GameObject camera by code when the compoenent is enable in the scene
        //mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        gravityValue = 9.81f;
        jumpForce = 10f;
        speed = 30f;

    }

    // Update is called once per frame
    void Update()
    {
        // DO THE MATH FIRST
        // get's camera possition
        CameraDirection();
        // gets the final move vector
        Move();
        // applies gravity force to the object 
        SetGravity();
        // checks if the player wanna jump
        Jump();
        // execute the move
        MovePlayer();
        //checks if player fall to emptyness and nothing
        Fall();
    }
    // gets camera position
    void CameraDirection()
    {
        camForward = mainCamera.transform.forward;
        camRigth = mainCamera.transform.right;

        camForward.y = 0;
        camRigth.y = 0;

        camForward = camForward.normalized;
        camRigth = camRigth.normalized;
    }
    
    // Function to set the vector to applies move
    void Move()
    {
        // Gets the input 
        horizontalMove = Input.GetAxis("Horizontal");
        
        //horizontalMove = 0f;
        verticalMove = Input.GetAxis("Vertical");

        // Create the movement vector
        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        
        // applies cam direction correction to player 
        playerDirection = (playerInput.x * camRigth) + (playerInput.z * camForward);
        
        // aplies the speed to direction vector
        playerDirection = playerDirection * speed;
        
    }

    //function to set the gravity
    void SetGravity()
    {

        if (player.isGrounded)
        {
            fallVelocity = -gravityValue * Time.deltaTime;
            playerDirection.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravityValue * Time.deltaTime;
            playerDirection.y = fallVelocity;
        }

    }
    
    // Jump Skill
    private void Jump()
    {
        if (Input.GetKey("space") && player.isGrounded)
        {
            fallVelocity = jumpForce;
            playerDirection.y = fallVelocity;
        }
    }

    private void MovePlayer()
    {
        // make the  move
        player.Move(playerDirection * Time.deltaTime);
        playerDirection.y = 0f;
        player.transform.LookAt(player.transform.position + playerDirection);
    }

    private void Fall()
    {
        Vector3 position = player.transform.position;
        if (position.y < -150f)
        {
            float xPosition = position.x;
            Debug.Log(xPosition);
            float zPosition = position.z;
            Debug.Log(zPosition);

            player.transform.Translate(new Vector3(-xPosition, 300f, -zPosition));
        }
    }
}
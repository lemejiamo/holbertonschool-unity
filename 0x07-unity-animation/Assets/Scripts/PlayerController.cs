using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public vars
    // for debuging purposes
    public float horizontalMove;
    public float verticalMove;
    public float speed;
    public float jumpForce;
    public float gravityValue;
    public float fallVelocity;
    public bool running; 
    public bool jumping; 
    public bool stand;
    public bool onGround;
    public bool falling;
    public Vector3 playerInput; // stores the vector transfrom to applies the movement
    public Vector3 playerDirection; // stores the vector transfrom to applies the movement


    // private objs
    // objects to control the camera
    private Vector3 camForward;
    private Vector3 camRigth;

    // instance from required classes
    // public objs 
    // Assign this Objects in your Inspertor Window
    public Camera mainCamera; // this GameObjects can be assigned by code too.
    public CharacterController player; // this GameObjects can be assigned by code too.
    private Animator animator; // this GameObjects is assigned by code.

    // Start is called before the first frame update
    void Start()
    {
        // Gets the  required GameObjects
        player = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        //find the GameObject camera by code when the compoenent is enable in the scene
        //mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        // sets default values for physics
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
        // check if the player stil are in the air
        OnAir();
        // sets the paratameters to play the animations
        SetAnimator();
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
        verticalMove = Input.GetAxis("Vertical");

        // Create the movement vector
        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        
        // applies cam direction correction to player 
        playerDirection = (playerInput.x * camRigth) + (playerInput.z * camForward);
        
        // aplies the speed to direction vector
        playerDirection = playerDirection * speed;

        // condition to stablish  if the player is running or not
        if (horizontalMove == 0 && verticalMove == 0)
        {
            running = false;
            stand = true;
        }
        else
        {
            running = true;
            stand = false;
        }
        
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
            jumping = true;
        }
    }

    // checks if the player  is on air
    private void OnAir()
    {
        if (player.isGrounded)
        {
            onGround = true;
            jumping = false;
            falling = false;
        }
        else if (player.transform.position.y < -20f)
        {
            falling = true;
            jumping = false;
            onGround = false;
            stand = false;
        }
        /*else if (falling  == true)
        {
            jumping = false;
            onGround = false;
        }*/
    }

    // execute the move of the player
    private void MovePlayer()
    {
        // make the  move
        player.Move(playerDirection * Time.deltaTime);
        playerDirection.y = 0f;
        player.transform.LookAt(player.transform.position + playerDirection);
    }

    // checks if the player is falling
    private void Fall()
    {
        Vector3 position = player.transform.position;
        if (position.y < -40f)
        {
            //resets the rotation of player
            player.transform.rotation = new Quaternion(0, 0, 0, 0);
            float xPosition = position.x;
            float zPosition = position.z;
            Debug.Log(xPosition);
            Debug.Log(zPosition);
            OnAir();
            player.transform.Translate(new Vector3(-xPosition, 100f, -zPosition));
        }
    }


    //Sets the parameters to the animator controller
    private void SetAnimator()
    {
        animator.SetBool("running", running);
        animator.SetBool("Stand", stand);
        animator.SetBool("Jumping", jumping);
        animator.SetBool("onground", onGround);
        animator.SetBool("Falling", falling);
    }
}
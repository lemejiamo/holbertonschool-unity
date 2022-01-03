using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // instance Rigidbody into rb
    private Rigidbody rb;
    // control de speed of movement
    public float speed = 20f;

    // control the score of game
    private int score = 0;

    // control the healt
    public int health = 5;

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

        if (this.health == 0)
        {
            Debug.Log("Game Over!");
            RestartGame();
        }
    }

    // Pick up a coin and destroy it when touch it
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            this.score += 1;
            string log = "Score:" + " " + score;
            Debug.Log(log);
            DestroyObject(other.gameObject, 1.0f);
        }

        if (other.tag == "Trap")
        {
            this.health -= 1;
            string log = "Health:" + " " + health;
            Debug.Log(log);
        }

        if (other.tag == "Goal")
        {
            Debug.Log("You Win!");
        }
    }

    // function to restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // instance Rigidbody into rb
    private Rigidbody rb;
    // control de speed of movement
    public float speed = 20f;
    // control the score of game
    private int score = 0;
    // control the healt UI
    public int health = 5;
    // control the score Status UI
    public Text scoreText;
    // Control the Health Status UI
    public Text healthText;
    // control the win or lose message UI
    public Text winLoseText;
    public GameObject winLoseBanner;
    public Image winLoseBannerImage;

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
            //Debug.Log("Game Over!");

            Color red = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            Color white = new Color(1.0f, 1.0f, 1.0f, 1.0f);

            winLoseBanner.SetActive(true);
            winLoseBannerImage.color = red;
            winLoseText.color = white;
            winLoseText.fontStyle = FontStyle.Bold;
            winLoseText.fontSize = 25;
            winLoseText.text = "Game Over!";
            StartCoroutine(LoadScene(3));
        }

        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("menu");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Pick up a coin and destroy it when touch it
        if (other.tag == "Pickup")
        {
            this.score += 1;
            SetScoreText();
            DestroyObject(other.gameObject, 0.2f);
        }
        // rest health when pass through a trap
        if (other.tag == "Trap")
        {
            this.health -= 1;
            SetHealthText();
        }

        // display You Win when reach to the goal
        if (other.tag == "Goal")
        {
            Color green = new Color(0.0f, 1.0f, 0.0f, 1.0f);
            Color black = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            winLoseBanner.SetActive(true);
            winLoseBannerImage.color = green;
            winLoseText.fontStyle = FontStyle.Bold;
            winLoseText.text = "You Win!";
            winLoseText.fontSize = 25;
            winLoseText.color = black;
            StartCoroutine(LoadScene(3));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Goal")
        {
            winLoseBanner.SetActive(false);
        }

    }
    // function to restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Control the score of game
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Function to control the health UI
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    // delay the reset scene
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        RestartGame();
    }

}

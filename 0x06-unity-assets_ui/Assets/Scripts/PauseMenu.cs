using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    private Timer timer_canvas;
    private PlayerController controller;
    public Button restart;
    public Button resume;
    public Button options;
    public Button menu;


    // Start is called before the first frame update
    void Start()
    {
        timer_canvas = GameObject.Find("Player").GetComponent<Timer>();
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
        pauseCanvas.SetActive(false);
        //restart = GameObject.Find("/PauseCanvas/RestartButton").GetComponent<Button>();
        restart.onClick.AddListener(delegate { Restart(); });
        resume.onClick.AddListener(delegate { Resume(); });
        options.onClick.AddListener(delegate { Options(); });
        menu.onClick.AddListener(delegate { MainMenu(); });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel"))
        { 
            if (pauseCanvas.active == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        timer_canvas.enabled = false;
        pauseCanvas.SetActive(true);
        controller.enabled = false;
    }

    public void Resume()
    {
        timer_canvas.enabled = true;
        pauseCanvas.SetActive(false);
        controller.enabled = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        PlayerPrefs.Save();
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");

    }
}

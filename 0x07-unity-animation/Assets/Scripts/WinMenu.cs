using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WinMenu : MonoBehaviour
{
    public Button menu;
    public Button next;

    // Start is called before the first frame update
    void Start()
    {
        menu.onClick.AddListener(delegate { MainMenu(); });
        next.onClick.AddListener(delegate { Next(); });

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        if (SceneManager.GetActiveScene().name == "Level01")
            SceneManager.LoadScene("Level02");
        else if (SceneManager.GetActiveScene().name == "Level02")
            SceneManager.LoadScene("Level03");
        else if (SceneManager.GetActiveScene().name == "Level03")
            SceneManager.LoadScene("MainMenu");

    }
}

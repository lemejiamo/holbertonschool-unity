using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button level01;
    public Button level02;
    public Button level03;
    private GameObject options;
    private GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        options = GameObject.Find("OptionsButton");
        exit = GameObject.Find("ExitButton");

        options.gameObject.GetComponent<Button>().onClick.AddListener(delegate { LoadScene("Options"); });
        exit.gameObject.GetComponent<Button>().onClick.AddListener(delegate { ExitGame(); });

        level01.onClick.AddListener(delegate { LevelSelect(1); });
        level02.onClick.AddListener(delegate { LevelSelect(2); });
        level03.onClick.AddListener(delegate { LevelSelect(3); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LevelSelect(int level)
    {
        string string_level;
        string_level = "Level0" + level.ToString();
        SceneManager.LoadScene(string_level);
    }

    private void LoadScene(string scene)
    {
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(scene);
    }

    private static void ExitGame()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}

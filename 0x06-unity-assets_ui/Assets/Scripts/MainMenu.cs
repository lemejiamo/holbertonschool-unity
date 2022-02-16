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

    // Start is called before the first frame update
    void Start()
    {
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
}

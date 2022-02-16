using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    private GameObject backButton;
    private GameObject applyButton;
    
    // Start is called before the first frame update
    void Start()
    {
        backButton = GameObject.Find("BackButton");
        applyButton = GameObject.Find("ApplyButton");
        backButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { LoadScene("MainMenu"); });

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}

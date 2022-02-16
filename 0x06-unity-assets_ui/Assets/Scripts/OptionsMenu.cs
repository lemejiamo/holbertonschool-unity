using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    private GameObject options;
    private GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        options = GameObject.Find("OptionsButton");
        exit = GameObject.Find("ExitButtobn");

        options.gameObject.GetComponent<Button>().onClick.AddListener(delegate { LoadScene("Options");  });
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text timer;
    public Text record;
    public GameObject winCanvas;
    private PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        // Set's the WinCanvas GameObject as default
        controller = GameObject.Find("Player").GetComponent<PlayerController>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            timer.enabled = false;
            record.text = timer.text;
            winCanvas.SetActive(true);
            controller.enabled = false;
        }
    }
}

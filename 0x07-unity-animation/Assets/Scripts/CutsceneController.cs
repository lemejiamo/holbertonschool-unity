using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour

{
    public GameObject cutScene;
    public Transform possitionController;
    public Vector3 currentPossition;
    public Vector3 finalPossition;
    public GameObject timerCanvas;
    public PlayerController playerController;
    public GameObject mainCamera;



    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        possitionController = GetComponent<Transform>();
        finalPossition = new Vector3(0f, 2.5f, -6.25f);
    }

    // Update is called once per frame
    void Update()
    {
        currentPossition = possitionController.transform.position;
        if (currentPossition == finalPossition)
        {
            MakeTransitionIntro01();

        }

    }

    private void MakeTransitionIntro01()
    {
        playerController.enabled = true;
        mainCamera.SetActive(true);
        timerCanvas.SetActive(true);
        cutScene.SetActive(false);
    }


    
}

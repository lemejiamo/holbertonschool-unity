using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public GameObject backButton;
    private GameObject applyButton;
    private Toggle isInverted;
    private float SFX;
    private float BGM;
    private RectTransform markSFX;
    private RectTransform markBGM;

    // Start is called before the first frame update
    void Start()
    {
        isInverted = GameObject.Find("InvertYToggle").GetComponent<Toggle>();
        backButton = GameObject.Find("BackButton");
        applyButton = GameObject.Find("ApplyButton");
        backButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { Back(); });
        applyButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { Apply(); });
        markSFX = GameObject.Find("HandleSFX").GetComponent<RectTransform>();
        markBGM = GameObject.Find("HandleBGM").GetComponent<RectTransform>();
        SFX = PlayerPrefs.GetFloat("SFX");
        BGM = PlayerPrefs.GetFloat("BGM");

        if (PlayerPrefs.GetString("isInverted") == "true")
            isInverted.isOn = true;
        else
            isInverted.isOn = false;

        float imposible = PlayerPrefs.GetFloat("imposible");

        if (SFX  == 0f)
        {
            markSFX.anchorMin = new Vector2(0.5f, 0f);
            markSFX.anchorMax = new Vector2(0.5f, 1f);
            GameObject.Find("FillSFX").GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1f);
        }
        else
        {
            markSFX.anchorMin = new Vector2(SFX, 0f);
            markSFX.anchorMax = new Vector2(SFX, 1f);
            GameObject.Find("FillSFX").GetComponent<RectTransform>().anchorMax = new Vector2(SFX, 1f);
        }

        if (BGM == 0f)
        {
            markBGM.anchorMin = new Vector2(0.5f, 0f);
            markBGM.anchorMax = new Vector2(0.5f, 1f);
            GameObject.Find("FillBGM").GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1f);
        }
        else
        {
            markBGM.anchorMin = new Vector2(BGM, 0f);
            markBGM.anchorMax = new Vector2(BGM, 1f);
            GameObject.Find("FillBGM").GetComponent<RectTransform>().anchorMax = new Vector2(BGM, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Apply()
    {
        if (isInverted.isOn)
            PlayerPrefs.SetString("isInverted", "true");
        else
            PlayerPrefs.SetString("isInverted", "false");

        SFX = GameObject.Find("FillSFX").GetComponent<RectTransform>().anchorMax.x;
        BGM = GameObject.Find("FillBGM").GetComponent<RectTransform>().anchorMax.x;

        PlayerPrefs.SetFloat("SFX", SFX);
        PlayerPrefs.SetFloat("BGM", BGM);
        //debuging
        Debug.Log($"SFX {SFX}");
        Debug.Log($"BGM {BGM}");
        Debug.Log($"{PlayerPrefs.GetString("isInverted")}");
    }

    private void Back()
    {
        string previous = PlayerPrefs.GetString("PreviousScene");
        SceneManager.LoadScene(previous);  
    }


}

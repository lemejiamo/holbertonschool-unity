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
    public float SFX;
    public float BGM;
    public Slider volSFX;
    public Slider volBGM;


    // Start is called before the first frame update
    void Start()
    {

        isInverted = GameObject.Find("InvertYToggle").GetComponent<Toggle>();
        backButton = GameObject.Find("BackButton");
        applyButton = GameObject.Find("ApplyButton");
        backButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { Back(); });
        applyButton.gameObject.GetComponent<Button>().onClick.AddListener(delegate { Apply(); });


        if (PlayerPrefs.GetString("isInverted") == "true")
            isInverted.isOn = true;
        else
            isInverted.isOn = false;

        if (PlayerPrefs.GetFloat("SFX") != 0)
        {
            SFX = PlayerPrefs.GetFloat("SFX");
            GameObject.Find("FillSFX").GetComponent<RectTransform>().anchorMax.Set(SFX, 1f);
        }
        else
        {
            GameObject.Find("FillSFX").GetComponent<RectTransform>().anchorMax.Set(0.5f, 1f);
        }

        if (PlayerPrefs.GetFloat("BGM") != 0)
        {
            BGM = PlayerPrefs.GetFloat("BGM");
            GameObject.Find("FillBGM").GetComponent<RectTransform>().anchorMax.Set(BGM, 1f);
        }
        else
        {
            GameObject.Find("FillBGM").GetComponent<RectTransform>().anchorMax.Set(0.5f, 1f);
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

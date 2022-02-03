using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer.text = "0:00.0"; 
    }

    // Update is called once per frame
    void Update()
    {
        bool power = timer.isActiveAndEnabled;
        if (power == true)
        {
            string textTime = Time.fixedTime.ToString("f");
            //Debug.Log($"texttime {textTime}");
            float timeMeasure = float.Parse(textTime, System.Globalization.CultureInfo.InvariantCulture) / 100f;
            //timeMeasure = Mathf.Round(timeMeasure);
            //Debug.Log($"timeMeasure {timeMeasure}");
            float minutes = Mathf.Floor(timeMeasure / 60);
            int intMinutes = (int)minutes;
            float seconds = (timeMeasure % 60);

            //Debug.Log($"minutes {minutes}");
            //Debug.Log($"seconds {seconds}");

            textTime = minutes.ToString("00") + ":" + seconds.ToString("00.00");
            timer.text = textTime;
        }

    }
}

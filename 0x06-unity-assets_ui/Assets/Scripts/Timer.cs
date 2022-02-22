using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text timer;
    public Text record;
    private float time = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        timer.text = "00:00.0"; 
        record = GameObject.Find("/WinCanvas/FinalTime").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        bool timer_state = timer.isActiveAndEnabled;
        if (timer_state == true)
        {
            time += Time.deltaTime;
            string textTime = time.ToString("f");
            float timeMeasure = float.Parse(textTime, System.Globalization.CultureInfo.InvariantCulture) / 100f;
            float minutes = Mathf.Floor(timeMeasure / 60);
            int intMinutes = (int)minutes;
            float seconds = (timeMeasure % 60);

            textTime = minutes.ToString("00") + ":" + seconds.ToString("00.00");
            timer.text = textTime;
        }
       

    }
    public void Win()
    {
        record.text = timer.ToString();
    }
}

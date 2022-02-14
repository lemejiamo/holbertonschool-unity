using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Timer player;
    void Start()
    {
        //player = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
        Debug.Log("collision");
            player.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Vector3 ofset;
    private Transform target;
    [Range (0, 1)] public float lerpValue;
    [Range(0, 10)] public float sensitive;
    public int inverted;
    public bool isInverted;

    private void Start()
    {
        if (PlayerPrefs.GetString("isInverted") == "true")
        {
            Debug.Log("Y axis is inverted");
            inverted = -1;
        }
        else
        {
            Debug.Log("Y axis is not inverted");
            inverted = 1;
        }
        target = GameObject.Find("Player").transform;
        //ofset = new Vector3(-6f, 2f, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse Buton pressed");
            ofset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensitive, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * inverted * sensitive, Vector3.left) * ofset;
        }
        transform.position = Vector3.Lerp(transform.position, target.position + ofset, lerpValue);
        transform.LookAt(target);
    }
}
  
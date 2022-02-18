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
    private bool isInverted = false;
    public int inverted;

    private void Start()
    {
        if (PlayerPrefs.GetString("isInverted") == "true")
        {
            Debug.Log("is inverted");
            isInverted = true;
            inverted = -1;
        }
        else
        {
            Debug.Log("not is inverted");
            isInverted = false;
            inverted = 1;
        }
        target = GameObject.Find("Player").transform;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + ofset, lerpValue);
        ofset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensitive, Vector3.up) * Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * inverted * sensitive, Vector3.left) * ofset;
        transform.LookAt(target);
    }
}
  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 ofset;
    private Transform target;
    [Range (0, 1)] public float lerpValue;
    [Range(0, 10)] public float sensitive; 

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + ofset, lerpValue);
        ofset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensitive, Vector3.up) * ofset;
        transform.LookAt(target);
    }
}
  
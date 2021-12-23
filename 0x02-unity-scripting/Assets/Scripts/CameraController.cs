using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Transform camera;
    public Vector3 ofset = new Vector3(1f, 40f, -20f);

    // Update is called once per frame
    void Update()
    {
        transform.position = camera.position + ofset;
    }
}

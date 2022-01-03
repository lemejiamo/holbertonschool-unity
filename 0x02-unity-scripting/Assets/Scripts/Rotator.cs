using UnityEngine;
using System;


public class Rotator : MonoBehaviour
{
    public float xAngle=2.0f, yAngle, zAngle;

    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }
}

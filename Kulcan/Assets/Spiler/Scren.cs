using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scren : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visable = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(-Input.GetAxisRaw("Mouse Y"), -Input.GetAxisRaw("Mouse X"), 0);
    }
}

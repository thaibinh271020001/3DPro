using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    public float anglePerSecond;
    float yaw = 0f;
    float yawY = 0f;
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");        
        float mouseY = Input.GetAxis("Mouse Y");

        yaw += mouseX * anglePerSecond;
        yawY += mouseY * anglePerSecond *(-1);
        transform.localEulerAngles = new Vector3(yawY, yaw, 0);
    }
}

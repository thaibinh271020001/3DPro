using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    public float anglePerSecond;
    float yaw = 0f;
    float yawY = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        Move();
    }
    public void Move()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        yaw += mouseX * anglePerSecond;
        yawY += mouseY * anglePerSecond * (-1);

        if (yawY > -90 && yawY < 90)
        {
            transform.localEulerAngles = new Vector3(yawY, yaw, 0);
        }
        else if (yawY >= 90)
        {
            yawY = 90;
        }
        else
        {
            yawY = -90;
        }
    }
}

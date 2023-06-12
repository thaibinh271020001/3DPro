using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKey : MonoBehaviour
{
    public CharacterController characterController;
    public float movingSpeed;

    private void OnValidate() => characterController = GetComponent<CharacterController>();

    private void Update()
    {
        float horizoltalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * horizoltalInput + transform.forward * verticalInput;
        characterController.SimpleMove(direction * movingSpeed);
    }
}

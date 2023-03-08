using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerController playerController;
    PlayerInput playerInput;
    public GameObject rightArm;
    public GameObject leftArm;

    private Renderer rightRend;
    private Renderer leftRend;
    Rigidbody selectedRd;
    //public Vector2 s;


    private void Awake()
    {
        //selectedRd = this.GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        PlayerController playerController = new PlayerController();
        playerController.Gameplay.Enable();
        playerController.Gameplay.Move.performed += Movement_performed;
    }

    public void SelectRightArm(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //s = rightArm.transform.position;
            selectedRd = rightArm.GetComponent<Rigidbody>();
            rightRend = rightArm.GetComponent<Renderer>();
            rightRend.material.color = Color.red;
        }
        else
        {
            rightRend.material.color = Color.white;
            selectedRd = null;

        }

    }

    public void SelectLeftArm(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //s = leftArm.transform.position;
            selectedRd = leftArm.GetComponent<Rigidbody>();
            leftRend = leftArm.GetComponent<Renderer>();
            leftRend.material.color = Color.red;
        }
        else
        {
            leftRend.material.color = Color.white;
            selectedRd = null;
        }

    }


    private void Movement_performed(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        float speed = 2f;
        selectedRd.AddForce(new Vector2(inputVector.x,inputVector.y) * speed, ForceMode.Force);
        Debug.Log(selectedRd);
    }

    void Update()
    {
        Vector2 inputVector = playerController.Gameplay.Move.ReadValue<Vector2>();
        float speed = 5f;
        selectedRd.AddForce(new Vector2(inputVector.x,inputVector.y) * speed, ForceMode.Force);
        Debug.Log(inputVector);
    }



}

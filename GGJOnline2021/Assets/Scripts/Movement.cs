using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] CharacterController characterController;
    [SerializeField] float moveSpeed = 3F;
    Vector3 moveVector;
    Vector3 frictionMove;

    [SerializeField] Camera mainCamera;
    Vector3 cameraR;
    Vector3 cameraF;

    [SerializeField] float gravity;
    float Yvelocity;

    [SerializeField] float friction;

    Vector2 inputsPlayer;


    void Update()
    {
        Move();
    }

    public void Move()
    {

        //Vector2 moveXY = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        inputsPlayer = inputsPlayer.normalized;

        cameraR = mainCamera.transform.right;
        cameraF = mainCamera.transform.forward;

        GravityPlayer();

        moveVector = (inputsPlayer.x * cameraR + inputsPlayer.y * cameraF ) * moveSpeed;
        moveVector.y = Yvelocity;

        //Friccion movimiento
        frictionMove = Vector3.Lerp(frictionMove, moveVector, friction * Time.deltaTime);

        characterController.Move(frictionMove * Time.deltaTime);

    }

    

    public void GravityPlayer()
    {

        if (characterController.isGrounded)
        {
            Yvelocity = -gravity * Time.deltaTime;
        }
        else
        {
            Yvelocity -= gravity * Time.deltaTime;
        }

    }

    public void OnMove(InputValue input)
    {
        inputsPlayer = input.Get<Vector2>();

    }

}

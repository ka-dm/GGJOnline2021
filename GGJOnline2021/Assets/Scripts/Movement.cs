
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterController characterController;
    [SerializeField] Animator animPlayer;
    Transform character;

    Vector3 moveVector;
    Vector3 frictionMove;

    [SerializeField] Camera mainCamera;
    Vector3 cameraR;
    Vector3 cameraF;

    float Yvelocity;
    [Header("Movement")]
    [SerializeField] float friction = 10f;
    [SerializeField] float moveSpeed = 3F;
    [SerializeField] float rotateSpeed = 3F;
    [SerializeField] float gravity;

    [Header("Interactive")]
    [SerializeField] float forcePush;

    Vector2 inputsPlayer;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        characterController = GetComponent<CharacterController>();
        character = GetComponent<Transform>();
    }
    void Update()
    {
        Move();
        Animation();
    }

    public void Move()
    {

        inputsPlayer = inputsPlayer.normalized;

        cameraR = mainCamera.transform.right;
        cameraF = mainCamera.transform.forward;

        GravityPlayer();

        moveVector = (inputsPlayer.x * cameraR + inputsPlayer.y * cameraF) * moveSpeed;
        moveVector.y = Yvelocity;

        //rotacion del personaje
        RotatePlayer();

        //Friccion movimiento
        frictionMove = Vector3.Lerp(frictionMove, moveVector, friction * Time.deltaTime);

        characterController.Move(frictionMove * Time.deltaTime);




    }


    public void RotatePlayer()
    {
        if (inputsPlayer.x != 0 || inputsPlayer.y != 0)
        {
            Vector3 lookAt = moveVector;
            lookAt.y = 0;
            Quaternion look = Quaternion.LookRotation(lookAt, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, look, rotateSpeed * Time.deltaTime );
        }

    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body  = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }


        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        body.velocity = pushDir * forcePush;
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
        Debug.Log("a");
    }


    public void Animation()
    {
        Vector2 velocity = new Vector2(characterController.velocity.x, characterController.velocity.z);
        animPlayer.SetFloat("Speed", velocity.magnitude / moveSpeed);
        /*
        if (velocity.magnitude != 0){
            animPlayer.SetBool("isMoving", true);
        }
        else{
            animPlayer.SetBool("isMoving", false);
        }
        */

    }
     
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] float moveSpeed = 3F;
    [SerializeField] GameObject boyModel;
    [SerializeField] Animator animPlayer;
    Vector3 moveVector;
    Vector3 ant;

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(moveVector);

        if (ant != transform.transform.position) animPlayer.SetBool("isMoving", true);
        else animPlayer.SetBool("isMoving", false);
        ant = transform.transform.position;
    }

    public void OnMove(InputValue input)
    {
        Vector2 vec = input.Get<Vector2>();
        moveVector = new Vector3(vec.x, 0, vec.y) * moveSpeed * Time.deltaTime;

        boyModel.transform.rotation = Quaternion.LookRotation(moveVector);
        animPlayer.Play("Boy_Armature|Run");
        animPlayer.Play("Adult_Armature|Run");
    }




}

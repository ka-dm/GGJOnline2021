using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] float moveSpeed = 3F;
    Vector3 moveVector;
    Vector2 xd;

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(moveVector);
    }

    public void OnMove(InputValue input)
    {
        xd = input.Get<Vector2>();
        Vector2 vec = input.Get<Vector2>();
        moveVector = new Vector3(vec.x, 0, vec.y) * moveSpeed * Time.deltaTime;
        Debug.Log(xd);
    }




}

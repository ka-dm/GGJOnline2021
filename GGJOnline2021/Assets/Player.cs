using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] float moveSpeed = 5F;
    Vector3 moveVector;

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(moveVector);
    }

    public void OnMove(InputValue input)
    {
        
        Vector2 vec = input.Get<Vector2>();
        moveVector = new Vector3(vec.x, vec.y, 0) * moveSpeed * Time.deltaTime;
    }
    
}

using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private Vector2 moveDirection;
    public bool canMove = true;

    private float moveX = 0;
    private float moveY = 0;
    private float Speed;
    void Update()
    {
        processInputs();
        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", Speed);
    }

    void FixedUpdate()
    {     
        if(canMove){
         move();
        }
    }

    void processInputs()
    {

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        Speed = new Vector2(moveX, moveY).magnitude;

    }

    void move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void enableMovement(){
        canMove = true;
    }
    
    public void disableMovement(){
        canMove = false;
        rb.velocity = new Vector2(0,0);
    }

}

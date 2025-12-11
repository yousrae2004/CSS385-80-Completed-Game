using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 2.0f;
    private Rigidbody2D rb;
    private Vector2 input;
    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (input.sqrMagnitude > 0.01f)
        {
            animator.speed = 1;
            animator.SetFloat("Horizontal", input.x);
            animator.SetFloat("Vertical", input.y);
        }
        else
        {
            animator.speed = 0;
        }

        input.Normalize();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * speed;
    }
}

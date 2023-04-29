﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { Down, Up, Left, Right };

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    public float speed = 8f;
    State state = State.Down;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xSpeed = speed * xInput;
        float ySpeed = speed * yInput;

        Vector2 newVelocity = new Vector2(xSpeed, ySpeed);
        rigidbody.velocity = newVelocity;
        
        if (newVelocity.magnitude != 0)
        {
            state = NewState(newVelocity);
            animator.SetInteger("State", (int)state);
        }
    }

    public State NewState(Vector2 vector)
    {
        float degree = Mathf.Atan2(vector.x, vector.y) * Mathf.Rad2Deg;

        if (degree > 135)
        {
            return State.Down;
        }
        else if (degree > 45)
        {
            return State.Right;
        }
        else if (degree > -45)
        {
            return State.Up;
        }
        else if (degree > -135)
        {
            return State.Left;
        }
        else
        {
            return State.Down;
        }
    }


    public void Die()
    {
        gameObject.SetActive(false);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { Down, Up, Left, Right };

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private State state = State.Down;

    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKey(KeyCode.J) == true)
        {
            playerRigidbody.AddForce(new Vector2(0f, 100f));
        }
        */

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xSpeed = speed * xInput;
        float ySpeed = speed * yInput;

        Vector2 newVelocity = new Vector2(xSpeed, ySpeed);
        playerRigidbody.velocity = newVelocity;


        if (newVelocity.x > 0)
        {
            state = State.Right;
        }
        else if (newVelocity.x < 0)
        {
            state = State.Left;
        }
        else if (newVelocity.y > 0)
        {
            state = State.Up;
        }
        else state = State.Down;

        animator.SetInteger("State", (int)state);
        /*
        if (newVelocity.magnitude != 0)
        {
            state = NewState(newVelocity);
            animator.SetInteger("State", (int)state);
        }
        */

        /*  플레이어가 카메라 밖으로 나가지 않는 처리
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        */
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

        GameManager gamemanager = FindObjectOfType<GameManager>();
        gamemanager.Gameover();
    }

}

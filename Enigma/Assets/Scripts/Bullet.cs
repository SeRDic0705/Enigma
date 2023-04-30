using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8;
    private Rigidbody2D bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = transform.forward * speed;
        
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Die();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

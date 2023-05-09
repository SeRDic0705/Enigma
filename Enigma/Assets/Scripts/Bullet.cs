using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8;
    private Rigidbody2D bulletRigidbody;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<Player>().transform;
        Vector2 newVelocity = (target.positin - transform.position).normalized;
        bulletRigidbody.velocity = newVelocity * speed;

        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb = null;
    Collider2D collider;
    float distToGround = 0f;

    Vector2 motion;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        distToGround = collider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    bool IsGround()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    void Move()
    {
        motion.x = Input.GetAxis("Horizontal");

        rb.velocity = motion * 10;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGround())
        {
            motion.y = 100;
            rb.velocity = motion * 10;
        }
        else
        {

        }
    }
}

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
        Jump();
        Fall();
        Move();
    }

    bool IsGround()
    {
        return Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    void Move()
    {
        motion.x = Input.GetAxis("Horizontal");
        motion.x *= 5;

        rb.velocity = motion;
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && IsGround())
        {
            motion.y = 20;
            rb.velocity = motion * Time.deltaTime;
        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            if (motion.y > 0)
            {
                motion.y = 0;
            }

            rb.velocity = motion * Time.deltaTime;
        }
    }

    private void Fall()
    {
        if (IsGround() && motion.y < 0)
        {
            motion.y = 0;
        }
        else
        {
            motion.y -= 1f;
        }

        rb.velocity = motion * Time.deltaTime;
    }

}

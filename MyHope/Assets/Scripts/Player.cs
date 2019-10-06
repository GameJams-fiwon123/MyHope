﻿using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb = null;
    Collider2D collider = null;
    float distToGround = 0f;

    public int life = 3;
    public int attack = 0;
    public int attackSpeed = 0;

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
        Vector3 refPosition = transform.position;
        refPosition.x = transform.position.x + 0.51f;

        RaycastHit2D hitRight = Physics2D.Raycast(refPosition, -Vector3.up, distToGround + 0.1f);

        refPosition.x = transform.position.x;
        RaycastHit2D hitCenter = Physics2D.Raycast(refPosition, -Vector3.up, distToGround + 0.1f);

        refPosition.x = transform.position.x - 0.51f;
        RaycastHit2D hitLeft = Physics2D.Raycast(refPosition, -Vector3.up, distToGround + 0.1f);

        return hitRight || hitCenter  || hitLeft;
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
            motion.y = 15;
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
            motion.y -= 0.5f;
        }

        rb.velocity = motion * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Time.timeScale = 0.5f;

            life--;

            FindObjectOfType<StudioEventEmitter>().SetParameter("energia", life);

            Vector2 dir = collision.transform.position - transform.position;
            rb.AddForce(-dir.normalized * 10000);
            motion.y = 0;
            rb.velocity = motion;
            Invoke("ResetTimeScale", 0.3f);

            if (life <= 0)
            {
                FindObjectOfType<LevelManager>().Invoke("ResetLevel", 3f);
            }
        }
    }

    private void ResetTimeScale()
    {
        Time.timeScale = 1f;
    }

}
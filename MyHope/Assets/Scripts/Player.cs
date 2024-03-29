﻿using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb = null;
    Collider2D collider = null;
    SpriteRenderer sprRenderer;
    float distToGround = 0f;

    Animator anim;

    //[HideInInspector]
    public int maxHp = 3;
    public int hp = 3;

    //[HideInInspector]
    public int attack = 0;

    //[HideInInspector]
    public int attackSpeed = 0;

    Vector2 motion;

    float timeStep = 0f;
    float timeWaitStep = 0.25f;

    [HideInInspector]
    public bool isDead = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        distToGround = collider.bounds.extents.y;
        sprRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        maxHp = DataManager.instance.hp;
        hp = DataManager.instance.hp;
        attack = DataManager.instance.attack;
        attackSpeed = DataManager.instance.attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Fall();

        if (!isDead)
        {
            Jump();
            Move();
        }
    }

    bool IsGround()
    {
        Vector3 refPosition = transform.position;
        refPosition.x = transform.position.x + 0.51f;

        RaycastHit2D hitRight = Physics2D.Raycast(refPosition, -Vector3.up, distToGround + 0.2f);

        refPosition.x = transform.position.x;
        RaycastHit2D hitCenter = Physics2D.Raycast(refPosition, -Vector3.up, distToGround + 0.2f);

        refPosition.x = transform.position.x - 0.51f;
        RaycastHit2D hitLeft = Physics2D.Raycast(refPosition, -Vector3.up, distToGround + 0.2f);

        return hitRight || hitCenter  || hitLeft;
    }

    bool IsCeilling()
    {
        Vector3 refPosition = transform.position;
        refPosition.x = transform.position.x + 0.51f;

        RaycastHit2D hitRight = Physics2D.Raycast(refPosition, Vector3.up, distToGround);

        refPosition.x = transform.position.x;
        RaycastHit2D hitCenter = Physics2D.Raycast(refPosition, Vector3.up, distToGround);
       

        refPosition.x = transform.position.x - 0.51f;
        RaycastHit2D hitLeft = Physics2D.Raycast(refPosition, Vector3.up, distToGround);

        return hitRight || hitCenter || hitLeft;
    }

    void Move()
    {
        motion.x = Input.GetAxis("Horizontal");
        motion.x *= 5;

        timeStep += Time.deltaTime;

        if (motion.x > 0)
        {
            if (timeStep > timeWaitStep)
            {
                //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Passos", transform.position);
                timeStep = 0f;
            }
            sprRenderer.flipX = false;
            anim.SetInteger("AxisX", 1);
        }
        else if (motion.x < 0)
        {
            if (timeStep > timeWaitStep)
            {
                //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Passos", transform.position);
                timeStep = 0f;
            }

            sprRenderer.flipX = true;
            anim.SetInteger("AxisX", -1);
        }
        else
        {
            timeStep = timeWaitStep;
            anim.SetInteger("AxisX", 0);
        }

        rb.velocity = motion;
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && IsGround())
        {
            FMOD.Studio.EventInstance soundInstance = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Pulo");
            soundInstance.setVolume(0.5f);
            soundInstance.start();

            motion.y = 15;
            rb.velocity = motion * Time.deltaTime;
        }
        else if (!Input.GetKey(KeyCode.Space) || IsCeilling())
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
            if (!isDead)
            {
                Time.timeScale = 0.5f;

                hp--;

                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Dano Personagem", transform.position);

                FindObjectOfType<StudioEventEmitter>().SetParameter("energia", hp);

                FindObjectOfType<UI>().SetHp(hp, false);

                Vector2 dir = collision.transform.position - transform.position;
                rb.AddForce(-dir.normalized * 10000);
                motion.y = 0;
                rb.velocity = motion;
                Invoke("ResetTimeScale", 0.3f);

                if (hp <= 0)
                {
                    isDead = true;
                    FindObjectOfType<LevelManager>().Invoke("ResetLevel", 3f);
                }
            }
        }
    }

    private void ResetTimeScale()
    {
        Time.timeScale = 1f;
    }

}

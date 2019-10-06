using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMonster : MonoBehaviour
{
    Rigidbody2D rb = null;
    Collider2D collider = null;
    float distToGround = 0f;

    Vector2 motion;

    public GameObject player = null;

    enum State { IDLE, MOVE, ATTACK}
    State curState;

    float curTime = 0f;
    float idleTime = 0f;
    float moveTime = 0f;

    float curTimeTeleport = 0f;
    float teleportTime = 3f;

    float hp = 5f;

    bool isRight = true;

    public GameObject staff;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        distToGround = collider.bounds.extents.y;
        curState = State.IDLE;
        idleTime = Random.Range(0.5f, 1.5f);

        
    }

    // Update is called once per frame
    void Update()
    { 
        Fall();

        if (player)
        {
            curTimeTeleport = 0f;

            Move();
        }
        else
        {
            curTimeTeleport += Time.deltaTime;

            if (curTimeTeleport > teleportTime)
            {
                curTimeTeleport = 0f;
                //Teleport();
            }

            if (curState == State.IDLE)
            {
                // IDLE
                curTime += Time.deltaTime;
                if (curTime > idleTime)
                {
                    curTime = 0f;
                    curState = State.MOVE;
                    moveTime = Random.Range(0.5f, 1.5f);
                }

            }
            else if (curState == State.MOVE)
            {
                Move();
                curTime += Time.deltaTime;
                if (curTime > moveTime)
                {
                    curTime = 0f;
                    curState = State.IDLE;
                    isRight = !isRight;
                    idleTime = Random.Range(1f, 2f);
                }

            }
            else if (curState == State.ATTACK)
            {
                // TODO
            }
        }
    }

    private void Teleport()
    {
        int index = Random.RandomRange(0, 2);
        transform.position = FindObjectOfType<Player>().gameObject.transform.transform.GetChild(index).position;
    }

    bool IsGround()
    {
        Vector3 refPosition = transform.position;
        refPosition.x = transform.position.x + 0.51f;

        RaycastHit2D hitRight = Physics2D.Raycast(refPosition, -Vector3.up, distToGround + 0.1f);

        refPosition.x = transform.position.x - 0.51f;
        RaycastHit2D hitLeft = Physics2D.Raycast(refPosition, -Vector3.up, distToGround + 0.1f);

        return hitRight || hitLeft;
    }

    void Move()
    {
        if (player)
        {
            motion.x = player.transform.position.x - transform.position.x;

            rb.velocity = motion;
        }
        else
        {
            if (isRight)
            {
                motion.x = 3;

                rb.velocity = motion;
            }
            else
            {
                motion.x = -3;

                rb.velocity = motion;
            }
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
            motion.y -= 20f;
        }

        rb.velocity = motion * Time.deltaTime;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Attack")
        {
            hp -= FindObjectOfType<Player>().attack;

            if (hp <= 0)
            {
                if (staff != null)
                {
                    staff.GetComponent<Staff>().MonsterDied();
                }
                Destroy(gameObject);
            }
        }
    }
}

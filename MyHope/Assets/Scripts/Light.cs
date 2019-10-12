using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    private void Start()
    {
        if (transform.parent != null)
        {
            if (transform.parent.tag == "Player")
            {
                FindObjectOfType<UI>().SetVisibleAtks(true);
                FindObjectOfType<UI>().SetVisibleAtkSpeeds(true);

                SetAttackSpeed(DataManager.instance.attackSpeed);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null)
        {
            if (transform.parent.tag == "Player")
            {
                mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                mousePosition = transform.parent.transform.InverseTransformPoint(mousePosition);
                mousePosition.z = 0;
                Vector3 clampMouse = Vector3.zero;
                clampMouse.x = Mathf.Clamp(mousePosition.x, -1.2f, 1.2f);
                clampMouse.y = Mathf.Clamp(mousePosition.y, -1.2f, 1.2f);

                Vector2 relativePos = mousePosition - transform.localPosition;
                relativePos.y = -relativePos.y;
                float angle = Vector2.SignedAngle(Vector2.right , relativePos.normalized);

                transform.GetChild(2).eulerAngles = new Vector3(angle, 90f, 0);
                transform.localPosition = Vector2.Lerp(transform.localPosition, clampMouse, moveSpeed);


                if (Input.GetMouseButton(0) && !transform.parent.GetComponent<Player>().isDead)
                {
                    if (!transform.GetChild(2).GetComponent<ParticleSystem>().isPlaying)
                    {
                        //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Golpe de luz", transform.position);
                        transform.GetChild(2).GetComponent<ParticleSystem>().Play();
                    }
                }
            }
        }
    }

    public void SetAttackSpeed(float value)
    {
        transform.GetChild(2).GetComponent<ParticleSystem>().emissionRate = 1 + value * 0.2f - 0.2f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (transform.parent != collision.transform)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Amigo Luz", transform.position);
                FindObjectOfType<UI>().SetVisibleAtks(true);
                FindObjectOfType<UI>().SetVisibleAtkSpeeds(true);
                FindObjectOfType<Player>().attack = 1;
                FindObjectOfType<Player>().attackSpeed = 1;
                transform.SetParent(collision.transform);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

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
                mousePosition.x = Mathf.Clamp(mousePosition.x, -1f, 1f);
                mousePosition.y = Mathf.Clamp(mousePosition.y, -1, 1f);

                Vector3 relativePos = transform.position - transform.parent.position;

                // the second argument, upwards, defaults to Vector3.up
                Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                transform.GetChild(2).rotation = rotation;
                transform.localPosition = Vector2.Lerp(transform.localPosition, mousePosition, moveSpeed);


                if (Input.GetMouseButton(0))
                {
                    if (!transform.GetChild(2).GetComponent<ParticleSystem>().isPlaying)
                        transform.GetChild(2).GetComponent<ParticleSystem>().Play();
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (transform.parent != collision.transform)
            {
                FindObjectOfType<UI>().SetVisibleAtks(true);
                FindObjectOfType<UI>().SetVisibleAtkSpeeds(true);
                FindObjectOfType<Player>().attack = 1;
                FindObjectOfType<Player>().attackSpeed = 1;
                transform.SetParent(collision.transform);
            }
        }
    }
}

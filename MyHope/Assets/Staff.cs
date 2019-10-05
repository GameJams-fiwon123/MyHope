using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    float hp = 100;


    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Attack")
        {
            hp -= 10;

            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

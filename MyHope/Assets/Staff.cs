using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    float hp = 100;

    [SerializeField]
    Transform positions;

    [SerializeField]
    GameObject prefabMonster;

    private void Start()
    {
        if (positions.childCount > 0)
        {
            StartCoroutine(GenerateEnemies());
        }
    }

    IEnumerator GenerateEnemies()
    {
        while (true)
        {
            int index = Random.Range(0, positions.childCount);

            Instantiate(prefabMonster, positions.GetChild(index).position, Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
    }

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

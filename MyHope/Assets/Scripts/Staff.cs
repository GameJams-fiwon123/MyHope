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

    int maxSpawn = 3;
    int countSpawn = 0;

    private void Start()
    {
        if (positions.childCount > 0)
        {
            StartCoroutine(GenerateEnemies());
        }
    }

    IEnumerator GenerateEnemies()
    {
        while (true) {
            if (countSpawn < 3)
            {
                int index = Random.Range(0, positions.childCount);

                countSpawn++;
                GameObject g = Instantiate(prefabMonster, positions.GetChild(index).position, Quaternion.identity, FindObjectOfType<GameManager>().monsters);
                g.GetComponent<BlueMonster>().staff = gameObject;

                yield return new WaitForSeconds(5);
            }
        }
    }

    public void MonsterDied()
    {
        countSpawn--;
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

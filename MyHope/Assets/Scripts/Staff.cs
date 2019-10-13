using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    float hp = 6;

    [SerializeField]
    Transform positions;

    [SerializeField]
    GameObject prefabMonster;

    int maxSpawn = 3;
    int countSpawn = 0;


    Coroutine coroutine;

    private void Start()
    {
        if (positions.childCount > 0)
        {
            coroutine = StartCoroutine(GenerateEnemies());
        }
    }

    IEnumerator GenerateEnemies()
    {
        while (countSpawn < maxSpawn)
        {
            int index = Random.Range(0, positions.childCount);

            countSpawn++;
            GameObject g = Instantiate(prefabMonster, positions.GetChild(index).position, Quaternion.identity, FindObjectOfType<GameManager>().monsters);
            g.GetComponent<BlueMonster>().staff = gameObject;

            yield return new WaitForSeconds(5);
        }

        coroutine = null;
    }

    private void Update()
    {
        if (countSpawn < maxSpawn)
        {
            if (coroutine == null)
                coroutine = StartCoroutine(GenerateEnemies());
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
            hp -= FindObjectOfType<Player>().attack;
            FMOD.Studio.EventInstance soundInstance = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/acertar cajado");
            soundInstance.setVolume(0.4f);
            soundInstance.start();

            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

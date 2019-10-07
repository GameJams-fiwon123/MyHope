using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform staffs, monsters;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        FindObjectOfType<UI>().Reset(DataManager.instance.hp, DataManager.instance.attack, DataManager.instance.attackSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (staffs != null && monsters != null)
        {
            if (staffs.childCount == 0)
            { 
                FindObjectOfType<DataManager>().hp = FindObjectOfType<Player>().maxHp;
                FindObjectOfType<DataManager>().attack = FindObjectOfType<Player>().attack;
                FindObjectOfType<DataManager>().attackSpeed = FindObjectOfType<Player>().attackSpeed;
                FindObjectOfType<LevelManager>().LoadNexLevel();
            }
        }
    }

    public void StartGame()
    {
        staffs.gameObject.SetActive(true);
        monsters.gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public enum types { HP, Attack, AttackSpeed };

    public void ChooseUpgrade(types index)
    {
        switch (index)
        {
            case types.HP:
                FindObjectOfType<UI>().SetHp(FindObjectOfType<Player>().hp, true);
                FindObjectOfType<Player>().maxHp += 1;
                FindObjectOfType<Player>().hp += 1;
                break;
            case types.Attack:
                FindObjectOfType<UI>().SetAttack(FindObjectOfType<Player>().attack, true);
                FindObjectOfType<Player>().attack += 1;
                break;
            case types.AttackSpeed:
                FindObjectOfType<UI>().SetAttackSpeed(FindObjectOfType<Player>().attackSpeed, true);
                FindObjectOfType<Player>().attackSpeed += 1;
                FindObjectOfType<Light>().SetAttackSpeed(FindObjectOfType<Player>().attackSpeed);
                break;


        }

        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        FindObjectOfType<GameManager>().StartGame();
    }
}

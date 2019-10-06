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
                FindObjectOfType<Player>().hp += 1;
                FindObjectOfType<DataManager>().hp = FindObjectOfType<Player>().hp;
                break;
            case types.Attack:
                FindObjectOfType<UI>().SetAttack(FindObjectOfType<Player>().attack, true);
                FindObjectOfType<Player>().attack += 1;
                FindObjectOfType<DataManager>().attack = FindObjectOfType<Player>().attack;
                break;
            case types.AttackSpeed:
                FindObjectOfType<UI>().SetAttackSpeed(FindObjectOfType<Player>().attackSpeed, true);
                FindObjectOfType<Player>().attackSpeed += 1;
                FindObjectOfType<DataManager>().attackSpeed += FindObjectOfType<Player>().attackSpeed;
                break;
        }

        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
    }
}

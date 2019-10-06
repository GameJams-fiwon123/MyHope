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
                FindObjectOfType<Player>().life += 1;
                break;
            case types.Attack:
                FindObjectOfType<Player>().attack += 1;
                break;
            case types.AttackSpeed:
                FindObjectOfType<Player>().attackSpeed += 1;
                break;
        }

        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
    }
}

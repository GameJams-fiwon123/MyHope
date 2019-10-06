using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    public GameObject hps, atks, atkSpeeds;

    private void Start()
    {
        if (FindObjectsOfType<UI>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetVisibleHps(bool flag)
    {
        hps.SetActive(flag);
    }

    public void SetVisibleAtks(bool flag)
    {
        atks.SetActive(flag);
    }

    public void SetVisibleAtkSpeeds(bool flag)
    {
        atkSpeeds.SetActive(flag);
    }

    public void SetHp(int index, bool flag)
    {
        transform.GetChild(0).transform.GetChild(index).gameObject.SetActive(flag);
    }

    public void SetAttack(int index, bool flag)
    {
        transform.GetChild(1).transform.GetChild(index).gameObject.SetActive(flag);
    }

    public void SetAttackSpeed(int index, bool flag)
    {
        transform.GetChild(2).transform.GetChild(index).gameObject.SetActive(flag);
    }

}

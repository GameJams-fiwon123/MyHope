using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    public GameObject hps, atks, atkSpeeds;

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

    public void SetLive(int index)
    {
        transform.GetChild(index).gameObject.SetActive(true);
    }

    public void SetAttack(int index)
    {
        transform.GetChild(index).gameObject.SetActive(true);
    }

    public void SetAttackSpeed(int index)
    {
        transform.GetChild(index).gameObject.SetActive(true);
    }

}

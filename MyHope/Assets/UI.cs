using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
   //[HideInInspector]
    public int hp = 3;

   //[HideInInspector]
    public int attack = 0;

   //[HideInInspector]
    public int attackSpeed = 0;

    public static DataManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (FindObjectsOfType<DataManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
}

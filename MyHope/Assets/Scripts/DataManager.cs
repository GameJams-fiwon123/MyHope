using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int hp = 3;
    public int attack = 0;
    public int attackSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectsOfType<DataManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform sttafs, monsters;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sttafs.childCount == 0 && monsters.childCount == 0)
        {
            sttafs = null;
            monsters = null;
            FindObjectOfType<LevelManager>().LoadNexLevel();
        }
    }
}

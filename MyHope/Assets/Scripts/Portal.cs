using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0.3f;
        Invoke("LoadNextLevel", 0.5f);
    }

    private void LoadNextLevel()
    {
        FindObjectOfType<LevelManager>().LoadNexLevel();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadStory()
    {
       
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {

    }

    public void LoadLevel3()
    {

    }

    public void LoadNexLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Botão", transform.position);
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadCredits()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Botão", transform.position);
        SceneManager.LoadScene("Credits");
    }

    public void LoadFinal()
    {

    }

    public void ExitGame()
    {
        #if UNITY_WEBGL
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Botão", transform.position);
                Application.Quit();
        #endif
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

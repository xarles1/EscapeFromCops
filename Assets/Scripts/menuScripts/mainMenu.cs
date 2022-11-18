using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void Start(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void soundVolume(float Volume)
    {
        PlayerPrefs.SetFloat("Volume", Volume);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backsound : MonoBehaviour
{
    private void Start()
    {
        if (GameObject.Find("BacksoundOn") == null)
        {
            DontDestroyOnLoad(gameObject);
            GetComponent<AudioSource>().Play();

            gameObject.name = "BacksoundOn";

            PlayerPrefs.SetFloat("Volume", 1);

            Debug.Log("Music on");
        }
    }

    private void Update()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
    }
}
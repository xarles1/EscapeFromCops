using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoreManager : MonoBehaviour
{
    public static int scoreValue = 0;
    Text score;

    private void Start()
    {
        score = GetComponent<Text>();
    }

    private void Update()
    {
        score.text = "$" + scoreValue;
    }
}
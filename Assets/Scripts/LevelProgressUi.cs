using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelProgressUi : MonoBehaviour
{
    [Header("UI References: ")]
    [SerializeField] private Image uiFillImage;

    [Header("Player & Endline references: ")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform finishLineTransform;

    private Vector3 finishLinePosition;
    private float fullDistance;

    private void Start()
    {
        finishLinePosition = finishLineTransform.position;
        fullDistance = GetDistance();
    }


            // 1 VE 2 LEVEL TEXTI (KULLANMADIM)
    //public void SetLevelText (int level)
    //{
    //    uiStartText.text = level.ToString();
    //    uiFinishText.text = (level + 1).ToString();
    //}

    private float GetDistance()
    {
        //return Vector3.Distance(playerTransform.position, finishLinePosition);

        return (finishLinePosition - playerTransform.position).sqrMagnitude;
    }

    private void UpdateProgressFill(float value)
    {
        uiFillImage.fillAmount = value;
    }

    private void Update()
    {
        float newDistance = GetDistance();
        float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);

        UpdateProgressFill(progressValue);
    }
}
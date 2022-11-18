using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackManager : MonoBehaviour
{
    public static stackManager instance;

    [SerializeField] private float distanceObjects;
    [SerializeField] private Transform prevObject;
    [SerializeField] private Transform parent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        distanceObjects = prevObject.localScale.y;
    }

    public void PickUp(GameObject pickedObject, bool needTag = true, string tag = "Pick", bool downOrUp = true)
    {
        if (needTag)
        {
            pickedObject.tag = tag;
        }
        pickedObject.transform.parent = parent;
        Vector3 desPos = prevObject.localPosition;
        desPos.y += downOrUp ? distanceObjects : -distanceObjects;
        desPos.z += pickedObject.transform.localScale.z;

        pickedObject.transform.localPosition = desPos;
        prevObject = pickedObject.transform;
    }
}
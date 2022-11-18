using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stackTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pick")
        {
            stackManager.instance.PickUp(other.gameObject, true, "Pick");
        }
    }
}
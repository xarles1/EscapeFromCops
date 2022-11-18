using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleObject : MonoBehaviour
{
    public ParticleSystem clickParticle;

    //TIKLAMA GUCU
    public float force = 10;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(clickParticle, transform.position,Quaternion.identity);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform != null)
                {
                    Rigidbody rig;

                    if (rig = hit.transform.GetComponent<Rigidbody>())
                    {
                        //PrintName(hit.transform.gameObject);
                        collectControl(rig);
                    }
                }
            }
        }
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }

    private void collectControl(Rigidbody rB)
    {
        rB.AddForce(rB.transform.up * force, ForceMode.Impulse);


        scoreManager.scoreValue += 10;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyManager : MonoBehaviour
{
    [Header("Unity Setup")]
    public ParticleSystem deathParticles;

    public GameObject Player;
    public float Distance;

    public bool isAngry;

    public NavMeshAgent enemy;

    private void Update()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);

        if (Distance <= 5)
        {
            isAngry = true;
        }
        if (Distance > 5f)
        {
            isAngry = false;
        }

        if (isAngry)
        {
            enemy.isStopped = false;

            enemy.SetDestination(Player.transform.position);
        }
        if (!isAngry)
        {
            enemy.isStopped = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BAM"))
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowManager : MonoBehaviour
{
    NavMeshAgent agent;

    public Transform target;

    public GameManager gameManager;

            //PLAYER DEATH PARTICLE EFFECT
    [Header("Particle")]
    public ParticleSystem playerDeathParticle;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.destination = target.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            DestroyedPlayer();
            GameManager.isGameOver = true;
            gameObject.SetActive(false);
        }
    }

    private void DestroyedPlayer()
    {
        Destroy(gameObject);

                //PLAYER DEATH PARTICLE EFFECT 
        Instantiate(playerDeathParticle, transform.position, Quaternion.identity);
    }
}
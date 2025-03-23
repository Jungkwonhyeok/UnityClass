using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private float detectionRange = 20f;
    private float attackRange = 2f;
    private float attackCooldown = 1f;
    private float lastAttackTime = 0f;
   
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        float distancePlayer =
            Vector3.Distance(player.position, transform.position);

        if (distancePlayer < detectionRange)
        {
            agent.SetDestination(player.position);

            if (distancePlayer <= attackRange && Time.time - lastAttackTime >= attackCooldown)
            {
                AttackPlayer();
            }
        }
    }

     private void AttackPlayer()
    {
        lastAttackTime = Time.time;

        Hp playerHp = player.GetComponent<Hp>();
        if (playerHp != null)
        {
            playerHp.Damage(5);
            Debug.Log("Enemy attacked the player!");
        }
    }
}
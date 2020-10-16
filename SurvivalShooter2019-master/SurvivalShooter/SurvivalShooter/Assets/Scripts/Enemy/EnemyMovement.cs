using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    Transform player2;
    PlayerHealth playerHealth;
    PlayerHealth2 playerHealth2;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;

    void Awake ()
    { 
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        player2 = GameObject.FindGameObjectWithTag("Player2").transform;
        playerHealth = player.GetComponent<PlayerHealth> ();
        playerHealth2 = player2.GetComponent<PlayerHealth2>();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }

    void Update ()
    {
        float pos;
        float pos2;
        Vector3 closest = Vector3.zero;

        pos = Vector3.Distance(player.position, transform.position);
        pos2 = Vector3.Distance(player2.position, transform.position);

        if (pos < pos2)
        {
            closest = player.position;
        }
        else
        {
            closest = player2.position;
        }

        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 || playerHealth2.currentHealth > 0)
        {
            nav.SetDestination(closest);
        }

        if(playerHealth.currentHealth == 0 && playerHealth2.currentHealth == 0)
        {
            nav.enabled = false;
        }
    }
}

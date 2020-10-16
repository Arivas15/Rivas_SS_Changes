using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    GameObject player2;
    PlayerHealth playerHealth;
    PlayerHealth2 playerHealth2;
    EnemyHealth enemyHealth;
    bool playerInRange;
    bool playerInRange2;
    float timer;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        playerHealth = player.GetComponent<PlayerHealth> ();
        playerHealth2 = player2.GetComponent<PlayerHealth2>();
        enemyHealth = GetComponent<EnemyHealth>();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
        if(other.gameObject == player2)
        {
            playerInRange2 = true;
        }
    }
    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
        if (other.gameObject == player2)
        {
            playerInRange2 = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }
        if (timer >= timeBetweenAttacks && playerInRange2 && enemyHealth.currentHealth > 0)
        {
            Attack2();
        }
    }

    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
            if (playerHealth.currentHealth <= 0)
            {
                player.GetComponent<Animator>().SetTrigger("PlayerDead");
            }
        }
    }
    void Attack2()
    {
        timer = 0f;

        if (playerHealth2.currentHealth > 0)
        {
            playerHealth2.TakeDamage(attackDamage);
            if (playerHealth2.currentHealth <= 0)
            {
                player2.GetComponent<Animator>().SetTrigger("PlayerDead");
            }
        }

    }
}

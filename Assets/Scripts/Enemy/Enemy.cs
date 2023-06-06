using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private string currentState = "Idle";
    private Transform target;
    
    public float chaseRange = 6;
    public Animator animator;
    public float speed = 6;
    public float attackRange = 2;
    public int HP;
    public int maxHP;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        HP = maxHP;
    }


    void Update() 
    {
        if(PlayerManager.gameOver)
        {
            //currentState = "Dance";
            //animator.SetTrigger("isPlayerDead");        
            animator.enabled = false;
            this.enabled = false;
        }

        float distance = Vector3.Distance(transform.position, target.position); 

        if(currentState == "Idle")
        {
            if(distance < chaseRange)
            {
                currentState = "Chase";
            }
        }

        else if(currentState == "Chase")
        {
            animator.SetTrigger("chase");
            animator.SetBool("isAttacking", false);

            if(distance < attackRange)
            {
                currentState = "Attack";
            }

            if (target.position.x > transform.position.x) //idi prema desno
            {     
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            else //lijevo
            {
                transform.Translate(transform.right * -1 * speed * Time.deltaTime); //-transform.right je isto sto i transform.left
                transform.rotation = Quaternion.identity;
            }
        }

        else if(currentState == "Attack")
        {
            animator.SetBool("isAttacking", true);

            if (distance > attackRange)
            {
                currentState = "Chase";
            }
        }
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        currentState = "Chase";

        if(HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("isDead");

        GetComponent<CapsuleCollider>().enabled = false;
        this.enabled = false;
    }
}

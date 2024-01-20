using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement_0 : MonoBehaviour
{
     private GameObject player;
     private float walkSpeed;
    private Vector2 difference;
    private bool isAttacking;
    private bool isDead;
    void Start()
    {
        walkSpeed = GetComponent<enemyStats>().getWalkSpeed();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isDead) catchPlayer();
        
    }
    
 public void catchPlayer()
    {
        if (transform.position != player.transform.position && !isAttacking)
        {
            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, walkSpeed * Time.deltaTime);

            // Look at the player
            Vector2 lookDir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    public void startAttack()
    {
        isAttacking = true;
    }

    public void stopAttack()
    {
        isAttacking = false;
    }

    public void enemyIsDead()
    {
        isDead = true;
    }
    
}

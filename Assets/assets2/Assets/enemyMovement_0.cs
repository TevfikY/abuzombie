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
        //if(!isDead)
        catchPlayer();
        
    }
    
    public void catchPlayer()
    {
        
        if (transform.position != player.transform.position && !isAttacking )
        {
            
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, walkSpeed*Time.deltaTime);
            difference = player.transform.position - transform.position;
            difference.Normalize();
            
            float rotationZ = MathF.Atan2(difference.y, difference.x) * Mathf.Rad2Deg +180 ;
            
            transform.rotation = Quaternion.Euler(0f,0f,rotationZ) ;
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

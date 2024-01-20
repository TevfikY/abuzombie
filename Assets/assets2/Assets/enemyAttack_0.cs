using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack_0 : MonoBehaviour
{
    private float AttackTime;
    [SerializeField] float timeBetweenAttacks;
    private bool isFirstAttack;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("collision");
            if (!isFirstAttack)
            {
                AttackTime = Time.time;
                collision.gameObject.GetComponent<playerStats>().getHit(GetComponent<enemyStats>().getDmg());
                GetComponent<enemyMovement_0>().startAttack();
                isFirstAttack = true;
            }
            
            if (Time.time > AttackTime + timeBetweenAttacks)
            {
                
                collision.gameObject.GetComponent<playerStats>().getHit(GetComponent<enemyStats>().getDmg());
                AttackTime = Time.time;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        GetComponent<enemyMovement_0>().stopAttack();
        isFirstAttack = false;
    }
}

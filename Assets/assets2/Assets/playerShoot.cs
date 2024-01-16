using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    
    public ParticleSystem muzzleFlash;
    private Vector2 direction;
    public Transform target;
    [SerializeField] private float range = 10;
    private bool isAiming = false;
    private float resetTimer;
    [SerializeField] private float attackSPeed = 3f;
    private float bulletCount = 0;
    float timeReseter;
    [SerializeField] float timeBetweenShots = 1f;
    [SerializeField] float bulletPerSecond = 0.3f;
    private float bulletPerSecondReseter;
    [SerializeField] private float bulletDamage = 3;
    private List<GameObject> enemies = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
      
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            enemies.Add(col.gameObject);
        }
    }


    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            isAiming = true;
            GameObject Target = col.gameObject;
            if (enemies.Count > 0)
            {
               
                Target = GetClosestEnemy(enemies);
               
            }
            
            Vector2 difference = Target.gameObject.transform.position - transform.position;
            difference.Normalize();
            float rotationZ = MathF.Atan2(difference.y, difference.x) * Mathf.Rad2Deg +10 ;
            
            transform.rotation = Quaternion.Euler(0f,0f,rotationZ) ;
            Shoot(Target);
            
        }

    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        isAiming = false;
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
        }
    }

    public bool isShooting()
    {
        return isAiming;
    }
    
    public void Shoot(GameObject enemy)
    {
        
       
        
        
        if (bulletCount < 5)
        {
            if (Time.time > timeReseter)
            {
                if (Time.time > bulletPerSecondReseter)
                {
                    muzzleFlash.Emit(30);
                    bulletPerSecondReseter = Time.time + bulletPerSecond;
                    bulletCount++;
                    enemy.GetComponent<enemyStats>().getHit(bulletDamage);
                    
                }
            }
            
        }
        else
        {
            
            timeReseter = Time.time + timeBetweenShots;
            bulletCount = 0;
        }
    }
    GameObject GetClosestEnemy(List<GameObject> enemies)
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        if (enemies.Count != 0)
        {
            foreach (GameObject t in enemies)
            {
                float dist = Vector3.Distance(t.gameObject.transform.position, currentPos);
                if (dist < minDist)
                {
                    tMin = t;
                    minDist = dist;
                }
            }  
        }
        
        return tMin;
    }
}

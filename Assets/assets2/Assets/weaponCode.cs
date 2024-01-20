using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponCode : MonoBehaviour
{
    private GameObject Player;
    [SerializeField] weaponConfigCreator weaponStats;
     private float bulletsInMag;
     private float Damage;
     private float timeBetweenShots;
     float reloadTime;
     public ParticleSystem muzzleFlash;
     private Vector2 direction;
     
     
     [SerializeField] private float range = 10;
     private bool isAiming = false;
     private float resetTimer;
     [SerializeField] private float attackSPeed = 3f;
     private float bulletCount = 0;
     float timeReseter;
     
     [SerializeField] float bulletPerSecond = 0.3f;
     private float bulletPerSecondReseter;
     
     private List<GameObject> enemies = new List<GameObject>();
    void Start()
    {
        bulletsInMag = weaponStats.getBulletsInMag();
        Damage = weaponStats.getDamage();
        timeBetweenShots = weaponStats.getTimeBetweenShots();
        reloadTime = weaponStats.getReloadTime();
        Player = GameObject.FindWithTag("Player");
        
        string ammoString = bulletsInMag-bulletCount + "/" +  bulletsInMag;
        GameObject.FindWithTag("GameManager").GetComponent<gameManager>().setAmmo(ammoString);
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
            Player.GetComponent<joystickMovement>().checkIsShooting(isShooting());
            isAiming = true;
            GameObject Target = col.gameObject;
            if (enemies.Count > 0)
            {
                
                Target = GetClosestEnemy(enemies);
               
            }
            
            Vector2 difference = Target.gameObject.transform.position - transform.position;
            difference.Normalize();
            float rotationZ = MathF.Atan2(difference.y, difference.x) * Mathf.Rad2Deg +10 ;
            
            Player.transform.rotation = Quaternion.Euler(0f,0f,rotationZ) ;
            Shoot(Target);
            
        }

    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        isAiming = false;
        
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Remove(other.gameObject);
            Player.GetComponent<joystickMovement>().checkIsShooting(isShooting());
        }
    }

    public bool isShooting()
    {
        return isAiming;
    }
    
    public void Shoot(GameObject enemy)
    {
        
       string ammoString = bulletsInMag-bulletCount + "/" +  bulletsInMag;
        GameObject.FindWithTag("GameManager").GetComponent<gameManager>().setAmmo(ammoString);
        
        if (bulletCount < bulletsInMag)
        {
            if (Time.time > timeReseter)
            {
                if (Time.time > bulletPerSecondReseter)
                {
                    GameObject.FindWithTag("Player").GetComponent<AudioSource>().Play();
                    muzzleFlash.Emit(30);
                    
                    bulletPerSecondReseter = Time.time + timeBetweenShots;
                    bulletCount++;
                    enemy.GetComponent<enemyStats>().getHit(Damage);
                    Debug.Log("damaga given = "+ Damage);
                    
                    
                }
            }
            
        }
        else
        {
            
            timeReseter = Time.time + reloadTime;
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

    public float getAmmo()
    {
        
        //String ammo = bulletsInMag-bulletCount + "/" + bulletsInMag ;
        
        return bulletCount;
    }
}

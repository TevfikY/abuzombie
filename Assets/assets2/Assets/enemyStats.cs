using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    //[SerializeField] private GameObject player;
    private float hp;
    private float dmg;
    private float exp;
    [SerializeField] private float walkSpeed;
    [SerializeField] private EnemyConfigCreatorCode enemyConfig;
    private float deathTime;
    private float gold;
    private GameObject gameManager;
    private bool isDead = false;
    void Awake()
    {
        hp = enemyConfig.getHP();
        dmg = enemyConfig.getDamage();
        exp = enemyConfig.getEXP();
        //walkSpeed = enemyConfig.getWalkSpeed();
        gold = enemyConfig.getGold();
        gameManager = GameObject.FindWithTag("GameManager");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getHit(float dmg)
    {
        if(hp>0) particle.Play();
       
        //particle.Emit(30);
        hp -= dmg;
        Debug.Log(hp);
        if (hp <= 0)
        {
            isDead = true;
            Debug.Log("zombie dead");
            gameManager.GetComponent<gameManager>().addGold(gold);
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            GetComponent<enemyMovement_0>().enemyIsDead();
            Destroy(GetComponent<BoxCollider2D>());
            deathTime = Time.time;
            GetComponent<SpriteRenderer>().sprite = enemyConfig.getSprite();
            Invoke(nameof(destroyEnemy),3);
        }

    }


    public bool getIsDead()
    {
        return isDead;
    }
    public float getWalkSpeed()
    {
        return walkSpeed;
    }

    public float getDmg()
    {
        return dmg;
    }

    public void destroyEnemy()
    {
        Destroy(gameObject);
    }

    public void stopTime()
    {
        Debug.Log("worksZZZ");
        
    }
}

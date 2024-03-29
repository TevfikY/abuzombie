using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "enemy config",menuName = "new enemy config") ]
public class EnemyConfigCreatorCode : ScriptableObject
{
    [SerializeField] private float enemyHP;
    [SerializeField] private float enemyDamage;
    [SerializeField] private Sprite deathAnimation;
    [SerializeField] private float enemyEXP;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float gold;
    [SerializeField] private float angle;

    public float getHP()
    {
        return enemyHP;
    }

    public float getDamage()
    {
        return enemyDamage;
    }

    public Sprite getSprite()
    {
        return deathAnimation;
    }

    public float getEXP()
    {
        return enemyEXP;
    }

    public void increaseHP()
    {
        enemyHP += 6;
    }

    public void increaseDMG()
    {
        enemyDamage += 1;
    }

    public float getWalkSpeed()
    {
        return walkSpeed;
    }

    public float getGold()
    {
        return gold;
    }

    public float getAngle()
    {
        return angle;
    }
    
}

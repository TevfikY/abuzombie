using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon config",menuName = "new weapon config") ]
public class weaponConfigCreator : ScriptableObject
{
    [SerializeField] private float bulletsInMag;
    [SerializeField] private float Damage;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] float reloadTime;
   

   

    public float getDamage()
    {
        return Damage;
    }
    public float getBulletsInMag()
    {
        return bulletsInMag;
    }
    public float getTimeBetweenShots()
    {
        return timeBetweenShots;
    }
    public float getReloadTime()
    {
        return reloadTime;
    }
    
    
}
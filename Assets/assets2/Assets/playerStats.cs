using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    [SerializeField] private float Hp;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getHit(float dmg)
    {
        Hp -= dmg;
        Debug.Log(Hp);
    }
}

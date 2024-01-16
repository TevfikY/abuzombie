using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPosition : MonoBehaviour
{
    private Transform playerHandPos;
    void Start()
    {
        playerHandPos = GameObject.FindGameObjectWithTag("Player").transform;
        transform.SetParent(playerHandPos);
            
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerHandPos.position;
    }
}

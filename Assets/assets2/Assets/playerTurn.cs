using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTurn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetFloat("is");
    }

    // Update is called once per frame
    void Update()
    {
        faceDirection2();
        
    }
    
    /*void faceDirection()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x-transform.position.x,mousePosition.y-transform.position.y);
        transform.up = direction ;


    }*/

    void faceDirection2()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = MathF.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotationZ+7);
    }
}

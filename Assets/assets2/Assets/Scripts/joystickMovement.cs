using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class joystickMovement : MonoBehaviour
{
   
    public FloatingJoystick joystick;
    private Rigidbody2D rb;
    public float moveSpeed;
    private static bool isShooting = false;
    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        Vector2 move = new Vector2(joystick.Horizontal, joystick.Vertical);

        // Move the character
        rb.velocity = new Vector2(move.x * moveSpeed, move.y * moveSpeed);

        // Update rotation based on joystick input
        if (move != Vector2.zero && !isShooting)
        {
            float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
   
   // public FloatingJoystick joystick;
   // private Rigidbody2D rb;
   // private Vector2 move;
   // public float moveSpeed;
   // private static bool isShooting = false;
   //
   // private void Start()
   // {
   //    
   //    rb = GetComponent<Rigidbody2D>();
   // }
   //
   // private void Update()
   // {
   //    move.x = joystick.Horizontal;
   //    move.y = joystick.Vertical;
   //
   //    float hAxis = move.x;
   //    float vAxis = move.y;
   //    float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
   //    
   //    
   //    transform.eulerAngles = new Vector3(0f, 0f, -zAxis + 80);
   //    //hAxis != 0 &&
   //    /*if ( !isShooting)
   //    {
   //       transform.eulerAngles = new Vector3(0f, 0f, -zAxis + 80);
   //       
   //    }*/
   //    
   // }

   private void FixedUpdate()
   {
      /*rb.MovePosition(rb.position+move * moveSpeed * Time.deltaTime);*/
   }

   public void checkIsShooting(bool isAim)
   {
      if (!isAim) isShooting = false;
      else
      {
         isShooting = true;
      }
   }
}

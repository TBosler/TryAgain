﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float runspeed = 40f;
    public float screenTop = 0f;
    public float screenBot = 0f;
    public GameObject levelEdges;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    
    private void Update()
    {
       horizontalMove   = Input.GetAxisRaw("Horizontal") * runspeed;
       verticalMove     = Input.GetAxisRaw("Vertical") * runspeed;
    }

    private void FixedUpdate()
    {
        Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
    }
    
    // Update is called once per frame
    public void Move(float horz, float vert)
    {

        float newX = transform.position.x + horz;
        float newY = transform.position.y + vert;

        newY = Mathf.Clamp(newY, screenBot, screenTop);

        transform.position = new Vector3(newX, newY, 0);

        // If the input is moving the player right and the player is facing left...
        if (horz > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horz < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

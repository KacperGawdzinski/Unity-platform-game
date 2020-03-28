using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity=new Vector2(-5,rb.velocity.y);
        }
        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity=new Vector2(5,rb.velocity.y);
        }
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            rb.velocity=new Vector2(rb.velocity.x,5);
        }
    }
}

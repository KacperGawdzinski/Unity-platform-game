using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    void Start()
    {
        rb.freezeRotation=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-5,rb.velocity.y);
            transform.localScale=new Vector2(-1,1);
            anim.SetBool("run",true);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(5,rb.velocity.y);
            transform.localScale=new Vector2(1,1);
            anim.SetBool("run",true);
        }
        else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x,5);
        }
        else
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
            anim.SetBool("run",false);
        }
    }
}

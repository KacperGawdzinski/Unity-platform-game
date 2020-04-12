using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    enum State {idle, run, jump, fall};
    State state = State.idle;
    Rigidbody2D rb;
    Animator anim;
    Collider2D coll;
    [SerializeField] LayerMask ground;
    float h_vel;
    float v_vel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        rb.freezeRotation=true;
    }

    void Update()
    {
        h_vel = Input.GetAxis("Horizontal");
        if(h_vel < -0.1)
        {
            rb.velocity = new Vector2(-10,rb.velocity.y);
            transform.localScale=new Vector2(-1,1);
            state = State.run;
        }

        else if(h_vel > 0.1)
        {
            rb.velocity = new Vector2(10,rb.velocity.y);
            transform.localScale=new Vector2(1,1);
            state = State.run;
        }
        else
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
            if(rb.velocity.y > 0.1)
            {
                state = State.jump;
            }
            else
            {
                state = State.idle;
            }
        }

        if(Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x,7.5f);
            state = State.jump;
        }
        if(rb.velocity.y < -0.1)
        {
            state = State.fall;
        }
        anim.SetInteger("state",(int)state);
    }
}
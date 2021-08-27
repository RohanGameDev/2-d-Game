using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog :Enemy
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;
  
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpLength;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;
  
    private bool facingLeft = true;

    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        
    }
    private void Update()
    {
        //transtition from jump to fall
        if (anim.GetBool("Jumping"))
        {
            if(rb.velocity.y < .1)
            {
                anim.SetBool("Falling",true);
                anim.SetBool("Jumping", false);
            }
        }
        // transtition from fall to idle
        if(coll.IsTouchingLayers(ground) && anim.GetBool("Falling"))
        {
            anim.SetBool("Falling", false);
        }

    }

    private void Move()
    {
        
    
        if(facingLeft)
        {
            
            if(transform.position.x > leftCap)
            {
                //makes sure sprite is facing right direction
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                // Test to see if you are beyond the left cap
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else
            {
                // Test to see if you are beyond the right cap
                facingLeft = false;
            }

        }
        else
        {
            if (transform.position.x < rightCap)
            {
                //makes sure sprite is facing right direction
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                // Test to see if you are beyond the left cap
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                }
            }
            else
            {
                // Test to see if you are beyond the right cap
                facingLeft = true;
            }
        }
    }

    public void JumpedOn()
    {
        anim.SetTrigger("Death");
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }
}

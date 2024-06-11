using System.Collections;
using System.Collections.Generic;
//using TreeEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;
    public float runSpeed;
    private float activeSpeed;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool canDoubleJump;

    public Animator anim;

    public float knockbackLength, knockbackSpeed;
    private float knockbackCounter;

    void Update()
    {
        if (Time.timeScale > 0f)
        {

            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

            if (knockbackCounter <= 0)
            {

                activeSpeed = moveSpeed;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    activeSpeed = runSpeed;
                }

                theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * activeSpeed, theRB.velocity.y);


                if (Input.GetButtonDown("Jump"))
                {
                    if (isGrounded == true)
                    {
                        
                        Jump();
                        canDoubleJump = true;

                        anim.SetBool("isDoubleJumping", false);
                    }
                    else
                    {
                        if (canDoubleJump == true)
                        {
                            Jump();
                            canDoubleJump = false;
                            anim.SetTrigger("doDoubleJump");
                        }
                    }
                }

                if (theRB.velocity.x > 0)
                {
                    transform.localScale = Vector3.one;
                }
                if (theRB.velocity.x < 0)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }
            }
            else
            {
                knockbackCounter -= Time.deltaTime;

                theRB.velocity = new Vector2(knockbackSpeed * -transform.localScale.x, theRB.velocity.y);
            }

            //handle animation
            anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
            anim.SetBool("isGrounded", isGrounded);
            anim.SetFloat("ySpeed", theRB.velocity.y);
        }
    }

    public void Jump()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);

        AudioManager.instance.PlaySFXPitched(14);
    }

    public void KnockBack()
    {
        theRB.velocity = new Vector2(0f, jumpForce * .5f);
        anim.SetTrigger("isKnockingBack");

        knockbackCounter = knockbackLength;
    }

    public void BouncePlayer(float bounceAmount)
    {
        theRB.velocity = new Vector2(theRB.velocity.x, bounceAmount);

        canDoubleJump = true;

        anim.SetBool("isGrounded", true);
    }

    public bool canAttack()
    {
        return isGrounded && theRB.velocity.x == 0;
    }
}

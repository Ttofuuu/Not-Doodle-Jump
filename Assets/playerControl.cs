using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public Collider2D coll;

    public LayerMask platform;
    public Transform groundCheck;
    public float checkRadius;
    public Transform killLine;

    float bouncePower = 9f;
    float speed = 6f;
    float Acceleration = 12f;

    public bool isGround;

    public bool playerDead;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position,checkRadius, platform);
        movement();
        Jump();
        SwitchAnim();
    }

    void movement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        Vector2 move = new Vector2(Acceleration*horizontalMove,0);
        rb.AddForce(move);
        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }
        if(transform.position.x < -4.5f)
        {
            transform.position = new Vector3(4.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 4.5f)
        {
            transform.position = new Vector3(-4.5f, transform.position.y, transform.position.z);
        }
    }

    void Jump()
    {
        if (isGround&&rb.velocity.y<=0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, bouncePower);
        }
    }

    void SwitchAnim()
    {
        if(rb.velocity.y > 0f)
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "platform"&& rb.velocity.y <= 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, bouncePower);
        }
    }*/

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spike"))
        {
            playerDead = true;
            anim.SetTrigger("dead");
        }
        if (collision.CompareTag("spikeonform")&&rb.velocity.y<0)
        {
            playerDead = true;
            anim.SetTrigger("dead");
        }
        if (collision.CompareTag("tanhuang") && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 15f);
        }
    }

    public void PlayerDead()
    {
        playerDead = true;
        manager.GameOver(playerDead);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero: MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;
    public Joystick joystick;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        GroundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        Walk();
        Reflect();
        Jump();
        CheckingGround();
    }
    
    public Vector2 moveVector;
    public int speed = 3;

    public void Walk()
    {
        moveVector.x = joystick.Horizontal;
        if (moveVector.x == 0)
        {
            moveVector.x = Input.GetAxisRaw("Horizontal");
        }

        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));

    }

    public bool faceRight = true;

    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            sprite.flipX = !sprite.flipX;
            faceRight = !faceRight;
        }
    }
    
    public int jumpForce = 15;
    
    public void Jump()
    {  
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (onGround && joystick.Vertical >= .5f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public bool onGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    public float GroundCheckRadius;

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);
    }
}
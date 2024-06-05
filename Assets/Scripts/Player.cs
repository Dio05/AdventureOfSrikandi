using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed;
    private Animator anim;
    [SerializeField] private bool ground;

    Rigidbody2D body;

    SpriteRenderer sprite;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /* if(Input.GetKey(KeyCode.RightArrow))
         {
             body.velocity = new Vector2(speed,body.velocity.y);
             sprite.flipX = false;
         }
         if (Input.GetKey(KeyCode.LeftArrow))
         {
             body.velocity = new Vector2(-speed, body.velocity.y);
             sprite.flipX = true;
         }
         if(Input.GetKeyUp(KeyCode.RightArrow) || (Input.GetKeyUp(KeyCode.LeftArrow))) 
         {
             body.velocity = new Vector2(0, body.velocity.y);
         }*/

        //movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //flip player
        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //jump
        if(Input.GetKey(KeyCode.Space) && ground) 
        {
            Jump();
        }

        //animasi
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("ground", ground);
    }
    
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        ground = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            ground = true;
        }
    }

}

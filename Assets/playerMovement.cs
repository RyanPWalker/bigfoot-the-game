using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 5f;
    [SerializeField]private float jumpForce = 10f;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Game starting");
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
   private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }

       UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
         if (dirX > 0f)
        {
            anim.SetBool("Walking", true);
            sprite.flipX = false;
        }
        else if (dirX  < 0f)
        {
            anim.SetBool("Walking", true);
            sprite.flipX = true;
        }
        else 
        {
            anim.SetBool("Walking", false);
        }
    }
}

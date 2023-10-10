using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    private float verticalInput;

    Rigidbody2D playerRb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 playerMove = new Vector3(horizontalInput, verticalInput, 0.0f).normalized;
        Vector3 moveDistance = playerMove * speed * Time.deltaTime;

        transform.Translate(moveDistance);

        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = true;
        }

        if (horizontalInput == 0 && verticalInput == 0)
        {
            animator.speed = 0f;
            animator.SetTrigger("PlayerStop");
        }
        else
        {
            animator.speed = 1f;
            animator.SetTrigger("PlayerMove");
        }

    }
}

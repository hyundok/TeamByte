using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    private float verticalInput;

    Rigidbody2D playerRb;
    SpriteRenderer spriter;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 playerMove = new Vector2(horizontalInput, verticalInput).normalized;
        Vector2 moveDistance = playerMove * speed * Time.deltaTime;

        transform.Translate(moveDistance);

        if(horizontalInput < 0)
        {
            spriter.flipX = false;
        }
    }
}

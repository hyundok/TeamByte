using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    private float verticalInput;

    Rigidbody2D playerRb;
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

        Vector3 playerMove = new Vector3(horizontalInput, verticalInput, 0.0f).normalized;
        Vector3 moveDistance = playerMove * speed * Time.deltaTime;

        transform.Translate(moveDistance);

        float playerSpeed = playerMove.magnitude * speed;
        animator.SetFloat("Speed", playerSpeed);

        if (playerMove == Vector3.zero)
        {
            animator.SetFloat("Speed", 0f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    private float verticalInput;

    public float bulletSpeed = 10f;

    public GameObject bulletPrefab;
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
        Move();

        if (Input.GetButtonDown("Fire1"))
        {
            FireBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collide");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("OutLine"))
        {

        }
    }


    void Move()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 playerMove = new Vector3(horizontalInput, verticalInput, 0.0f).normalized;
        Vector3 moveDistance = playerMove * speed * Time.deltaTime;

        transform.Translate(moveDistance);

        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX = false;
            animator.SetTrigger("Walk");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = true;
            animator.SetTrigger("Walk");
        }

        if (horizontalInput == 0 && verticalInput == 0)
        {
            animator.speed = 0f;
        }
        else
        {
            animator.speed = 1f;
        }
    }
    void FireBullet()
    {
        // �Ѿ��� �����ϰ� �ʱ� ��ġ�� �÷��̾� ��ġ�� ����
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // �Ѿ˿� Rigidbody2D ������Ʈ�� ������
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
        Vector2 defaultShootDirection = Vector2.right; // �⺻������ ���������� �߻��ϵ��� ����
        if (horizontalInput == 0 && verticalInput == 0)
        {
            if (spriteRenderer.flipX == false)
            {
                defaultShootDirection = Vector2.left;
                bulletRb.velocity = defaultShootDirection * bulletSpeed;
            }
            if (spriteRenderer.flipX == true)
            {
                bulletRb.velocity = defaultShootDirection * bulletSpeed;
            }
        }
        else
        {
            Vector2 shootDirection = new Vector2(horizontalInput, verticalInput).normalized;

            bulletRb.velocity = shootDirection * bulletSpeed;
        }
    }
}

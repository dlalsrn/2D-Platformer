using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public Projectile projectilePrefab;
    Rigidbody2D rigidbody2d;
    Animator animator;
    float jump = 12f; // 점프 힘
    float moveSpeed = 5f; // 움직이는 속도
    float xdir; // Input 값
    bool isGrounded; // 땅에 서있는지
    public bool hasKey; // Key를 가지고 있는지
    public bool hasProjectile; // 발사체를 가지고 있는지
    public int health = 3; // 플레이어 체력

    void Start() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.Instance.State == GameManager.GameState.Pause) {
            return;
        }
        
        xdir = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.A)) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.D)) {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            rigidbody2d.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }

        if (hasProjectile && Input.GetButtonDown("Fire1")) {
            Vector3 playerDir = new Vector3(transform.localScale.x, 0, 0);

             // 플레이어가 보는 방향으로 1만큼 앞에
            Projectile projectile = Instantiate<Projectile>(projectilePrefab, transform.position + playerDir, Quaternion.identity);
            projectile.Shoot(playerDir);
            hasProjectile = false;
        }

        isGrounded = Physics2D.CircleCast(transform.position, 0.3f, Vector2.down, 1.1f, LayerMask.GetMask("Platforms"));

        animator.SetBool("Grounded", isGrounded);
        animator.SetFloat("Speed", MathF.Abs(xdir * moveSpeed));
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 1.1f);
    }
    
    void FixedUpdate() {
        rigidbody2d.velocity = new Vector2(xdir * moveSpeed, rigidbody2d.velocity.y);
    }

    public void Hit() {
        animator.SetTrigger("Hurt");
        health -= 1;

        if (health == 0) { // 게임 오버
            GameManager.Instance.GameOver();
        }
    }
}

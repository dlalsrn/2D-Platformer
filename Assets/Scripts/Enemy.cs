using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Animator animator;
    float moveSpeed; // 적마다 움직이는 속도를 랜덤하게
    int xdir; // 처음 방향을 랜덤으로
    bool isGrounded1;
    bool isGrounded2;

    void Start() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        xdir = (UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1);
        moveSpeed = UnityEngine.Random.Range(3, 6);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            PlayerController player = collision.collider.gameObject.GetComponent<PlayerController>();
            player.Hit();     
        }

        if (collision.collider.CompareTag("Enemy")) { // 적끼리 부딪히면 방향을 반대로
            xdir *= -1;  
        }
    }

    void Update() {
        isGrounded1 = Physics2D.CircleCast(transform.position, 0.3f, (Vector2.down + Vector2.left), 1.1f, LayerMask.GetMask("Platforms")); // 왼쪽 대각선이 땅인지
        isGrounded2 = Physics2D.CircleCast(transform.position, 0.3f, (Vector2.down + Vector2.right), 1.1f, LayerMask.GetMask("Platforms")); // 오른쪽 대각선이 땅인지

        if (!isGrounded1) { // 왼쪽으로 더 가면 떨어지는 경우
            xdir = 1; // 방향을 오른쪽으로
        }

        if (!isGrounded2) { // 오른쪽으로 더 가면 떨어지는 경우
            xdir = -1; // 방향을 왼쪽으로
        }

        transform.localScale = new Vector3(xdir, 1, 1); // 이동 방향으로 x 값 변경

        animator.SetFloat("Speed", MathF.Abs(xdir * moveSpeed));
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (transform.position + Vector3.down + Vector3.left) * 1.1f); // 왼쪽 대각선
        Gizmos.DrawLine(transform.position, (transform.position + Vector3.down + Vector3.right) * 1.1f); // 오른쪽 대각선
    }

    void FixedUpdate() {
        rigidbody2d.velocity = new Vector2(xdir * moveSpeed, rigidbody2d.velocity.y);
    }
}

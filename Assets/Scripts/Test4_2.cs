using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test4_2 : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float baseJumpForce = 15f;
    public float maxMultiplier = 1.3f;
    public float accelerationTime = 2f;
    public float wallSlideSpeed = 1f;  // ���� �پ��� �� �̲������� �ӵ�
    public float wallJumpForce = 12f;  // �� ���� ��
    public float wallJumpPushForce = 7f; // �� ���� �� �и��� ��
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    private Rigidbody2D rb;
    private float speedMultiplier = 1f;
    private float jumpMultiplier = 1f;
    private float increaseTimer = 0f;
    private bool isGrounded;
    private bool isTouchingWall;
    private float lastDirection = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        // �� ����
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        // �� ���� (�¿�)
        bool touchingLeftWall = Physics2D.Raycast(transform.position, Vector2.left, 0.6f, wallLayer);
        bool touchingRightWall = Physics2D.Raycast(transform.position, Vector2.right, 0.6f, wallLayer);
        isTouchingWall = touchingLeftWall || touchingRightWall;

        // �̵� ������ �ٲ�� �ӵ� & ������ �ʱ�ȭ
        if (Mathf.Abs(moveX) > 0.01f)
        {
            if (Mathf.Sign(moveX) != Mathf.Sign(lastDirection) || lastDirection == 0f)
            {
                increaseTimer = 0f;
                speedMultiplier = 1f;
                jumpMultiplier = 1f;
            }
            else
            {
                increaseTimer += Time.deltaTime;
                float targetMultiplier = Mathf.Lerp(1f, maxMultiplier, increaseTimer / accelerationTime);
                speedMultiplier = Mathf.Min(targetMultiplier, maxMultiplier);
                jumpMultiplier = Mathf.Min(targetMultiplier, maxMultiplier);
            }
            lastDirection = moveX;
        }
        else
        {
            increaseTimer = 0f;
            speedMultiplier = 1f;
            jumpMultiplier = 1f;
        }

        // �� �̲����� ó��
        if (isTouchingWall && !isGrounded && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
        }

        // �̵� ���� (���� �پ����� ���� ����)
        if (!isTouchingWall || isGrounded)
        {
            rb.velocity = new Vector2(moveX * baseSpeed * speedMultiplier, rb.velocity.y);
        }

        // ���� ó��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, baseJumpForce * jumpMultiplier);
            }
            else if (isTouchingWall)
            {
                // �� ���� ó��
                float jumpDirection = touchingLeftWall ? 1f : -1f; // ���� ���̸� ����������, ������ ���̸� ��������
                rb.velocity = new Vector2(jumpDirection * wallJumpPushForce, wallJumpForce);
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test4_1 : MonoBehaviour
{
    public float baseSpeed = 5f;  // �⺻ �ӵ�
    public float baseJumpForce = 15f; // �⺻ ������
    public float maxMultiplier = 1.3f; // �ִ� ���� (1.3��)
    public float accelerationTime = 2f; // �ִ� ���� �ð� (2��)
    public LayerMask groundLayer;
    public LayerMask wallLayer; // �� ���� ���̾�

    private Rigidbody2D rb;
    private float speedMultiplier = 1f;
    private float jumpMultiplier = 1f;
    private float increaseTimer = 0f;
    private bool isGrounded;
    private bool isWallSliding;
    private float lastDirection = 0f; // ������ �̵� ����
    private float wallJumpCooldown = 0.2f; // �� ���� �� �Է� ��� �ð�
    private float wallJumpTimer;
    private int wallJumpDirection = 1; // �� ���� ����
    public float wallJumpMultiplier = 1.2f; // �� ���� �߰� ����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        // �̵� ������ �ٲ�� �ӵ� & ������ �ʱ�ȭ
        if (Mathf.Abs(moveX) > 0.01f)
        {
            if (Mathf.Sign(moveX) != Mathf.Sign(lastDirection) || lastDirection == 0f)
            {
                increaseTimer = 0f; // ���� �ٲٸ� �ʱ�ȭ
                speedMultiplier = 1f;
                jumpMultiplier = 1f;
            }
            else
            {
                increaseTimer += Time.deltaTime; // ��� �̵��ϸ� ����
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

        // ���� �ӵ� ���� (�� ���� ���� ��� �Է� ����)
        if (Time.time > wallJumpTimer)
        {
            rb.velocity = new Vector2(moveX * baseSpeed * speedMultiplier, rb.velocity.y);
        }

        // ���� ��� �ִ��� Ȯ��
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        // ���� ��� �ִ��� Ȯ��
        bool isTouchingWallLeft = Physics2D.Raycast(transform.position, Vector2.left, 0.6f, wallLayer);
        bool isTouchingWallRight = Physics2D.Raycast(transform.position, Vector2.right, 0.6f, wallLayer);

        isWallSliding = (isTouchingWallLeft || isTouchingWallRight) && !isGrounded && rb.velocity.y < 0;

        // �� �����̵� ������ �� �ӵ� ���̱�
        if (isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, -2f);
            wallJumpDirection = isTouchingWallLeft ? 1 : -1; // �� ���� �ݴ������� ����
        }

        // ���� ó�� (�Ϲ� ���� �� �� ����)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded) // �Ϲ� ����
            {
                rb.velocity = new Vector2(rb.velocity.x, baseJumpForce * jumpMultiplier);
            }
            else if (isWallSliding) // �� ����
            {
                rb.velocity = new Vector2(baseSpeed * wallJumpDirection, baseJumpForce * wallJumpMultiplier);
                wallJumpTimer = Time.time + wallJumpCooldown; // �� ���� �� ��� �Է� ����
            }
        }
    }
}

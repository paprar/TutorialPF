using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test4 : MonoBehaviour
{
    public float baseSpeed = 5f;  // �⺻ �ӵ�
    public float baseJumpForce = 15f; // �⺻ ������
    public float maxMultiplier = 1.3f; // �ִ� ���� (1.3��)
    public float accelerationTime = 2f; // �ִ� ���� �ð� (2��)
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float speedMultiplier = 1f;
    private float jumpMultiplier = 1f;
    private float increaseTimer = 0f;
    private bool isGrounded;
    private float lastDirection = 0f; // ������ �̵� ����

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

        // ���� �ӵ� ����
        rb.velocity = new Vector2(moveX * baseSpeed * speedMultiplier, rb.velocity.y);

        // ���� ��� �ִ��� Ȯ��
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);

        // ���� ó�� (�̵� �� ������ ������ ����)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, baseJumpForce * jumpMultiplier);
        }
    }
}


















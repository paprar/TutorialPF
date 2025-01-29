using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3_1 : MonoBehaviour
{
    public float moveSpeed = 20f;  // �⺻ �̵� �ӵ�
    public float maxSpeed = 12f;   // �ִ� �ӵ�
    public float acceleration = 5f; // ���ӵ�
    private Rigidbody2D rigid;
    public float jumpForce = 8f;
    private bool isGrounded = true;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.drag = 0.5f; // ���� ���� ���� (���� ���̸� �� ���� �̵� ����)
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(moveX, 0);

        // �ӵ��� �ε巴�� ������Ű�鼭 AddForce ����
        float smoothedSpeed = Mathf.Lerp(0, moveSpeed, Time.fixedDeltaTime * acceleration);
        rigid.AddForce(moveDirection * smoothedSpeed, ForceMode2D.Force);

        // �ִ� �ӵ� ����
        if (rigid.velocity.magnitude > maxSpeed)
        {
            rigid.velocity = rigid.velocity.normalized * maxSpeed;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; // ���� ���·� ����
        }
    }

    // �ٴڿ� ����� �� ���� �����ϵ��� ����
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Ground �±װ� �ִ� ������Ʈ�� �浹 ��
        {
            isGrounded = true;
        }
    }
}

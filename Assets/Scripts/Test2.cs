using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    int speed = 5;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // �Է� �� �ޱ�
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D Ű �Ǵ� ȭ��ǥ �¿�
        float moveVertical = Input.GetAxis("Vertical");     // W/S Ű �Ǵ� ȭ��ǥ ����

        // �ӵ� ����
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Rigidbody2D�� �ӵ� ����
        rb.velocity = movement * speed;
    }
}

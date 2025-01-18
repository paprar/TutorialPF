using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Transform playerStartPosition;
    private Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //�÷��̾ �����Ҷ� ���� ������ ��ġ�� �̵��϶�.
        //transform.position = new Vector2(-8f,2f);

        transform.position = playerStartPosition.position;

        //transform.Rotate(new Vector3());

        //transform.localScale = 
    }

    // Update is called once per frame
    void Update()
    {
        //�Է��� �޾ƿ;� �Ѵ�.
        //if(Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.position = transform.position + Vector3.right* moveSpeed * Time.deltaTime;
        //    //��ġ = ��ġ+ ����*�ӵ�*�ð�
        //}

        //if(Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.position = transform.position + Vector3.left* moveSpeed * Time.deltaTime;
        //}

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.position = transform.position + Vector3.up * moveSpeed * Time.deltaTime;
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.position = transform.position + Vector3.down * moveSpeed * Time.deltaTime;
        //}


        float moveInputX = Input.GetAxisRaw("Horizontal"); //���ι����� �Է°��� �޴´�.

        rigid.velocity = new Vector2(moveInputX * moveSpeed, rigid.velocity.y); 

        if (Input.GetKey(KeyCode.Space))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 10);
        }

        
        //�Է¿� �´� ������ �����ϴ� ��

        //ĳ���� ����

        //

        // ĳ���Ͱ� �����δ�.

        // �Է�

        //(x,y) ��ǥ �̵��Ѵ�.
    }
}

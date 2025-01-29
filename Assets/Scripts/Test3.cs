using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3 : MonoBehaviour
{
    public float moveSpeed = 15f; //�̵� �ӵ�
    private Rigidbody2D rigid; //Rigidbody ������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>(); //Rigidbody ��������
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); //�¿��̵�

        Vector2 moveDirectionX = new Vector2(moveX, 0);
        Vector2 moveDirectionY = new Vector2(0, 1);
        rigid.AddForce(moveDirectionX * moveSpeed, ForceMode2D.Impulse); 
        //velocity�� vector ������ ����ؼ� ���� ��� ���� ����
        //addforce�� vector �����ڸ� ���ڷ� �ޱ⸸ �ؼ� ���� ��� ���� �Ұ���, �ٸ� ������ �ٸ� ���� �߰��ؾ���.

        if(Input.GetKey(KeyCode.Space))
        {
            rigid.AddForce(moveDirectionY,ForceMode2D.Impulse);
        }



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCoin : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float popPower = 2.5f;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>(); //������Ʈ�� ã�Ƽ� Ÿ���� Rigidbody2D�� �༮�� rigid������ �Ҵ��Ѵ�.
        rigid.AddForce(Vector2.up *popPower, ForceMode2D.Impulse); //new Vector3() �̰� �� �ϴ���, Vector2.up ���� ���� ���Ѵ�.

        //Invoke(nameof((DisableObject), 1.5f)); //1.5f �ڿ� DisableObject �Լ� ����
        Destroy(gameObject,2);                 //gameObject �ı��Ѵ� 2f �ڿ�
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���������� Ŭ�����߽��ϴ�.
        Debug.Log("���������� Ŭ�����߽��ϴ�.");
        //Ŭ���� ����
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("�浹 �������� ������ϴ�.");
    }

    //������ ������ ��� �����.
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("�浹 ������");
    }
}

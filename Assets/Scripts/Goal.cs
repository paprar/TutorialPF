using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject ClearInfoObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���������� Ŭ�����߽��ϴ�.
        //Debug.Log("���������� Ŭ�����߽��ϴ�.");
        //Ŭ���� ����

        //�÷��̾�� �浹�ϸ� Clear Info UI�� Ȱ��ȭ�Ѵ�.
        ClearInfoObject.SetActive(true);
    }
}

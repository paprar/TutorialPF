using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBox : MonoBehaviour
{
    public GameObject CoinPrefab; //���� �������� ����ϰڴ�.

    public bool isActivate = true; //RandomBox�� Ȱ��ȭ �Ǿ��ִ� ����

    SpriteRenderer _sr;

    public Sprite unActivateBoxSpriteRenderer;

    public ParticleSystem broken;

    private void Start()
    {
        _sr = GetComponentInParent<SpriteRenderer>();
        broken = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActivate) //isActivate������ true�϶��� �Ʒ��ڵ带 ������.
        {
            //���������� Ŭ�����߽��ϴ�.
            isActivate = false;
            create();  
            Debug.Log("�����ڽ��� �浹�߽��ϴ�.");

            Instantiate(CoinPrefab, transform.position, Quaternion.identity);

            // �θ���(������Ʈ �̸��� randombox ����) spriterenderer����� sprite ���� tilemap_29�� �����϶�.
            _sr.sprite = unActivateBoxSpriteRenderer;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("�����ڽ��� �浹�� �������ϴ�.");
    }

    //������ ������ ��� �����.
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("�����ڽ��� �浹 �������Դϴ�.");
    }

    void create()
    {
        broken.Play();
    }
}

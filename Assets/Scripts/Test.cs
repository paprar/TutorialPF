using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Test : MonoBehaviour
{
    int speed = 10;
    int yspeed = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float x = Input.GetAxis("Horizontal") * moveSpeed;
        //float y = Input.GetAxis("Vertical") * moveSpeed;
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x������ �̵��� ��
        float yMove = Input.GetAxis("Vertical") * yspeed * Time.deltaTime; //y������ �̵��Ҿ�
        transform.Translate(new Vector3(xMove, yMove, 0));  //�̵�

        //rigidBody.velocity = ;
        //transform.Translate(Vector3.forward*speed);
    }
}

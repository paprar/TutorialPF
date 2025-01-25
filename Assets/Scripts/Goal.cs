using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //스테이지를 클리어했습니다.
        Debug.Log("스테이지를 클리어했습니다.");
        //클리어 과정
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("충돌 지점에서 벗어났습니다.");
    }

    //가만히 있으면 계속 실행됨.
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("충돌 진행중");
    }
}

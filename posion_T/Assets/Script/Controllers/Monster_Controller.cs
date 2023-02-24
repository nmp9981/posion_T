using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Controller : MonoBehaviour
{
    bool Live;
    float HP;
    float DefaultSpead;

    public void beAttacked(float DMG)   // 공격 당함// 투사체가 this.transform.gameObject와 충돌했을 때 사용

    {
        //this.HP --;
    }

    //Collision2D

    public void Dead()  //죽음
    {
        //디스트로이(this.gameObj);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Resource.MonsterMove -= this.ThisMove;
        GameManager.Resource.MonsterMove += this.ThisMove;


        //GM.Resource.OnUpdate += ThisMove;
    }

    float RealSpead(float plusMin)//
    {
        return DefaultSpead * plusMin;
    }

    void ThisMove()
    {
        //this.gameOBJ.transform
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

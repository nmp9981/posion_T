using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Controller : MonoBehaviour
{
    bool Live;
    float HP;
    float DefaultSpead;

    public void beAttacked(float DMG)   // ���� ����// ����ü�� this.transform.gameObject�� �浹���� �� ���

    {
        //this.HP --;
    }

    //Collision2D

    public void Dead()  //����
    {
        //��Ʈ����(this.gameObj);
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

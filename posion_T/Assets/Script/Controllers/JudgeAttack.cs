using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeAttack : T_Controller
{
    //���� ����� ���� ã��
    public Vector3 NearestMonster()
    {
        float mobDist;
        float dist = gameObject.GetComponent<Monster_Controller>().dist;//���� ����Ÿ�
        //��ü�Ÿ�
        float FullDist_x = Mathf.Abs(GameObject.Find("Dir2").transform.position.x - GameObject.Find("Dir3").transform.position.x) * 4;
        float FullDist_y = Mathf.Abs(GameObject.Find("Dir1").transform.position.x - GameObject.Find("Dir2").transform.position.x) * 4;
        float FullDist = FullDist_x+FullDist_y+ Mathf.Abs(GameObject.Find("StartPoint").transform.position.x - GameObject.Find("EndPoint").transform.position.x);
       
        Vector3 target;
        float closeDist = 100;
        int idx = 0;

        if (InAreaMonster.Count == 0)
        {
            target = new Vector3(this.xpos,this.ypos,0);
            return target;
        }

        for (int i = 0; i < InAreaMonster.Count; i++)
        {
            mobDist = InAreaMonster[i].dist;//���� �̵� �Ÿ�
            if (FullDist-mobDist < closeDist)//�� ���� �Ÿ�
            {
                idx = i;
            }
        }
        target = new Vector3(InAreaMonster[idx].xpos, InAreaMonster[idx].ypos, 0);
        return target;
    }

}
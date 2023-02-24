using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeAttack : T_Controller
{

    float endXpos = 1.5f;//Ÿ�� ��ǥ
    float endYpos = -3f;

    //���� ����� ���� ã��
    public Vector3 NearestMonster()
    {
        float closeDist = 100;
        int idx = 0;
        for (int i = 0; i < InAreaMonster.Count; i++)
        {
            if (21 - InAreaMonster[i].GetComponent<Monster_Controller>().dist < closeDist)//�� ���� �Ÿ�
            {
                idx = i;
            }
        }
        Vector3 target = new Vector3(InAreaMonster[idx].xpos, InAreaMonster[idx].ypos, 0);
        return target;
    }

}
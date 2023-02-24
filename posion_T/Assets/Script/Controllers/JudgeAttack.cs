using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeAttack : T_Controller
{

    float endXpos = 1.5f;//타워 좌표
    float endYpos = -3f;

    //가장 가까운 몬스터 찾기
    public Vector3 NearestMonster()
    {
        float closeDist = 100;
        int idx = 0;
        for (int i = 0; i < InAreaMonster.Count; i++)
        {
            if (21 - InAreaMonster[i].GetComponent<Monster_Controller>().dist < closeDist)//더 작은 거리
            {
                idx = i;
            }
        }
        Vector3 target = new Vector3(InAreaMonster[idx].xpos, InAreaMonster[idx].ypos, 0);
        return target;
    }

}
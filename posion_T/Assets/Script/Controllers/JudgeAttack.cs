using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeAttack : T_Controller
{
    //가장 가까운 몬스터 찾기
    public Vector3 NearestMonster()
    {
        float mobDist;
        float dist = gameObject.GetComponent<Monster_Controller>().dist;//현재 진행거리
        //전체거리
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
            mobDist = InAreaMonster[i].dist;//몬스터 이동 거리
            if (FullDist-mobDist < closeDist)//더 작은 거리
            {
                idx = i;
            }
        }
        target = new Vector3(InAreaMonster[idx].xpos, InAreaMonster[idx].ypos, 0);
        return target;
    }

}
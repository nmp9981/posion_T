using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager 
{
    Action MonsterMove = null;
    
    public List<GameObject> _monster_List = new List<GameObject>();
    public List<GameObject> Monster_List { get { return _monster_List; }set { _monster_List = value; } }

    public List<GameObject> InAreaMonster_List = new List<GameObject>();//3*3���� ����

    int idx;


    //List ����;
    //List ����ü;

    public void OnUpdate()
    {
        // Null?? �׾ ������������ ��� �����ڰ� �θ��� ��?
        //MonsterMove.Invoke();
    }

    // Start is called before the first frame update
   
}
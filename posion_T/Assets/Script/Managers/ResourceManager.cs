using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager 
{
    public Action MonsterMove = null;
    
    public List<GameObject> _monster_List = new List<GameObject>();
    public List<GameObject> Monster_List { get { return _monster_List; }set { _monster_List = value; } }


    int idx;


    //List ����;
    //List ����ü;

    public void OnUpdate()
    {
        MonsterMove.Invoke();
    }

    // Start is called before the first frame update
   
}

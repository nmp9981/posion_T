using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Controller : MonoBehaviour
{
    GameObject Tower;
    GameObject Skill;

    int _y, _x;
    int _towerNum = 0;
    public int Y { get { return _y; } set { _y = value; } }

    public int X { get { return _x; } set { _x = value; } }

    public int TowerNum { get { return _towerNum; } set { _towerNum = value; } }

    public void InstanceTower(Define.Property property)
    {

        Tower = Instantiate(GameManager.Tower[(int)property]);
        Tower.transform.parent = transform;

        Tower.transform.localPosition = new Vector3(0,0,0);
    }
    public void InstanceSkill(Define.Skill property)
    {

        Skill = Instantiate(GameManager.Skills[(int)property]);
        Skill.transform.parent = transform;
        Skill.GetComponent<SkillTile>().SkillExistTime();
        Skill.transform.localPosition = new Vector3(0, 0, 0);
    }
}

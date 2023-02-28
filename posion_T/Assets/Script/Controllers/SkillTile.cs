using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTile : MonoBehaviour
{
    GameObject Skill;
    public void InstanceSkill(Define.Skill skill)
    {

        Skill = Instantiate(GameManager.Skills[(int)skill]);
        Skill.transform.parent = transform;

        Skill.transform.localPosition = new Vector3(0, 0, 0);
    }
    //��ų ������ ���� �߰�
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mob")//�����̰�
        {
            float range = Vector3.Magnitude(this.gameObject.transform.position - other.gameObject.transform.position);
            if (range <= GameManager.SkillRange)//3*3���� ���ΰ�?
            {
                gameObject.GetComponent<ResourceManager>().InAreaMonster_List.Add(other.gameObject);
            }
        }
    }
    //��ų ������ ���� ����
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mob")//�����̸�
        {
            gameObject.GetComponent<ResourceManager>().InAreaMonster_List.Remove(other.gameObject);
        }
    }
}

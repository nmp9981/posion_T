using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTile : MonoBehaviour
{
    GameObject Skill;
    [SerializeField]
    Define.Skill Myskill;

    float[] _exitTime = new float[3] { 0.1f,5f,5f};

    public void InstanceSkill(Define.Skill skill)// �� �Լ��� Tile_Controller�� ���°� �½��ϴ�
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
            /*
            float range = Vector3.Magnitude(this.gameObject.transform.position - other.gameObject.transform.position);
            if (range <= GameManager.SkillRange)//3*3���� ���ΰ�?
            {
                gameObject.GetComponent<ResourceManager>().InAreaMonster_List.Add(other.gameObject);
            }
            */

            // �׳� SkillŸ�� Collider�� ũ�⸦ 3*3 ũ��� ��

            switch (Myskill) {

                case Define.Skill.Explosion:
                    Debug.Log("Explosion");
                    other.GetComponent<Monster_Controller>().beAttacked(300);
                    break;
                case Define.Skill.Sticky:
                    Debug.Log("Sticky");

                    other.GetComponent<Monster_Controller>().Slow(0.5f);
                    break;
                case Define.Skill.Nullity:
                    Debug.Log("Nullity");

                    other.GetComponent<Monster_Controller>().Property = Define.Property.None;
                    break;
            }


        }
    }
    //��ų ������ ���� ����
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mob")//�����̸�
        {
            //gameObject.GetComponent<ResourceManager>().InAreaMonster_List.Remove(other.gameObject);

            switch (Myskill)
            {

                case Define.Skill.Explosion:
                    //other.GetComponent<Monster_Controller>().beAttacked(300);
                    break;
                case Define.Skill.Sticky:
                    other.GetComponent<Monster_Controller>().Slow(0f);
                    break;
                case Define.Skill.Nullity:
                    other.GetComponent<Monster_Controller>().Property = other.GetComponent<Monster_Controller>().BornProperty;
                    break;
            }
        }
    }

    public void SkillExistTime()
    {
        StartCoroutine(ExistTime());
    }
    IEnumerator ExistTime()
    {
        yield return new WaitForSeconds(_exitTime[(int)Myskill]);
        Destroy(this.gameObject);
    }
}

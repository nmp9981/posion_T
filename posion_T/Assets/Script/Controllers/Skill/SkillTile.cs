using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTile : MonoBehaviour
{
    GameObject Skill;
    [SerializeField]
    Define.Skill Myskill;

    //float[] _exitTime = new float[3] { 0.5f,5f,5f};

    public void InstanceSkill(Define.Skill skill)// �� �Լ��� Tile_Controller�� ���°� �½��ϴ�
    {

        Skill = Instantiate(GameManager.Skills[(int)skill]);
        Skill.transform.parent = transform;

        Skill.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void Start()
    {
        this.transform.localScale = new Vector3(0.6482642f, 0.6180149f, 1f);

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
                    other.GetComponent<Monster_Controller>().beAttacked(300);
                    break;
                case Define.Skill.Sticky:
                    other.GetComponent<Monster_Controller>().Speed = other.GetComponent<Monster_Controller>().DEFAULTSPEED/2;
                    break;
                case Define.Skill.Nullity:
                    other.GetComponent<Monster_Controller>().Property = Define.Property.None;
                    break;
            }


        }
    }
    // ���ο찡 ������ ������ ���� �ӵ��� ���Ѵٸ� ������ ��ġ�� �̾������� ù ��° ������ �����ڸ��� ���� �ӵ��� ���ƿ� ���̴� �� ��° ���� ȿ�� x
    // �� ������ ������Ʈ �� ���� ó���� ����� �� ã��
    private void OnTriggerStay2D(Collider2D other)
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

                    other.GetComponent<Monster_Controller>().Speed = other.GetComponent<Monster_Controller>().DEFAULTSPEED/2;
                    break;
                case Define.Skill.Nullity:
                    //other.GetComponent<Monster_Controller>().Property = other.GetComponent<Monster_Controller>().BornProperty;
                    break;
                default:
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
                    other.GetComponent<Monster_Controller>().Speed = other.GetComponent<Monster_Controller>().DEFAULTSPEED;
                    break;
                case Define.Skill.Nullity:
                    other.GetComponent<Monster_Controller>().Property = other.GetComponent<Monster_Controller>().BornProperty;
                    break;

                default:
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
        Debug.Log($"LV[{(int)Myskill + 5}] : {GameManager.LV[(int)Myskill + 5]} time: {GameManager.SKILLEXISTTIME[GameManager.LV[(int)Myskill + 5]]}");
        yield return new WaitForSeconds(Myskill == Define.Skill.Explosion ? 0.4f : GameManager.SKILLEXISTTIME[GameManager.LV[(int)Myskill + 5]]);

        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTile : MonoBehaviour
{
    GameObject Skill;
    [SerializeField]
    Define.Skill Myskill;

    //float[] _exitTime = new float[3] { 0.5f,5f,5f};

    public void InstanceSkill(Define.Skill skill)// 위 함수는 Tile_Controller에 가는게 맞습니다
    {

        Skill = Instantiate(GameManager.Skills[(int)skill]);
        Skill.transform.parent = transform;

        Skill.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void Start()
    {
        this.transform.localScale = new Vector3(0.6482642f, 0.6180149f, 1f);

    }

    //스킬 범위내 몬스터 추가
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mob")//몬스터이고
        {
            /*
            float range = Vector3.Magnitude(this.gameObject.transform.position - other.gameObject.transform.position);
            if (range <= GameManager.SkillRange)//3*3범위 내인가?
            {
                gameObject.GetComponent<ResourceManager>().InAreaMonster_List.Add(other.gameObject);
            }
            */

            // 그냥 Skill타일 Collider의 크기를 3*3 크기로 함

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
    // 슬로우가 장판을 나가면 정상 속도로 변한다면 장판을 겹치게 이어놨을경우 첫 번째 장판을 나가자마자 정상 속도로 돌아올 것이다 두 번째 장판 효력 x
    // 이 문제를 업데이트 안 쓰고 처리할 방안을 못 찾음
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mob")//몬스터이면
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
    //스킬 범위내 몬스터 삭제
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mob")//몬스터이면
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

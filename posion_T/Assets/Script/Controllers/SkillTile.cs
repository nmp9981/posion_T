using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTile : MonoBehaviour
{
    GameObject Skill;
    [SerializeField]
    Define.Skill Myskill;

    float[] _exitTime = new float[3] { 0.1f,5f,5f};

    public void InstanceSkill(Define.Skill skill)// 위 함수는 Tile_Controller에 가는게 맞습니다
    {

        Skill = Instantiate(GameManager.Skills[(int)skill]);
        Skill.transform.parent = transform;

        Skill.transform.localPosition = new Vector3(0, 0, 0);
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

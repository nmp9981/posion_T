using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Controller : MonoBehaviour
{
    public List<Monster_Controller> InAreaMonster;
    protected float xpos, ypos;
    float arrowSpeed = 0.7f;
    GameObject Projectile;
    public GameObject arrow;

    bool isDelay;

    [SerializeField]
    Define.Property property = Define.Property.Fire;

    // Start is called before the first frame update
    void Start()
    {
        InAreaMonster = new List<Monster_Controller>();
        Projectile = Resources.Load<GameObject>($"Prefabs/Projectile/Projectile{(int)property}");
       
        //현재 타워 좌표
        xpos = this.transform.position.x;
        ypos = this.transform.position.y;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (isDelay == false)//화살 생성에 딜레이를 준다
        {
            isDelay = true;
            StartCoroutine("SetArrow");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //공격할 몬스터 넣기
        Monster_Controller M = collision.GetComponent<Monster_Controller>();
        //if (M != null) print("Here");
        InAreaMonster.Add(M);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        //몬스터 인덱스 관리가 필요함

        Monster_Controller M = collision.GetComponent<Monster_Controller>();
        if (M != null)//&& M.)M.Live -> 이게 퍼블릭 처리가 안되어있음
        {
            InAreaMonster.Remove(M);

        }
        StopCoroutine("SetArrow");
    }
   
    void Attack()
    {

    }

    IEnumerator SetArrow()
    {
        Debug.Log("화살생성");
        GameObject go = Instantiate(arrow);//화살 생성(매개변수로 프리팹 전달),GameObject로 강제 형 변환
        go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        yield return new WaitForSecondsRealtime(arrowSpeed);
        isDelay = false;
    }
}

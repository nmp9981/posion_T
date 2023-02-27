using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Controller : MonoBehaviour
{
    public List<Monster_Controller> InAreaMonster;
    float FullDist_x, FullDist_y,FullDist;
    float xpos, ypos;
    float mobDist;
    float arrowSpeed = 1f;
    float closeDist = 100;
    GameObject Projectile;
    GameObject myTarget;
    Vector3 target;
    public List<GameObject> inRangeMonster; 

    bool isDelay;
    bool arrowFlag;

    [SerializeField]
    Define.Property property = Define.Property.Fire;

    Vector3[] _direction = new Vector3[9];
    // Start is called before the first frame update
    void Start()
    {
        _direction = GameManager.Direction;
        InAreaMonster = new List<Monster_Controller>();
        Projectile = Resources.Load<GameObject>($"Prefabs/Projectile/Projectile{(int)property}");
        myTarget = GameObject.FindWithTag("Arrow");
        isDelay = false;
        arrowFlag = false;
        StartCoroutine(ContinueShoot());

        //���� Ÿ�� ��ǥ
        xpos = this.transform.position.x;
        ypos = this.transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //������ ���� �ֱ�
        if (other.gameObject.tag == "Mob")
        {
            inRangeMonster.Add(other.gameObject);


            //GameObject tempMob = other.gameObject;
            //Monster_Controller M = other.gameObject.GetComponent<Monster_Controller>();
            //InAreaMonster.Add(M);
            //target = M.gameObject.transform.position;
            //myTarget.GetComponent<Projectile_Controller>().setTarget((Vector3)tempMob.transform.position);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mob")
        {
            if (inRangeMonster.Count > 0)
            {
                inRangeMonster.Remove(other.gameObject);
            }
           
        }
        
    }

    public Vector3 NearestMonster()
    {
        //��ü�Ÿ�
        //FullDist_x = Mathf.Abs(GameObject.Find("dir2").transform.position.x - GameObject.Find("dir3").transform.position.x) * 4;
        //FullDist_y = Mathf.Abs(GameObject.Find("dir1").transform.position.y - GameObject.Find("dir2").transform.position.y) * 4;
        //FullDist = FullDist_x + FullDist_y + Mathf.Abs(GameObject.Find("StartPoint").transform.position.x - GameObject.Find("EndPoint").transform.position.x);

        FullDist_x = Mathf.Abs(_direction[1].x - _direction[2].x) * 4;
        FullDist_y = Mathf.Abs(_direction[0].y - _direction[1].y) * 4;

        FullDist = FullDist_x + FullDist_y + Mathf.Abs(GameObject.Find("StartPoint").transform.position.x - GameObject.Find("EndPoint").transform.position.x);

        //int idx = 0;

        if (InAreaMonster.Count == 0)
        {
            target = this.transform.position;
            return target;
        }
        /*
        for (int i = 0; i < InAreaMonster.Count; i++)
        {
            mobDist = InAreaMonster[i].dist;//���� �̵� �Ÿ�
            if (FullDist - mobDist < closeDist)//�� ���� �Ÿ�
            {
                idx = i;
            }
        }
        */
      
        //target = new Vector3(InAreaMonster[0].xpos, InAreaMonster[0].ypos, 0);//�Ǿ�
        return target;
    }
    void Attack()
    {

    }

    IEnumerator ContinueShoot()
    {
        while (true)
        {
            if (isDelay == false && inRangeMonster.Count > 0)
            {
          
                isDelay = true;
                if (Time.timeScale == 1)
                {
                    GameObject go = Instantiate(Projectile);//ȭ�� ����(�Ű������� ������ ����),GameObject�� ���� �� ��ȯ
                    go.transform.position = this.transform.position;
                    Vector3 point = NearestMonster();
                    go.GetComponent<Projectile_Controller>().Shoot(point, this.transform.position);
                    GameManager.Sound.Play("Effect/button1");
                    go.GetComponent<Projectile_Controller>().setTarget(FindTarget(inRangeMonster).transform.position);
                    Destroy(go, 2f);
                }
                yield return new WaitForSecondsRealtime(GameManager.SHOOTSPEED[GameManager.LV[(int)property]]);
                isDelay = false;
            }
            else
            {
                yield return null;
            }
        }
    } 
   

    GameObject FindTarget(List<GameObject> mons)
    {
        float maxTime = mons[0].GetComponent<Monster_Controller>().LifeTime;
            int nowIdx = 0;
        for(int i = 1; i < mons.Count; i++)
        {
            if(maxTime< mons[i].GetComponent<Monster_Controller>().LifeTime)
            {
                maxTime = mons[i].GetComponent<Monster_Controller>().LifeTime;
                nowIdx = i;
            }
        }
        return mons[nowIdx];
    }
}

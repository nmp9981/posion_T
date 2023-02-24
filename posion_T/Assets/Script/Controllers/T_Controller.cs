using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Controller : MonoBehaviour
{
    public List<Monster_Controller> InAreaMonster;
    float FullDist_x, FullDist_y,FullDist;
    float xpos, ypos;
    float mobDist;
    float arrowSpeed = 0.7f;
    float closeDist = 100;
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
        isDelay = false;
       
        //���� Ÿ�� ��ǥ
        xpos = this.transform.position.x;
        ypos = this.transform.position.y;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (isDelay == false)//ȭ�� ������ �����̸� �ش�
        {
            isDelay = true;
            StartCoroutine("SetArrow");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //������ ���� �ֱ�
        if (other.gameObject.tag == "Mob")
        {
            Monster_Controller M = other.GetComponent<Monster_Controller>();
            InAreaMonster.Add(M);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mob")
        {
            Monster_Controller M = other.GetComponent<Monster_Controller>();
            if (M != null)//&& M.)M.Live -> �̰� �ۺ� ó���� �ȵǾ�����
            {
                InAreaMonster.Remove(M);

            }
        }
        
    }

    public Vector3 NearestMonster()
    {
        //��ü�Ÿ�
        FullDist_x = Mathf.Abs(GameObject.Find("dir2").transform.position.x - GameObject.Find("dir3").transform.position.x) * 4;
        FullDist_y = Mathf.Abs(GameObject.Find("dir1").transform.position.y - GameObject.Find("dir2").transform.position.y) * 4;
        FullDist = FullDist_x + FullDist_y + Mathf.Abs(GameObject.Find("StartPoint").transform.position.x - GameObject.Find("EndPoint").transform.position.x);

        Vector3 target;
        int idx = 0;

        if (InAreaMonster.Count == 0)
        {
            target = new Vector3(xpos, ypos, 0);
            return target;
        }

        for (int i = 0; i < InAreaMonster.Count; i++)
        {
            mobDist = InAreaMonster[i].dist;//���� �̵� �Ÿ�
            if (FullDist - mobDist < closeDist)//�� ���� �Ÿ�
            {
                idx = i;
            }
        }
        target = new Vector3(InAreaMonster[idx].xpos, InAreaMonster[idx].ypos, 0);
        return target;
    }
    void Attack()
    {

    }

    IEnumerator SetArrow()
    {
        //Debug.Log("ȭ�����");
        GameObject go = Instantiate(arrow);//ȭ�� ����(�Ű������� ������ ����),GameObject�� ���� �� ��ȯ
        go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        Vector3 point = NearestMonster();
        go.GetComponent<Projectile_Controller>().Shoot(point);
        yield return new WaitForSecondsRealtime(arrowSpeed);
        isDelay = false;
    }
}

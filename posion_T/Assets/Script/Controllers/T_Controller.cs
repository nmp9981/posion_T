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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //������ ���� �ֱ�
        Monster_Controller M = collision.GetComponent<Monster_Controller>();
        //if (M != null) print("Here");
        InAreaMonster.Add(M);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        //���� �ε��� ������ �ʿ���

        Monster_Controller M = collision.GetComponent<Monster_Controller>();
        if (M != null)//&& M.)M.Live -> �̰� �ۺ� ó���� �ȵǾ�����
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
        Debug.Log("ȭ�����");
        GameObject go = Instantiate(arrow);//ȭ�� ����(�Ű������� ������ ����),GameObject�� ���� �� ��ȯ
        go.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
        yield return new WaitForSecondsRealtime(arrowSpeed);
        isDelay = false;
    }
}

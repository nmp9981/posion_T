using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Controller : MonoBehaviour
{
    protected List<Monster_Controller> InAreaMonster;
    GameObject Projectile;
    [SerializeField]
    Define.Property property = Define.Property.Fire;

    // Start is called before the first frame update
    void Start()
    {
        InAreaMonster = new List<Monster_Controller>();
        Projectile = Resources.Load<GameObject>($"Prefabs/Projectile/Projectile{(int)property}");
        if (Projectile != null)
        {
            Instantiate(Projectile,transform);
        }
        



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster_Controller M = collision.GetComponent<Monster_Controller>();
        if (M != null )//&& M.)M.Live -> �̰� �ۺ� ó���� �ȵǾ�����
        {
            InAreaMonster.Add(M);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        //���� �ε��� ������ �ʿ���

        Monster_Controller M = collision.GetComponent<Monster_Controller>();
        if (M != null)//&& M.)M.Live -> �̰� �ۺ� ó���� �ȵǾ�����
        {
            InAreaMonster.Remove(M);

        }
    }
    
    void Attack()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

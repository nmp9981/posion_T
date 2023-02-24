using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Controller : MonoBehaviour
{
    List<GameObject> InAreaMonster;
    GameObject Projectile;
    [SerializeField]
    Define.Property property = Define.Property.Fire;

    // Start is called before the first frame update
    void Start()
    {
        InAreaMonster = new List<GameObject>();
        Projectile = Resources.Load<GameObject>($"Prefabs/Projectile/Projectile{(int)property}");
        if (Projectile != null)
        {
            Instantiate(Projectile,transform);
        }
        



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster_Controller M = collision.GetComponent<Monster_Controller>();
        if (M != null )//&& M.)M.Live -> 이게 퍼블릭 처리가 안되어있음
        {
            InAreaMonster.Add(collision.gameObject);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        //몬스터 인덱스 관리가 필요함

        Monster_Controller M = collision.GetComponent<Monster_Controller>();
        if (M != null)//&& M.)M.Live -> 이게 퍼블릭 처리가 안되어있음
        {
            InAreaMonster.Remove(M.gameObject);

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

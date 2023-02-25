using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Controller : MonoBehaviour
{
    float _proj_Dmg;
    float _proj_Spead;
    float _proj_Slow;

    Vector3 targetPos;//Ÿ�� ��ġ
    public float projSpeed;
    Vector3 Tpoint;//��ǥ ��ġ

    [SerializeField]
    Define.Property property = Define.Property.Fire;


    GameManager Target;

    public float Proj_Dmg { get { return _proj_Dmg; } set { _proj_Dmg = value; } }
    public float Proj_Spead { get { return _proj_Spead; } set { _proj_Spead = value; } }


    float GetSome()
    {
        return 1.0f;
    }
    public Define.Property ProjProp()
    {
        return property;
    }

    public float DMG(float some)
    {
        return Proj_Dmg * some;
    }

    public float Slow()
    {
        return _proj_Slow;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Mob")//���̶� ������ ������
        {
            Destroy(this.gameObject);
        }
    }
    public void setTarget(Vector3 point)
    {
        Tpoint = point;
    }
    public void Fly()
    {
        //GetComponent<Rigidbody2D>().AddForce(Tpoint);
        //transform.position = Vector3.MoveTowards(this.transform.position, Tpoint, speed);
        GetComponent<Rigidbody2D>().velocity = (Vector2)(Tpoint - this.transform.position).normalized * projSpeed;
    }

    // Start is called before the first frame update
    public void Shoot(Vector3 point,Vector3 startPos)//��ǥ ����, ���� ����
    {
        Target = new GameManager();
        gameObject.transform.LookAt(point);
        targetPos = point;
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Controller : MonoBehaviour
{
    [SerializeField]
    bool _live;
    float HP = 10;
    float DefaultSpead = 0.01f;
    public float xpos, ypos;
    float LRflag = 1;

    public float dist;
    [SerializeField]
    Define.Property _property = Define.Property.Fire;
    public Define.Property Property { get { return _property; } set { _property = value; } }
    public void beAttacked(float DMG, Define.Property Property) //������, ����ü �Ӽ�
    {
        //�Ӽ� �˻�
        if ((this._property == Define.Property.Fire && Property == Define.Property.Water) ||
            ((this._property == Define.Property.Water && Property == Define.Property.Grass)) ||
            (this._property == Define.Property.Grass && Property == Define.Property.Fire))//����
        {
            DMG *= 1.5f;
        }
        if ((this._property == Define.Property.Fire && Property == Define.Property.Grass) ||
            ((this._property == Define.Property.Water && Property == Define.Property.Fire)) ||
            (this._property == Define.Property.Grass && Property == Define.Property.Water))//�ݰ�
        {
            DMG *= 0.5f;
        }

        this.HP -= DMG;

        if (this.HP <= 0)//���
        {
            Invoke("Dead", 0);
        }
    }

    public bool Live { get { return _live; } set { _live = value; } }

    void OnCollisionEnter2D(Collision2D other)
    {
        //����ü�� ����
        if (other.gameObject.GetComponent<Projectile_Controller>().ProjProp() == _property)//����ü �Ӽ� = ���� �Ӽ�
        {
            Invoke("beAttacked", 0f);
        }
    }

    public void Dead()  //����
    {

        //GameManager.Resource.MonsterMove -= this.ThisMove;
        GameManager.Resource.Monster_List.Remove(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Resource.MonsterMove -= this.ThisMove;
        GameManager.Resource.MonsterMove += this.ThisMove;
    }

    float RealSpead(float plusMin)//���� �ӵ�
    {
        return DefaultSpead * plusMin;
    }

    void ThisMove()
    {
        xpos = this.gameObject.transform.position.x; ypos = this.gameObject.transform.position.y;

        if (Mathf.Abs(xpos) <= 1.51f && (Mathf.Abs(ypos) >= 3 || Mathf.Abs(ypos) <= 0.1f))//����������
        {
            LRflag = 1;
            this.gameObject.transform.Translate(this.DefaultSpead * LRflag, 0, 0);
        }
        else if (Mathf.Abs(xpos) <= 1.51f && Mathf.Abs(ypos) <= 1.55f && Mathf.Abs(ypos) >= 1.45f)//��������
        {
            LRflag = -1;
            this.gameObject.transform.Translate(this.DefaultSpead * LRflag, 0, 0);
        }
        else
        {
            if (LRflag == 1) this.gameObject.transform.position = new Vector3(1.5f, ypos, 0f);
            else if (LRflag == -1) this.gameObject.transform.position = new Vector3(-1.5f, ypos, 0f);
            this.gameObject.transform.Translate(0, -this.DefaultSpead, 0);//�Ʒ�
        }
        this.dist += this.DefaultSpead;

    }



}

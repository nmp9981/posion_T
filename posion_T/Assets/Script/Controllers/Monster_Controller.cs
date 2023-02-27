using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Controller : MonoBehaviour
{
    [SerializeField]
    bool _live = true;
    float _HP = 10;
    float DefaultSpead = 0.1f;
    public float xpos, ypos;
    Vector3[] direction = new Vector3[9];

    public float horizon = 1.5f;
    public float yzero = 0.1f;
    public float yEnd = 3.0f;   
    public bool Live { get { return _live; } set { _live = value; } }
    public float LifeTime;
    int checkBox = 0;
    public float dist;
    [SerializeField]
    Define.Property _property = Define.Property.Fire;
    public Define.Property Property { get { return _property; } set { _property = value; } }

    public float HP { get { return _HP;}set { _HP = value; } }

    public void beAttacked( Define.Property Property) //������, ����ü �Ӽ�
    {
        float DMG = GameManager.DMGTABLE[GameManager.LV[(int)Property]];
        

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
        Debug.Log("HP " + HP);
        if (this.HP <= 0)//���
        {
            _live = false;
            Invoke("Dead", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //����ü�� ����
        if (collision.gameObject.tag == "Arrow")
        {
            beAttacked(collision.gameObject.GetComponent<Projectile_Controller>().ProjProp());

        }
        //����ǥ�� �浹
        if (collision.gameObject.tag == "Dir")
        {
            checkBox++;
        }
    }
    
    

    public void Dead()  //����
    {
        if (!_live)
        {
            GameManager.NowPoint += 1;
        }
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Awake()
    {
        //Find�� ��� ���Ͱ� ������ ������ ����ϱ⿡�� �� ���ſ� + �ٲ�� OBJ�� �ƴ����� ���⿡�� ���� ã�� ������ x
        //Manager�� �ű�°��� �ո���

        
        direction = GameManager.Direction;

    }
    void Start()
    {
        HP = 10 * GameManager.Wave;

    }

    float RealSpead(float plusMin)//���� �ӵ�
    {
        return DefaultSpead * plusMin;
    }

    void ThisMove()
    {
        xpos = this.gameObject.transform.position.x; ypos = this.gameObject.transform.position.y;
        this.transform.position = Vector3.MoveTowards(this.transform.position, direction[checkBox], this.DefaultSpead);
        
      
        this.dist += this.DefaultSpead;

    }

    
    private void FixedUpdate()
    {
        LifeTime += Time.deltaTime;
        ThisMove();
    }

}

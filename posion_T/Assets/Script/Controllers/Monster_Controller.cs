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

    public void beAttacked( Define.Property Property) //데미지, 투사체 속성
    {
        float DMG = GameManager.DMGTABLE[GameManager.LV[(int)Property]];
        

        //속성 검사
        if ((this._property == Define.Property.Fire && Property == Define.Property.Water) ||
            ((this._property == Define.Property.Water && Property == Define.Property.Grass)) ||
            (this._property == Define.Property.Grass && Property == Define.Property.Fire))//증폭
        {
            
            DMG *= 1.5f;
        }
        if ((this._property == Define.Property.Fire && Property == Define.Property.Grass) ||
            ((this._property == Define.Property.Water && Property == Define.Property.Fire)) ||
            (this._property == Define.Property.Grass && Property == Define.Property.Water))//반감
        {
            DMG *= 0.5f;
        }

        this.HP -= DMG;
        Debug.Log("HP " + HP);
        if (this.HP <= 0)//사망
        {
            _live = false;
            Invoke("Dead", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //투사체에 맞음
        if (collision.gameObject.tag == "Arrow")
        {
            beAttacked(collision.gameObject.GetComponent<Projectile_Controller>().ProjProp());

        }
        //이정표와 충돌
        if (collision.gameObject.tag == "Dir")
        {
            checkBox++;
        }
    }
    
    

    public void Dead()  //죽음
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
        //Find는 모든 몬스터가 생성될 때마다 사용하기에는 좀 무거움 + 바뀌는 OBJ가 아님으로 여기에서 새로 찾을 이유가 x
        //Manager로 옮기는것이 합리적

        
        direction = GameManager.Direction;

    }
    void Start()
    {
        HP = 10 * GameManager.Wave;

    }

    float RealSpead(float plusMin)//실제 속도
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

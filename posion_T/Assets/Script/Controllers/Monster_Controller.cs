using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Controller : MonoBehaviour
{
    [SerializeField]
    bool _live = true;
    float _HP = 10;
    float DefaultSpead = 0.01f;
    public float xpos, ypos;
    public Vector3[] direction = new Vector3[9];

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

        GameManager.Resource.MonsterMove -= this.ThisMove;
        //GameManager.Resource.Monster_List.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Awake()
    {
        direction[0] = GameObject.Find("dir1").transform.position;
        direction[1] = GameObject.Find("dir2").transform.position;
        direction[2] = GameObject.Find("dir3").transform.position;
        direction[3] = GameObject.Find("dir4").transform.position;
        direction[4] = GameObject.Find("dir5").transform.position;
        direction[5] = GameObject.Find("dir6").transform.position;
        direction[6] = GameObject.Find("dir7").transform.position;
        direction[7] = GameObject.Find("dir8").transform.position;
        direction[8] = GameObject.Find("dir9").transform.position;

    }
    void Start()
    {
        GameManager.Resource.MonsterMove -= this.ThisMove;
        GameManager.Resource.MonsterMove += this.ThisMove;
        HP = GameManager.MonsterHP;

    }

    float RealSpead(float plusMin)//실제 속도
    {
        return DefaultSpead * plusMin;
    }

    void ThisMove()
    {
        xpos = this.gameObject.transform.position.x; ypos = this.gameObject.transform.position.y;
        this.transform.position = Vector3.MoveTowards(this.transform.position, direction[checkBox], this.DefaultSpead);
        
        /*
        if (Mathf.Abs(xpos) <= horizon && (Mathf.Abs(ypos) >= yEnd || Mathf.Abs(ypos) <= yzero))//오른쪽으로
        {
            LRflag = 1;
            this.gameObject.transform.Translate(this.DefaultSpead * LRflag, 0, 0);
        }
        else if (Mathf.Abs(xpos) <= horizon && Mathf.Abs(ypos) <= horizon+0.05f && Mathf.Abs(ypos) >= horizon-0.05f)//왼쪽으로
        {
            LRflag = -1;
            this.gameObject.transform.Translate(this.DefaultSpead * LRflag, 0, 0);
        }
        else
        {
            if (LRflag == 1) this.gameObject.transform.position = new Vector3(horizon, ypos, 0f);
            else if (LRflag == -1) this.gameObject.transform.position = new Vector3(-horizon, ypos, 0f);
            this.gameObject.transform.Translate(0, -this.DefaultSpead, 0);//아래
        }
        */
        this.dist += this.DefaultSpead;

    }

    
    private void Update()
    {
        LifeTime += Time.deltaTime;
        ThisMove();
    }

}

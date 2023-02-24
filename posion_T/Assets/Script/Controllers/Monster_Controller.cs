using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Controller : MonoBehaviour
{
    [SerializeField]
    bool Live;
    float HP = 10;
    float DefaultSpead = 0.01f;
    float xpos,ypos;
    float LRflag = 1;

    public void beAttacked(float DMG)   // ���� ����// ����ü�� this.transform.gameObject�� �浹���� �� ���
    {
        this.HP -=DMG;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Invoke("beAttacked", 0f);
    }

    public void Dead()  //����
    {
        
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
        xpos = this.gameObject.transform.position.x;ypos = this.gameObject.transform.position.y;

        if (Mathf.Abs(xpos)<=1.51f && (Mathf.Abs(ypos)>=3 || Mathf.Abs(ypos)<=0.1f))//����������
        {
            LRflag = 1;
            this.gameObject.transform.Translate(this.DefaultSpead * LRflag, 0, 0);
        }
        else if (Mathf.Abs(xpos) <= 1.51f && Mathf.Abs(ypos) <= 1.55f && Mathf.Abs(ypos) >= 1.45f)//��������
        {
            LRflag = -1;
            this.gameObject.transform.Translate(this.DefaultSpead*LRflag, 0, 0);
        }
        else
        {
            if (LRflag == 1) this.gameObject.transform.position = new Vector3(1.5f,ypos,0f);
            else if (LRflag == -1) this.gameObject.transform.position = new Vector3(-1.5f, ypos, 0f);
            this.gameObject.transform.Translate(0, -this.DefaultSpead, 0);//�Ʒ�
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    int explosionDamage = 300;
    float skillRange = 1.5f;//������
    List<GameObject> InArea = new List<GameObject>();

    
    // Start is called before the first frame update
    void Start()
    {
        InArea = gameObject.GetComponent<ResourceManager>().InAreaMonster_List;
    }

    //���� ����
    public void Explosion()
    {
        //����� ����Ѱ�?
        if(GameManager.Instance.Money >= GameManager.UPGRATECOST[GameManager.Instance.LV[2]])
        {
            GameManager.Instance.Money -= GameManager.UPGRATECOST[GameManager.Instance.LV[2]];

            //������ ���� ����
            for(int i=0;i<InArea.Count; i++)
            {
                
            }
            
        }
    }
}

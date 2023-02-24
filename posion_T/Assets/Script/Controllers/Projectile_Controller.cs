using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Controller : MonoBehaviour
{
    float _proj_Dmg;
    float _proj_Spead;
    float _proj_Slow;
    
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

    public void Fly(Vector3 point)//point == 단위백터
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Target = new GameManager();
    }

    // Update is called once per frame
    void Update()
    {
        //Fly();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Monster_Controller endOBJ = collision.GetComponent<Monster_Controller>();
            if (endOBJ.Live)
            {
                //    GameManager.Life -= 1;
            }
            GameManager.Life -= 1;


            collision.gameObject.GetComponent<Monster_Controller>().Dead();
            //Destroy(collision.gameObject.GetComponent<Monster_Controller>());
            Destroy(collision.gameObject);
            GameManager.UI.PointUpdate();
        }
    }
       
}

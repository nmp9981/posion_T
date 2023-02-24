using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Controller : MonoBehaviour
{

    private void move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.transform.position += new Vector3(0, 0.1f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Input.KeyAction -= move;

        GameManager.Input.KeyAction += move;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

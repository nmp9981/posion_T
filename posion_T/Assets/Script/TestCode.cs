using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (name == "Square")
        {
            Debug.Log("1. Square");
            num = 1;

            StartCoroutine(Dest());
        }
        else if (name == "Capsule")
        {
            Debug.Log("1. Capsule");
            num = 2;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("2. Enter " + name);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("4. Exit " + name);

    }
    IEnumerator Dest()
    {
        Debug.Log("3. Counting");
        yield return new WaitForSeconds(3);


        Destroy(this.gameObject);
        Debug.Log("5. bye");
        


    }
}
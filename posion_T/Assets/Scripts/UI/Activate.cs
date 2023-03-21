using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    [SerializeField]
    GameObject Obj;
    public void SetActiveTrue()
    {
        if (Obj != null)
            Obj.SetActive(true);
    }
    public void SetActiveFalse()
    {
        if (Obj != null)
            Obj.SetActive(false);
    }
}

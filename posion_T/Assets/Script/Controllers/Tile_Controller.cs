using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Controller : MonoBehaviour
{
    GameObject Tower;
    public void InstanceTower(Define.Property property)
    {

        Tower = Instantiate(GameManager.Tower[(int)property]);
        Tower.transform.parent = transform;

        Tower.transform.localPosition = new Vector3(0,0,0);
    }
    
}

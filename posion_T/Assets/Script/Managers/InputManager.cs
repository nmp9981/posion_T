using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager 
{
    public Action KeyAction = null;
    public void init()
    {
        //DeleteTowerButton = Re
    }
    public void OnUpdate()
    {
        //KeyAction.Invoke();
    }

    
    public GameObject GetClicked2DObject(int LayerMask)
    {
        GameObject target = null;


        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray2D ray = new Ray2D(pos, Vector2.zero);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, LayerMask);

        if (hit) //���콺 ��ó�� ������Ʈ�� �ִ��� Ȯ��
        {
            //������ ������Ʈ�� �����Ѵ�.
            target = hit.collider.gameObject;
        }
        return target;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using TMPro;
using System;

public class SkillButtonController : MonoBehaviour
{
    [SerializeField]
    Define.Skill MySkill = Define.Skill.Explosion;
    EventTrigger eventTrigger;

    GameObject UiImage;
    GameObject UiDragImage;

    GameObject ShowUpgradeMoney;

    readonly int[] _skillConst = new int[(int)Define.Skill.MaxCount];
    

    bool CanBuild = false;
    private void Start()
    {
        _skillConst[(int)Define.Skill.Explosion] = 20;
        _skillConst[(int)Define.Skill.Sticky] = 20;
        _skillConst[(int)Define.Skill.Nullity] = 20;
        
        UiDragImage = new GameObject();

        UiImage = Resources.Load<GameObject>($"Prefabs/UI/{System.Enum.GetName(typeof(Define.Skill), MySkill)}_Drag_UI");
        
        ShowUpgradeMoney = transform.Find($"{transform.name} Plus").gameObject;

        eventTrigger = gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry_PointerDown = new EventTrigger.Entry();
        entry_PointerDown.eventID = EventTriggerType.PointerDown;
        entry_PointerDown.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerDown);

        EventTrigger.Entry entry_Drag = new EventTrigger.Entry();
        entry_Drag.eventID = EventTriggerType.Drag;
        entry_Drag.callback.AddListener((data) => { OnDrag((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_Drag);

        EventTrigger.Entry Begin_Drag = new EventTrigger.Entry();
        Begin_Drag.eventID = EventTriggerType.BeginDrag;
        Begin_Drag.callback.AddListener((data) => { OnBeginDrag((PointerEventData)data); });
        eventTrigger.triggers.Add(Begin_Drag);


        EventTrigger.Entry entry_EndDrag = new EventTrigger.Entry();
        entry_EndDrag.eventID = EventTriggerType.EndDrag;
        entry_EndDrag.callback.AddListener((data) => { OnEndDrag((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_EndDrag);

        EventTrigger.Entry entry_Click = new EventTrigger.Entry();
        entry_Click.eventID = EventTriggerType.PointerClick;
        entry_Click.callback.AddListener((data) => { PointerClick((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_Click);


    }
    public GameObject GetClicked2DObject()
    {
        GameObject target = null;


        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray2D ray = new Ray2D(pos, Vector2.zero);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, (1 << 7) + (1 << 8));

        if (hit) //마우스 근처에 오브젝트가 있는지 확인
        {
            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject;
        }
        return target;
    }
    void OnPointerDown(PointerEventData data)
    {


    }
    void OnBeginDrag(PointerEventData data)
    {
        if (GameManager.Money >= _skillConst[(int)MySkill])
        {
            UiDragImage = Instantiate(UiImage, this.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
            CanBuild = true;
        }
    }
    void OnDrag(PointerEventData data)
    {
        UiDragImage.transform.position = data.position;
    }

    void OnEndDrag(PointerEventData data)
    {
        if (UiDragImage != null)
        {
            Destroy(UiDragImage);
        }
        
        UiDragImage = new GameObject();
        
        if (CanBuild)
        {
            GameObject tile = GameManager.Input.GetClicked2DObject(((1 << 7) + (1 << 8 )));

            if (tile != null && (GameManager.Money >= _skillConst[(int)MySkill]))
            {
                GameManager.Money -= _skillConst[(int)MySkill];
                GameManager.UI.PointUpdate();
                tile.GetComponent<Tile_Controller>().InstanceSkill(MySkill);
                GameManager.Sound.Play("Effect/button2");


            }

        }
        CanBuild = false;


    }

    void PointerClick(PointerEventData data)
    {
        Debug.Log("Plus 키");

        ShowUpgradeMoney.gameObject.SetActive(true);

    }



}

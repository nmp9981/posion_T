using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ButtonController : MonoBehaviour
{
    [SerializeField]
    Define.Property MyProperty = Define.Property.Fire;
    EventTrigger eventTrigger;
    EventTrigger eventTriggerPlus;

    GameObject UiImage;
    

    GameObject UiDragImage;
    private void Start()
    {
        UiDragImage = new GameObject();
        UiImage = Resources.Load<GameObject>($"Prefabs/UI/{System.Enum.GetName(typeof(Define.Property), MyProperty)}T_Drag_UI");

        
        if (!transform.name.Contains("Plus"))
        {
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

        else
        {// puls

            eventTriggerPlus = gameObject.GetComponent<EventTrigger>();
            EventTrigger.Entry entry_PointerDown_Plus = new EventTrigger.Entry();
            entry_PointerDown_Plus.eventID = EventTriggerType.PointerDown;
            entry_PointerDown_Plus.callback.AddListener((data) => { OnPointerDown_Plus((PointerEventData)data); });
            eventTriggerPlus.triggers.Add(entry_PointerDown_Plus);

            EventTrigger.Entry entry_Drag_Plus = new EventTrigger.Entry();
            entry_Drag_Plus.eventID = EventTriggerType.Drag;
            entry_Drag_Plus.callback.AddListener((data) => { OnDrag_Plus((PointerEventData)data); });
            eventTriggerPlus.triggers.Add(entry_Drag_Plus);

            EventTrigger.Entry entry_EndDrag_Plus = new EventTrigger.Entry();
            entry_EndDrag_Plus.eventID = EventTriggerType.EndDrag;
            entry_EndDrag_Plus.callback.AddListener((data) => { OnEndDrag_Plus((PointerEventData)data); });
            eventTriggerPlus.triggers.Add(entry_EndDrag_Plus);

            EventTrigger.Entry entry_Click_Plus = new EventTrigger.Entry();
            entry_Click_Plus.eventID = EventTriggerType.PointerClick;
            entry_Click_Plus.callback.AddListener((data) => { PointerClick_Plus((PointerEventData)data); });
            eventTriggerPlus.triggers.Add(entry_Click_Plus);
        }
    }
    public GameObject GetClicked2DObject()
    {
        GameObject target = null;

        
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray2D ray = new Ray2D(pos, Vector2.zero);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit) //마우스 근처에 오브젝트가 있는지 확인
        {
            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject;
        }
        return target;
    }
    void OnPointerDown(PointerEventData data)
    {
        //Debug.Log("Pointer Down");
        //UiImage = Instantiate()
    }
    void OnBeginDrag(PointerEventData data)
    {
        UiDragImage = Instantiate(UiImage, this.transform.position , Quaternion.identity, GameObject.Find("Canvas").transform);
    }
    void OnDrag(PointerEventData data)
    {
        //Debug.Log("이미지 끌고다니기");
        UiDragImage.transform.position = data.position; 
    }

    void OnEndDrag(PointerEventData data)
    {
        Debug.Log("RayCastTower");
        Destroy(UiDragImage);
        UiDragImage = new GameObject();
        if (GetClicked2DObject() == null)
        {
            Debug.Log("여기부터 널");
        }
        else
        {
            Debug.Log(GetClicked2DObject().name);

        }
        //Instantiate(UiImage, this.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        GetClicked2DObject().GetComponent<Tile_Controller>().InstanceTower(MyProperty);

    }

    void PointerClick(PointerEventData data)
    {
        Debug.Log("Plus 키");
    }



    //plus


    void OnPointerDown_Plus(PointerEventData data)
    {
        //Debug.Log("Pointer Down");
    }

    void OnDrag_Plus(PointerEventData data)
    {
        Debug.Log("Plus이미지 끌고다니기");
    }

    void OnEndDrag_Plus(PointerEventData data)
    {
        Debug.Log("PlusRayCastTower");
    }

    void PointerClick_Plus(PointerEventData data)
    {
        Debug.Log("Plus Plus 키");
    }
}

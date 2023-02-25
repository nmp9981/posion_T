using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
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
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity,1<<7);

        if (hit) //마우스 근처에 오브젝트가 있는지 확인
        {
            //있으면 오브젝트를 저장한다.
            target = hit.collider.gameObject;
        }
        return target;
    }
    void OnPointerDown(PointerEventData data)
    {
        //GameManger.Sound

        
    }
    void OnBeginDrag(PointerEventData data)
    {
        if (GameManager.Money >= 10)
        {
            UiDragImage = Instantiate(UiImage, this.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        }
    }
    void OnDrag(PointerEventData data)
    {
        //Debug.Log("이미지 끌고다니기");
        UiDragImage.transform.position = data.position; 
    }

    void OnEndDrag(PointerEventData data)
    {
        Destroy(UiDragImage);
        UiDragImage = new GameObject();
        GameObject tile = GetClicked2DObject();
        if (tile != null)
        {
            GameManager.Money -= 10;
            tile.GetComponent<Tile_Controller>().InstanceTower(MyProperty);

        }
        else
        {

        }

    }

    void PointerClick(PointerEventData data)
    {
        Debug.Log("Plus 키");
        if (transform.GetChild(0).gameObject != null)
        {
            transform.GetChild(0).gameObject.SetActive(true);

        }
    }



    //plus


    void OnPointerDown_Plus(PointerEventData data)
    {
        
    }

    void OnDrag_Plus(PointerEventData data)
    {
        //Debug.Log("Plus이미지 끌고다니기"); 
        if (transform.GetChild(0).gameObject != null)
        {
            Debug.Log("취소");
            transform.GetChild(0).gameObject.SetActive(false);

        }
    }

    void OnEndDrag_Plus(PointerEventData data)
    {
        Debug.Log("PlusRayCastTower");
    }

    void PointerClick_Plus(PointerEventData data)
    {
        //Debug.Log("Plus Plus 키");
        if (transform.GetChild(0).gameObject != null)
        {
            Debug.Log("업그레이드");
            transform.GetChild(0).gameObject.SetActive(false);

        }
    }
}

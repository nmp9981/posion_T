using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using TMPro;


public class TowerButtonController : MonoBehaviour
{
    [SerializeField]
    Define.Property MyProperty = Define.Property.Fire;
    EventTrigger eventTrigger;
    
    GameObject UiImage;
    GameObject UiDragImage;
    
    GameObject ShowUpgradeMoney;
    bool CanBuild = false;
    private void Start()
    {
        UiDragImage = new GameObject();
        UiImage = Resources.Load<GameObject>($"Prefabs/UI/{System.Enum.GetName(typeof(Define.Property), MyProperty)}T_Drag_UI");

        ShowUpgradeMoney = new GameObject();

        
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
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, 1 << 7);

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
        if (GameManager.Money >= 20)
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
        Destroy(UiDragImage);
        UiDragImage = new GameObject();
        if (CanBuild)
        {
            GameObject tile = GetClicked2DObject();
            if (tile != null && (GameManager.Money >= 20))
            {
                if (tile.transform.childCount == 0) {
                    GameManager.Money -= 20;
                    GameManager.UI.PointUpdate();
                    tile.GetComponent<Tile_Controller>().InstanceTower(MyProperty);
                    GameManager.Sound.Play("Effect/button2");
                }
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

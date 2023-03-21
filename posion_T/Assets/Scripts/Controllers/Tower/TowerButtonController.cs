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

        ShowUpgradeMoney = transform.Find($"{transform.name}_Plus").gameObject;

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
            GameObject tile = GameManager.Input.GetClicked2DObject(1<<7);
            if (tile != null && (GameManager.Money >= 20))
            {
                if (tile.transform.GetComponent<Tile_Controller>().TowerNum== 0) {
                    tile.transform.GetComponent<Tile_Controller>().TowerNum += 1;
                    GameManager.Money -= 20;
                    GameManager.UI.PointUpdate();
                    tile.GetComponent<Tile_Controller>().InstanceTower(MyProperty);
                    GameManager.Sound.Play("Effect/tower_getto_daze");
                }
            }
        }
        CanBuild = false;
    }

    void PointerClick(PointerEventData data)
    {
        if (GameManager.LV[(int)MyProperty] < 4)
        {
            GameManager.Sound.Play("Effect/button2");

            ShowUpgradeMoney.gameObject.SetActive(true);
        }
        
    }

    

}

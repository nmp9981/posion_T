using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using TMPro;


public class TowerUpgradeController : MonoBehaviour
{
    [SerializeField]
    Define.Property MyProperty = Define.Property.Fire;
    EventTrigger eventTrigger;

    GameObject UiImage;
    GameObject UiDragImage;


    GameObject LVImage;
    TextMeshProUGUI ShowUpgradeMoneyText;

    private void Start()
    {
        UiDragImage = new GameObject();
        UiImage = Resources.Load<GameObject>($"Prefabs/UI/{System.Enum.GetName(typeof(Define.Property), MyProperty)}T_Drag_UI");

        ShowUpgradeMoneyText = new TextMeshProUGUI();
        LVImage = transform.parent.transform.Find($"{transform.parent.name}LV").gameObject;
        if (LVImage == null)
        {
            Debug.Log($"{transform.name} : cant find LV:  {transform.parent.name}LV");
        }
        ShowUpgradeMoneyText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        ShowUpgradeMoneyText.text = $"{GameManager.UPGRATECOST[GameManager.LV[(int)MyProperty]]}";

        Debug.Log(ShowUpgradeMoneyText.name);


        eventTrigger = gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry_PointerDown_Plus = new EventTrigger.Entry();
        entry_PointerDown_Plus.eventID = EventTriggerType.PointerDown;
        entry_PointerDown_Plus.callback.AddListener((data) => { OnPointerDown_Plus((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerDown_Plus);

        EventTrigger.Entry entry_Drag_Plus = new EventTrigger.Entry();
        entry_Drag_Plus.eventID = EventTriggerType.Drag;
        entry_Drag_Plus.callback.AddListener((data) => { OnDrag_Plus((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_Drag_Plus);

        EventTrigger.Entry entry_EndDrag_Plus = new EventTrigger.Entry();
        entry_EndDrag_Plus.eventID = EventTriggerType.EndDrag;
        entry_EndDrag_Plus.callback.AddListener((data) => { OnEndDrag_Plus((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_EndDrag_Plus);

        EventTrigger.Entry entry_Click_Plus = new EventTrigger.Entry();
        entry_Click_Plus.eventID = EventTriggerType.PointerClick;
        entry_Click_Plus.callback.AddListener((data) => { PointerClick_Plus((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_Click_Plus);
    
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
    
    void OnPointerDown_Plus(PointerEventData data)
    {

    }

    void OnDrag_Plus(PointerEventData data)
    {

    }

    void OnEndDrag_Plus(PointerEventData data)
    {
        Debug.Log("PlusRayCastTower");
        gameObject.SetActive(false);

    }

    void PointerClick_Plus(PointerEventData data)
    {

        if (GameManager.LV[(int)MyProperty] < 5 && (GameManager.Money >= GameManager.UPGRATECOST[GameManager.LV[(int)MyProperty]]))
        {
            GameManager.Money -= GameManager.UPGRATECOST[GameManager.LV[(int)MyProperty]];
            GameManager.LV[(int)MyProperty] += 1;

            GameManager.UI.PointUpdate();

            LVImage.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprite/UI/9_LV{GameManager.LV[(int)MyProperty] + 1}");
            ShowUpgradeMoneyText.text = $"{GameManager.UPGRATECOST[GameManager.LV[(int)MyProperty]]}";

            gameObject.SetActive(false);
        }

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(pos, Vector2.zero);
            RaycastHit2D hit;
            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            if (hit) //마우스 근처에 오브젝트가 있는지 확인
            {
                //있으면 오브젝트를 저장한다.
                if(hit.collider.gameObject != gameObject)
                {
                    gameObject.SetActive(false);
                    Debug.Log(gameObject.name + " 비활성화");
                }
            }
            
        }
    }
}


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

        EventTrigger.Entry entry_PointerExit_Plus = new EventTrigger.Entry();
        entry_PointerExit_Plus.eventID = EventTriggerType.PointerExit;
        entry_PointerExit_Plus.callback.AddListener((data) => { PointerExit_Plus((PointerEventData)data); });
        eventTrigger.triggers.Add(entry_PointerExit_Plus);

    }
    
    void OnPointerDown_Plus(PointerEventData data)
    {

        if (GameManager.LV[(int)MyProperty] < 4 && (GameManager.Money >= GameManager.UPGRATECOST[GameManager.LV[(int)MyProperty]]))
        {
            GameManager.Sound.Play("Effect/levelup1");

            GameManager.Money -= GameManager.UPGRATECOST[GameManager.LV[(int)MyProperty]];
            GameManager.LV[(int)MyProperty] += 1;

            GameManager.UI.PointUpdate();

            LVImage.GetComponent<Image>().sprite = GameManager.UI.LVImage[GameManager.LV[(int)MyProperty]]; // 
            ShowUpgradeMoneyText.text = $"{GameManager.UPGRATECOST[GameManager.LV[(int)MyProperty]]}";

            gameObject.SetActive(false);
        }
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

        Debug.Log("PointerClick");
        /*
        if (GameManager.LV[(int)MyProperty] < 4 && (GameManager.Money >= GameManager.UPGRATECOST[GameManager.LV[(int)MyProperty]]))
        {
            GameManager.Money -= GameManager.UPGRATECOST[GameManager.LV[(int)MyProperty]];
            GameManager.LV[(int)MyProperty] += 1;

            GameManager.UI.PointUpdate();

            LVImage.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprite/UI/9_LV{GameManager.LV[(int)MyProperty] + 1}");
            ShowUpgradeMoneyText.text = $"{GameManager.UPGRATECOST[GameManager.LV[(int)MyProperty]]}";

            gameObject.SetActive(false);
        }
        */
    }

    void PointerExit_Plus(PointerEventData data)
    {
        //gameObject.SetActive(false);

    }
    
}

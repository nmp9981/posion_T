using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using TMPro;


public class SkillUpgradeController : MonoBehaviour

{
    [SerializeField]
    Define.Skill MySkill = Define.Skill.Explosion;
    EventTrigger eventTrigger;

    GameObject UiImage;
    GameObject UiDragImage;


    GameObject LVImage;
    TextMeshProUGUI ShowUpgradeMoneyText;

    private void Start()
    {
        UiDragImage = new GameObject();
        UiImage = Resources.Load<GameObject>($"Prefabs/UI/{System.Enum.GetName(typeof(Define.Skill), MySkill)}_Drag_UI");

        ShowUpgradeMoneyText = new TextMeshProUGUI();
        LVImage = transform.parent.transform.Find($"{transform.parent.name}LV").gameObject;
        if (LVImage == null)
        {
            Debug.Log($"{transform.name} : cant find LV:  {transform.parent.name}LV");
        }
        ShowUpgradeMoneyText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        ShowUpgradeMoneyText.text = $"{GameManager.UPGRATECOST[GameManager.LV[(int)MySkill]]}";

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
        Debug.Log("InSkillUpgrade");
        int SkillToLv = (int)MySkill + 5;
        if (GameManager.LV[SkillToLv] < 4 && (GameManager.Money >= GameManager.UPGRATECOST[GameManager.LV[SkillToLv]]))
        {
            GameManager.Money -= GameManager.UPGRATECOST[GameManager.LV[SkillToLv]];
            GameManager.LV[SkillToLv] += 1;

            GameManager.UI.PointUpdate();

            LVImage.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprite/UI/9_LV{GameManager.LV[SkillToLv] + 1}");
            ShowUpgradeMoneyText.text = $"{GameManager.UPGRATECOST[GameManager.LV[SkillToLv]]}";

            gameObject.SetActive(false);
        }

    }
    
}


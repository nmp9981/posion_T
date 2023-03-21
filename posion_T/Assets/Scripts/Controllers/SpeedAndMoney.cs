using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedAndMoney : MonoBehaviour
{
    [SerializeField]
    GameObject LVImage;

    TextMeshProUGUI ShowUpgradeMoneyText;

    private void Start()
    {
        ShowUpgradeMoneyText = transform.Find("NeedMoney").GetComponent<TextMeshProUGUI>();
    }
    public void UpgradeMoneyGet()
    {

        if (GameManager.LV[(int)Define.LV.MoneyGet] < 4 && (GameManager.Money >= GameManager.UPGRATECOST[GameManager.LV[(int)Define.LV.MoneyGet]]))
        {
            GameManager.Sound.Play("Effect/levelup1");

            GameManager.Money -= GameManager.UPGRATECOST[GameManager.LV[(int)Define.LV.MoneyGet]];
            GameManager.LV[(int)Define.LV.MoneyGet] += 1;

            GameManager.UI.PointUpdate();

            LVImage.GetComponent<Image>().sprite = GameManager.UI.LVImage[GameManager.LV[(int)Define.LV.MoneyGet]]; // 
            ShowUpgradeMoneyText.text = $"{GameManager.UPGRATECOST[GameManager.LV[(int)Define.LV.MoneyGet]]}";

            gameObject.SetActive(false);
        }
    }

    public void UpgradeShootSpeed()
    {
        if (GameManager.LV[(int)Define.LV.ShootSpeed] < 4 && (GameManager.Money >= GameManager.UPGRATECOST[GameManager.LV[(int)Define.LV.ShootSpeed]]))
        {
            GameManager.Sound.Play("Effect/levelup1");

            GameManager.Money -= GameManager.UPGRATECOST[GameManager.LV[(int)Define.LV.ShootSpeed]];
            GameManager.LV[(int)Define.LV.ShootSpeed] += 1;

            GameManager.UI.PointUpdate();

            LVImage.GetComponent<Image>().sprite = GameManager.UI.LVImage[GameManager.LV[(int)Define.LV.ShootSpeed]]; // 
            ShowUpgradeMoneyText.text = $"{GameManager.UPGRATECOST[GameManager.LV[(int)Define.LV.ShootSpeed]]}";

            gameObject.SetActive(false);
        }
    }
}

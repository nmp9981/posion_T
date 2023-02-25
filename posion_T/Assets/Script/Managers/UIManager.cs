using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager 
{
    //TextMeshProUGUI _maxPoint = new TextMeshProUGUI();
    //TextMeshProUGUI _nowPoint = new TextMeshProUGUI();
    TextMeshProUGUI _lifePoint = new TextMeshProUGUI();
    TextMeshProUGUI _moneyPoint = new TextMeshProUGUI();

    //TextMeshProUGUI _LVPoint = new TextMeshProUGUI();

    //public TextMeshProUGUI MaxPoint {get  { return _maxPoint; } set { _maxPoint = value; }}
    //public TextMeshProUGUI NowPoint { get { return _nowPoint; } set { _nowPoint = value; } }
    public TextMeshProUGUI LifePoint { get { return _lifePoint; } set { _lifePoint = value; } }
    //public TextMeshProUGUI LVPoint { get { return _LVPoint; } set { _LVPoint = value; } }
    public TextMeshProUGUI MoneyPoint { get { return _moneyPoint; } set { _moneyPoint = value; } }

    public void init()
    {
        //_maxPoint = GameObject.Find("MaxPoint").GetComponent<TextMeshProUGUI>();
        //_nowPoint = GameObject.Find("NowPoint").GetComponent<TextMeshProUGUI>();
        _lifePoint = GameObject.Find("LifePoint").GetComponent<TextMeshProUGUI>();
        //_LVPoint = GameObject.Find("LVPoint").GetComponent<TextMeshProUGUI>();
        _moneyPoint = GameObject.Find("MoneyPoint").GetComponent<TextMeshProUGUI>();

        GameManager.UI.PointUpdate();
    }
    public void PointUpdate()
    {
        //GameManager.UI.MaxPoint.text = "����: " + GameManager.MaxPoint;
        //GameManager.UI.NowPoint.text = "����: " + GameManager.NowPoint;
        GameManager.UI.LifePoint.text = "������: " + GameManager.Life;
        //GameManager.UI.LVPoint.text = $"��: {(int)GameManager.LV[(int)Define.Property.Fire]} ��: {(int)GameManager.LV[(int)Define.Property.Water]} Ǯ: {(int)GameManager.LV[(int)Define.Property.Grass]}   ";
        GameManager.UI.MoneyPoint.text = $"{(int)GameManager.Money}��";

    }

}

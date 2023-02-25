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
        //GameManager.UI.MaxPoint.text = "고점: " + GameManager.MaxPoint;
        //GameManager.UI.NowPoint.text = "지금: " + GameManager.NowPoint;
        GameManager.UI.LifePoint.text = "라이프: " + GameManager.Life;
        //GameManager.UI.LVPoint.text = $"불: {(int)GameManager.LV[(int)Define.Property.Fire]} 물: {(int)GameManager.LV[(int)Define.Property.Water]} 풀: {(int)GameManager.LV[(int)Define.Property.Grass]}   ";
        GameManager.UI.MoneyPoint.text = $"{(int)GameManager.Money}원";

    }

}

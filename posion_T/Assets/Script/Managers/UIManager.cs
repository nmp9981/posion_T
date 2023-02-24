using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager 
{
    TextMeshProUGUI _maxPoint = new TextMeshProUGUI();
    TextMeshProUGUI _nowPoint = new TextMeshProUGUI();
    TextMeshProUGUI _lifePoint = new TextMeshProUGUI();


    public TextMeshProUGUI MaxPoint {get  { return _maxPoint; } set { _maxPoint = value; }}
    public TextMeshProUGUI NowPoint { get { return _nowPoint; } set { _nowPoint = value; } }
    public TextMeshProUGUI LifePoint { get { return _lifePoint; } set { _nowPoint = value; } }

    public void init()
    {
        _maxPoint = GameObject.Find("MaxPoint").GetComponent<TextMeshProUGUI>();
        _nowPoint = GameObject.Find("NowPoint").GetComponent<TextMeshProUGUI>();
        _lifePoint = GameObject.Find("LifePoint").GetComponent<TextMeshProUGUI>();
        GameManager.UI.PointUpdate();
    }
    public void PointUpdate()
    {
        GameManager.UI.MaxPoint.text = "고점: " + GameManager.MaxPoint;
        GameManager.UI.NowPoint.text = "지금: " + GameManager.NowPoint;
        GameManager.UI.LifePoint.text = "라이프: " + GameManager.Life;



    }

}

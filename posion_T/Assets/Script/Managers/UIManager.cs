using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager 
{
    TextMeshProUGUI _wavePoint = new TextMeshProUGUI();
    TextMeshProUGUI _moneyPoint = new TextMeshProUGUI();
    TextMeshProUGUI _maxPoint = new TextMeshProUGUI();
    TextMeshProUGUI _nowPoint = new TextMeshProUGUI();

    TextMeshProUGUI _wavePointEnd = new TextMeshProUGUI();
    TextMeshProUGUI _maxPointEnd = new TextMeshProUGUI();
    TextMeshProUGUI _nowPointEnd = new TextMeshProUGUI();

    GameObject[] lifeArray = new GameObject[5];
    GameObject GameOverScene;
    GameObject _mainScene;
    Sprite FullLife;
    Sprite emptyLife;
    readonly int FULLLIFE = 5;


    public TextMeshProUGUI WavePoint { get { return _wavePoint; } set { _wavePoint = value; } }
    public TextMeshProUGUI MoneyPoint { get { return _moneyPoint; } set { _moneyPoint = value; } }
    public TextMeshProUGUI MaxPoint { get { return _maxPoint; } set { _maxPoint = value; } }
    public TextMeshProUGUI NowPoint { get { return _nowPoint; } set { _nowPoint = value; } }
    public GameObject MainScene { get { return _mainScene; } set { _mainScene = value; } }
    int idx = 0;
    public void init()
    {
        _maxPoint = GameObject.Find("MaxPoint").GetComponent<TextMeshProUGUI>();
        _nowPoint = GameObject.Find("NowPoint").GetComponent<TextMeshProUGUI>();
        _wavePoint = GameObject.Find("WavePoint").GetComponent<TextMeshProUGUI>();
        _moneyPoint = GameObject.Find("MoneyPoint").GetComponent<TextMeshProUGUI>();
        GameOverScene = GameObject.Find("GameOver").gameObject;

        _mainScene = GameObject.Find("MainPage").gameObject;
        
        _wavePointEnd = GameOverScene.transform.Find("WaveEnd").GetComponent<TextMeshProUGUI>();
        _nowPointEnd = GameOverScene.transform.Find("NowScoreEnd").GetComponent<TextMeshProUGUI>();
        _maxPointEnd = GameOverScene.transform.Find("BestScoreEnd").GetComponent<TextMeshProUGUI>();
        
        FullLife = Resources.Load<Sprite>("Sprite/UI/3_체력O");
        emptyLife = Resources.Load<Sprite>("Sprite/UI/3_체력X");

        

        for (int i = 0; i < 5; i++)
        {
            lifeArray[i] = GameObject.Find($"Life{i+1}").gameObject;
        }
        GameOverScene.SetActive(false);
        GameManager.UI.PointUpdate();

    }
    public void PointUpdate()
    {
        //GameManager.UI.LifePoint.text = "라이프: " + GameManager.Life;
        _wavePoint.text = $"{GameManager.Wave} WAVE";
        _nowPoint.text = $"SCORE: {GameManager.NowPoint}";
        _maxPoint.text = $"BEST SCORE: {GameManager.MaxPoint}";
        GameManager.UI.MoneyPoint.text = $"{(int)GameManager.Money}원";
        HPBar();

    }
    void HPBar()
    {
        for (int i = 0; i < GameManager.Life; i++)
        {
            lifeArray[i].GetComponent<Image>().sprite = FullLife;
        }
        for (int i = GameManager.Life; i < FULLLIFE; i++)
        {
            lifeArray[i].GetComponent<Image>().sprite = emptyLife;
        }

    }

    public void GameOverUI()
    {
        GameOverScene.SetActive(true);

        _wavePointEnd.text = $"{GameManager.Wave} WAVE";
        _nowPointEnd.text = $"SCORE: {GameManager.NowPoint}";
        _maxPointEnd.text = $"BEST SCORE: {GameManager.MaxPoint}";

    }

    public void ReLoadScene()
    {
        SceneManager.LoadScene(GameManager.SCENENAME);
        Object.Destroy(GameManager.Instance.gameObject);
        
    }

    public void GameStart()
    {
        GameManager.Instance.UnPauseTime();
        _mainScene.SetActive(false);

    }
    public void MainPageOff()
    {
        _mainScene.SetActive(false);

    }
}

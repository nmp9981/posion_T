using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInfo : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[5];
    public int nowScore;
    int maxScore;
    int life;
    public int wave;

    public GameObject scoreText;
    public GameObject bestTect;

    public TextMeshProUGUI Score;
    public TextMeshProUGUI BestScore;

    bool isSave;//����� �����Ͱ� �ִ°�?

    private void Awake()
    {

        Debug.Log("????");
        Score = GameObject.Find("NowPoint").GetComponent<TextMeshProUGUI>();
        BestScore = GameObject.Find("MaxPoint").GetComponent<TextMeshProUGUI>();

        if (!isSave)
        {
            maxScore = 0;
        }
        else
        {
            maxScore = PlayerPrefs.GetInt("maxi");
        }
        userInit();
    }
    //�ʱ�ȭ
    private void userInit()
    {
        nowScore = 0;
        life = 5;
        wave = 1;

        lifeArray[0] = GameObject.Find("c1");
        lifeArray[1] = GameObject.Find("c2");
        lifeArray[2] = GameObject.Find("c3");
        lifeArray[3] = GameObject.Find("c4");
        lifeArray[4] = GameObject.Find("c5");
    }
    //���� ȹ��
    public void getScore()
    {
        nowScore += 1;
        //Debug.Log(nowScore);
    }
    //HP����
    public void LoseHP()
    {
        life -= 1;
    }
    void HPBar()
    {
        if (life == 5)
        {
            lifeArray[0].SetActive(true);
            lifeArray[1].SetActive(true);
            lifeArray[2].SetActive(true);
            lifeArray[3].SetActive(true);
            lifeArray[4].SetActive(true);
        }else if(life == 4)
        {
            lifeArray[0].SetActive(true);
            lifeArray[1].SetActive(true);
            lifeArray[2].SetActive(true);
            lifeArray[3].SetActive(true);
            lifeArray[4].SetActive(false);
        }
        else if (life == 3)
        {
            lifeArray[0].SetActive(true);
            lifeArray[1].SetActive(true);
            lifeArray[2].SetActive(true);
            lifeArray[3].SetActive(false);
            lifeArray[4].SetActive(false);
        }
        else if (life == 2)
        {
            lifeArray[0].SetActive(true);
            lifeArray[1].SetActive(true);
            lifeArray[2].SetActive(false);
            lifeArray[3].SetActive(false);
            lifeArray[4].SetActive(false);
        }
        else if (life == 1)
        {
            lifeArray[0].SetActive(true);
            lifeArray[1].SetActive(false);
            lifeArray[2].SetActive(false);
            lifeArray[3].SetActive(false);
            lifeArray[4].SetActive(false);
        }
        else if (life == 0)
        {
            lifeArray[0].SetActive(false);
            lifeArray[1].SetActive(false);
            lifeArray[2].SetActive(false);
            lifeArray[3].SetActive(false);
            lifeArray[4].SetActive(false);
        }
    }
    void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = nowScore.ToString();
        bestTect.GetComponent<TextMeshProUGUI>().text = bestTect.ToString();
        Score.text = "SCORE : " + nowScore.ToString();
        BestScore.text = "BEST : " + maxScore.ToString();
        HPBar();//hp��
        if (maxScore < nowScore)//����
        {
           
            PlayerPrefs.SetFloat("maxi", maxScore);
            PlayerPrefs.Save();
        }
    }
    
}

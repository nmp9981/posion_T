using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // ���� �۾����� ����Ƽ ����
    
    static GameManager _instance;
    DataManager _dataManager = new DataManager();
    InputManager _inputManager = new InputManager();
    SoundManager _soundManager = new SoundManager();
    ResourceManager _resourceManager = new ResourceManager();
    UIManager _uIManager = new UIManager();
    
    public static GameManager Instance { get { init(); return _instance; } }
    public static InputManager Input { get { return Instance._inputManager; } }
    public static DataManager Data { get { return Instance._dataManager; } }
    public static SoundManager Sound { get { return Instance._soundManager; } }

    public static ResourceManager Resource { get { return Instance._resourceManager; } }
    public static UIManager UI { get { return Instance._uIManager; } }


    static void init()
    {

        if (_instance == null)
        {

            GameObject gm = GameObject.Find("GameManager");
            if(gm == null)
            {
                gm = new GameObject { name = "GameManager" };
                
                gm.AddComponent<GameManager>();
            }
            DontDestroyOnLoad(gm);
            _instance = gm.GetComponent<GameManager>();
            _instance._soundManager.init();

            _instance._uIManager.init();

            _instance._Tower = new GameObject[3];
            _instance._Tower[(int)Define.Property.Fire] = Resources.Load<GameObject>($"Prefabs/Tower/Tower{(int)Define.Property.Fire}");
            _instance._Tower[(int)Define.Property.Water] = Resources.Load<GameObject>($"Prefabs/Tower/Tower{(int)Define.Property.Water}");
            _instance._Tower[(int)Define.Property.Grass] = Resources.Load<GameObject>($"Prefabs/Tower/Tower{(int)Define.Property.Grass}");

            for(int i=0;i<9; i++)
            {
                _instance._direction[i] = GameObject.Find($"dir{i+1}").transform.position;

            }
            

            _instance._money = 40;
            _instance._maxPoint = PlayerPrefs.GetInt(MAXSCORESTR, 0);
            _instance.StartCoroutine(_instance.MoneyGet());
            
            _instance._soundManager.SetAudioSourceVolume(PlayerPrefs.GetFloat("BGMVol", 0.5f), Define.Sound.BGM);
            _instance._soundManager.SetAudioSourceVolume(PlayerPrefs.GetFloat("EffectVol", 0.5f), Define.Sound.Effect);
            _instance._soundManager.Play("BGM/GAMEPLAY", Define.Sound.BGM);


        }
    }

    // Start is called before the first frame update
    void Start()
    {
        init();
        PauseTime();
    }

    // Update is called once per frame
    void Update()
    {
        Input.OnUpdate();
        Resource.OnUpdate();
    }
    IEnumerator MoneyGet()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            GameManager.Money += GameManager.GETMONEY[GameManager.LV[3]];
        }
    }

    public void DataSave()
    {
        if(Instance._maxPoint < Instance._nowPoint)
        {
            Instance._maxPoint = Instance._nowPoint;
        }
        PlayerPrefs.SetInt(MAXSCORESTR, Instance._maxPoint);
    }

    public void PauseTime()
    {
        Time.timeScale = 0;
    }
    public void UnPauseTime()
    {
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        Instance._life = 0;
        Instance.DataSave();
        UI.GameOverUI();
        if (_instance._maxPoint < _instance._nowPoint)
        {
            _instance._maxPoint = _instance._nowPoint;
        }
        _instance._maxPoint = PlayerPrefs.GetInt(MAXSCORESTR, _instance._maxPoint);
        _instance.PauseTime();

    }
    public void Clear()
    {
        _instance._uIManager = new UIManager();
        _instance._uIManager.init();

    }

    public void ReLoadScene()
    {
        Instance.DataSave();
        SceneManager.LoadScene(SCENENAME);
        Destroy(_instance.gameObject);
        init();
        


    }

    #region ����������

    GameObject[] _Tower;

    int _maxPoint = 0;
    int _nowPoint = 0;
    int _thiswavenum = 1;
    int _thiswaveRegen = 0;
    int _life = 5;
    int _money = 40;
    int _monsterHP = 10;
    int _wave = 1;
    int[] _lv = new int[4] { 0, 0, 0, 0 };  // 0,1,2: �� �� Ǯ  4: ��  5, 
    Vector3[] _direction = new Vector3[9];

    //���
    public static readonly float[] DMGTABLE = new float[5] { 5, 10, 15, 20, 25 };
    public static readonly float[] SHOOTSPEED = new float[5] { 1.5f, 1.0f, 0.7f, 0.5f, 0.1f };
    public static readonly int[] UPGRATECOST = new int[5] { 20, 40, 60, 80, 100 };
    public static readonly int[] GETMONEY = new int[5] { 2, 4, 6, 8, 10 };
    public static readonly string SCENENAME = "PST";
    public static readonly string maxSCORESTR = "MaxScoreasfln;e;wfnkawe;fnk";

    public static string MAXSCORESTR { get { return maxSCORESTR; } } 

    public static GameObject[] Tower { get { return Instance._Tower; } }
    public static int Money { get { return Instance._money; } set { Instance._money = value; Instance._uIManager.PointUpdate(); } }
    public static int Wave { get { return Instance._wave; } set { Instance._wave = value; Instance._uIManager.PointUpdate(); } }
   
    public static int[] LV { get { return Instance._lv; } set { Instance._lv = value; } }

    // warning: �� ���� ������ Monster_Controller���� �ϴ°��� ��Ģ���� �Ѵ�.
    public static int MaxPoint { get { return Instance._maxPoint; } set { Instance._maxPoint = value; } }
    // warning: �� ���� ������ Monster_Controller���� �ϴ°��� ��Ģ���� �Ѵ�.
    public static int NowPoint { get { return Instance._nowPoint; } set { Instance._nowPoint = value; } }
    public static int ThisWaveNum { get { return Instance._thiswavenum; } set { Instance._thiswavenum = value; } }
    public static int ThisWaveRegen { get { return Instance._thiswaveRegen; } set { Instance._thiswaveRegen = value; } }
    // warning: �� ���� ������ EndPoint���� �ϴ°��� ��Ģ���� �Ѵ�.
    public static int Life { get { return Instance._life; } set { Instance._life = value; if (Instance._life <= 0) { Instance.GameOver(); } Instance._uIManager.PointUpdate(); } }
    public static int MonsterHP { get { return Instance._monsterHP; } set { Instance._monsterHP = value; } }
    public static Vector3[] Direction { get { return Instance._direction; }  }

    // int _point = 0; == ���� ���� �� ������ Dead��Ȳ�� ++�� ����� data; 
    // public int _point{}; == ���� ���� �� ������ Dead��Ȳ�� ++�� ����� data; 
    #endregion


}

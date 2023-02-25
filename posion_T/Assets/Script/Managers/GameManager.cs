using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // 현재 작업중인 유니티 맞음


    static GameManager _instance;
    DataManager _dataManager = new DataManager();
    InputManager _inputManager = new InputManager();
    SoundManager _soundManager = new SoundManager();
    ResourceManager _resourceManager = new ResourceManager();
    UIManager _uIManager = new UIManager();
    
    GameObject[] _Tower;

    int _maxPoint = 0;
    int _nowpoint = 0;
    int _thiswavenum = 1;
    int _thiswaveRegen = 0;
    int _life = 10;
    int _money = 40;
    int _monsterHP = 10;

    public static float[] DMGTABLE = new float[5] { 5, 10, 15, 20, 25 };
    public static float[] SHOOTSPEED = new float[5] { 1.5f, 1.0f, 0.7f, 0.5f, 0.1f};
    public static int[] UPGRATECOST = new int[5] { 20, 40, 60, 80, 100};

    int _wave = 1;
    int[] _lv = new int[4] { 0,0,0,0};  /// <summary>
                                        /// 0,1,2: 불 물 풀  4: 돈  5, 
                                        /// </summary>
    public static int[] GETMONEY = new int[5] { 2, 4, 6, 8, 10 };

    public static GameManager Instance { get { init(); return _instance; } }
    public static InputManager Input { get { return Instance._inputManager; } }
    public static DataManager Data { get { return Instance._dataManager; } }
    public static SoundManager Sound { get { return Instance._soundManager; } }

    public static ResourceManager Resource { get { return Instance._resourceManager; } }
    public static UIManager UI { get { return Instance._uIManager; }}
    public static GameObject[] Tower { get { return Instance._Tower; } }
    public static int Money { get { return Instance._money; }set { Instance._money = value; Instance._uIManager.PointUpdate(); } }
    public static int Wave{ get { return Instance._wave; } set { Instance._wave = value; Instance._uIManager.PointUpdate(); } }

    public static int[] LV { get { return Instance._lv; } set { Instance._lv = value; } }


    public static int MaxPoint        {get{ return Instance._maxPoint; } set{ Instance._maxPoint = value; } }
    public static int NowPoint        {get{ return Instance._nowpoint; } set{ Instance._maxPoint = value; } }
    public static int ThisWaveNum     {get{ return Instance._thiswavenum; } set{ Instance._maxPoint = value; } }
    public static int ThisWaveRegen   { get { return Instance._thiswaveRegen; }  set { Instance._maxPoint = value; } }
    public static int Life { get { return Instance._life; } set { Instance._life = value; Instance._uIManager.PointUpdate(); } }
    public static int MonsterHP{ get { return Instance._monsterHP; } set { Instance._monsterHP = value; } }

    // int _point = 0; == 죽인 적의 수 몬스터의 Dead상황에 ++해 줘야할 data; 
    // public int _point{}; == 죽인 적의 수 몬스터의 Dead상황에 ++해 줘야할 data; 


    static void init()
    {
        if(_instance == null)
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

            _instance._money = 40;

            _instance.StartCoroutine(_instance.MoneyGet());


        }
    }

    // Start is called before the first frame update
    void Start()
    {
        init();
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
}

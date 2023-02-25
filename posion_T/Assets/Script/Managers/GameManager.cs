using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{



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
    int _money = 20;

    public static GameManager Instance { get { init(); return _instance; } }
    public static InputManager Input { get { return Instance._inputManager; } }
    public static DataManager Data { get { return Instance._dataManager; } }
    public static SoundManager Sound { get { return Instance._soundManager; } }

    public static ResourceManager Resource { get { return Instance._resourceManager; } }
    public static UIManager UI { get { return Instance._uIManager; }}
    public static GameObject[] Tower { get { return Instance._Tower; } }
    public static int Money { get { return Instance._money; }set { Instance._money = value; } }

    public static int MaxPoint        {get{ return Instance._maxPoint; } set{ Instance._maxPoint = value; } }
    public static int NowPoint        {get{ return Instance._nowpoint; } set{ Instance._maxPoint = value; } }
    public static int ThisWaveNum     {get{ return Instance._thiswavenum; } set{ Instance._maxPoint = value; } }
    public static int ThisWaveRegen   { get { return Instance._thiswaveRegen; }  set { Instance._maxPoint = value; } }
    public static int Life { get { return Instance._life; } set { Instance._life = value; } }

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

            _instance._soundManager.Play("BGM/GAMEPLAY");
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
}

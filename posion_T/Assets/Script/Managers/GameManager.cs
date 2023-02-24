using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static GameManager _instance;
    DataManager _dataManager = new DataManager();
    InputManager _inputManager = new InputManager();
    SoundManager _soundManager = new SoundManager();


    GameObject _player = new GameObject();
    public GameObject Player { get { return _instance._player; } }

    public static GameManager Instance { get { init(); return _instance; } }
    public static InputManager Input { get { return Instance._inputManager; } }
    public static DataManager Data { get { return Instance._dataManager; } }
    public static SoundManager Sound { get { return Instance._soundManager; } }



    static void init()
    {
        if(_instance == null)
        {
            GameObject gm = GameObject.Find("GameManager");
            if(gm == null)
            {
                gm = new GameObject { name = "GameManager" };
                DontDestroyOnLoad(gm);
                gm.AddComponent<GameManager>();
            }

            _instance = gm.GetComponent<GameManager>();
            Sound.init();

            _instance._player = new GameObject();//Instantiate(Resources.Load<GameObject>(""));
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
    }
}

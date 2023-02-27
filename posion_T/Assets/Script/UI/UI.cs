using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    public GameObject ui;
    float BGMVol = 0.5f;
    float EffectVol = 0.5f ;
    public GameObject MainScene;
    public Slider BGMSlider;
    public Slider EffectSlider;

    
    private void Awake()
    {

        BGMSlider = GameObject.Find("BGMSlider").GetComponent<Slider>();
        EffectSlider = GameObject.Find("EffectSlider").GetComponent<Slider>();
        MainScene = GameManager.UI.MainScene;

        BGMVol = PlayerPrefs.GetFloat("BGMVol" , 0.5f);
        EffectVol = PlayerPrefs.GetFloat("EffectVol", 0.5f);

        BGMSlider.value = BGMVol;
        EffectSlider.value = EffectVol;

        
        

    }
    private void Start()
    {
        
    }
    
    public void ActiveUI()
    {
        ui.SetActive(true);
    }

    public void InActiveUI()
    {
        ui.SetActive(false);
    }
    public void PauseTime()
    {
        GameManager.Instance.PauseTime();
    }
    public void UnPauseTime()
    {
        GameManager.Instance.UnPauseTime();

    }
    public void GameStart()
    {
        GameManager.UI.MainPageOff();
        UnPauseTime();
    }
    public void ReStartGame()
    {
        GameManager.Instance.ReLoadScene();

        GameStart();
    }
    public void ToMain()
    {
        GameManager.Instance.ReLoadScene();

    }
    private void Update()
    {
        if (ui.activeSelf &&  ((BGMVol != BGMSlider.value )||(EffectVol != EffectSlider.value))) {

            BGMVol = BGMSlider.value;
            EffectVol = EffectSlider.value;
            GameManager.Sound.SetAudioSourceVolume(BGMSlider.value, Define.Sound.BGM);
            GameManager.Sound.SetAudioSourceVolume(EffectSlider.value, Define.Sound.Effect);

            PlayerPrefs.SetFloat("BGMVol", BGMVol);
            PlayerPrefs.SetFloat("EffectVol", EffectVol);

        }



    }



}

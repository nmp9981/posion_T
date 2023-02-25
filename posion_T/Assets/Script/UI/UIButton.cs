using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIButton : MonoBehaviour
{
    public GameObject UI;
    float BGMVol = 0.5f;
    float EffectVol = 0.5f ;
    public Slider BGMSlider;
    public Slider EffectSlider;
    
    private void Awake()
    {

        Debug.Log("????");
        BGMSlider   = GameObject.Find("BGMSlider").GetComponent<Slider>();
        EffectSlider    = GameObject.Find("EffectSlider").GetComponent<Slider>();

        BGMVol = PlayerPrefs.GetFloat("BGMVol" , 0.5f);
        EffectVol = PlayerPrefs.GetFloat("EffectVol", 0.5f);

        BGMSlider.value = BGMVol;
        EffectSlider.value = EffectVol;

        GameManager.Sound.SetAudioSourceVolume(BGMSlider.value, Define.Sound.BGM);
        GameManager.Sound.SetAudioSourceVolume(EffectSlider.value, Define.Sound.Effect);

        UI.SetActive(false);


    }
    public void ActiveUI()
    {
        UI.SetActive(true);
    }

    public void InActiveUI()
    {
        UI.SetActive(false);
    }

    private void Update()
    {
        if (UI.activeSelf &&  ((BGMVol != BGMSlider.value )||(EffectVol != EffectSlider.value))) {

            BGMVol = BGMSlider.value;
            EffectVol = EffectSlider.value;
            GameManager.Sound.SetAudioSourceVolume(BGMSlider.value, Define.Sound.BGM);
            GameManager.Sound.SetAudioSourceVolume(EffectSlider.value, Define.Sound.Effect);

            PlayerPrefs.SetFloat("BGMVol", BGMVol);
            PlayerPrefs.SetFloat("EffectVol", EffectVol);

        }



    }



}

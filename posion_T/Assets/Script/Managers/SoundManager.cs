using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager 
{
    AudioSource[] audioSource = new AudioSource[(int)Define.Sound.MaxCound];     //  1 번은 BGM 2번은 Effect 3번은 UI사운드
    Dictionary<string, AudioClip> EffectSound = new Dictionary<string, AudioClip>(); 


    public void init()
    {
        GameObject Sound = GameObject.Find("Sound");
        if(Sound == null)
        {
            Sound = new GameObject{ name = "Sound"};
            Object.DontDestroyOnLoad(Sound);
            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));

            for (int i = 0; i < (int)Define.Sound.MaxCound; i++)
            {
                GameObject sound = new GameObject { name = soundNames[i]};
                audioSource[i] = sound.AddComponent<AudioSource>();
                sound.transform.parent = Sound.transform;
            }
            


        }
    }
    
}

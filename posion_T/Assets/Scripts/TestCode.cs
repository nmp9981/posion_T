using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TestCode : MonoBehaviour
{
    TMP_InputField InputField;

    private void Start()
    {
        InputField = this.transform.GetComponent<TMP_InputField>();
    }
    public void OnEndEditStartHP()
    {
        try
        {
            GameManager.StartHP = Int32.Parse(InputField.text);

            Debug.Log($"StartHP {InputField.text}");
        }
        catch (Exception e)
        {
            Debug.Log("StartInputFail");
        }
    }
    public void OnEndEditWaveHP()
    {
        try
        {
            GameManager.WaveHPPlus = Int32.Parse(InputField.text);
            Debug.Log($"WavetHP {InputField.text}");

        }
        catch (Exception e)
        {
            Debug.Log("WaveHPInputFail");
        }
    }
}
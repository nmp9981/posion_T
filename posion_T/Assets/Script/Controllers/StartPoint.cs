using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    float MonsterToMonster = 1.0f;
    float WaveToWave = 5.0f;

    bool _endWave = true;
    int thisWaveNum = 0;
    GameObject[] Monster = new GameObject[3];
    GameObject startPosition;

    private void Start()
    {
        startPosition = GameObject.Find("ReMonster");
        for (int i = 0; i < 3; i++) {
            Monster[i] = Resources.Load<GameObject>($"Prefabs/Monster/Monster{i}");
        }
        StartCoroutine(MonsterWave());

    }
    void MonsterRegen()
    {
        int MonsterIDX = Random.Range(0, 3);
        
        GameObject mob = Instantiate(Monster[MonsterIDX]);


        mob.transform.position = startPosition.transform.position;
    }

    IEnumerator MonsterWave()
    {
        while (true)
        {
            MonsterRegen();
            thisWaveNum += 1;

            if (thisWaveNum >= GameManager.Wave * 2)
            {
                Debug.Log("WaveUP");
                GameManager.Wave += 1;
                if (GameManager.Wave % 10 == 0)
                {
                    GameManager.MonsterHP *= 2;
                }
                thisWaveNum = 0;

                yield return new WaitForSeconds(WaveToWave);
            }
            else
            {
                yield return new WaitForSeconds(MonsterToMonster);

            }
        }

    }
    






}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public float MonsterToMonster = 2.0f;
    bool _endWave = true;
    int wave;
    public bool EndWave { get { return _endWave; } set { _endWave = value; } }
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
            
            if (EndWave)
            {
                StartCoroutine(EndWaveWait());
                EndWave = false;
            }

            MonsterRegen();
            yield return new WaitForSeconds(MonsterToMonster);

        }

    }
    IEnumerator EndWaveWait()
    {
        yield return new WaitForSeconds(5.0f);//MonsterToMonster);

    }






}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    float MonsterToMonster = 0.2f;

    List<int> Wave = new List<int>(new int[] { 10,15,20});

    private void Start()
    {

    }
    void MonsterRegen()
    {

    }

    IEnumerator MonsterWave()
    {
        yield return new WaitForSeconds(0.2f);//MonsterToMonster);
        MonsterRegen();

    }




}

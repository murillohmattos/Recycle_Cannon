using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnLocal;
    
    public GameObject[] enemyList; //Quais monstros em cada wave
    
    public int howMany = 1; //quantidade de monstros em cada wave

    //intervalo entre as waves
    public TMP_Text waveLevelText;
    public int waveLevel = 0;
    public float timeBetweenWaves = 20f;
    public float timeBetweenEnemies = 1f;

    public TMP_Text timerText;
    public float countdown = 10f;

    //intervalo de spawn de cada monstro

    private void Start()
    {
        waveLevelText.text = waveLevel.ToString();
    }

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());

            waveLevel++;
            if (waveLevel >= 1 && waveLevel <= 4)
            {
                howMany = Random.Range(1, 4);
            }

            if (waveLevel >= 5 && waveLevel <= 10)
            {
                howMany = Random.Range(3, 5);
            }

            if (waveLevel >= 11)
            {
                howMany = Random.Range(4, 8);
            }

            waveLevelText.text = waveLevel.ToString();

            countdown = timeBetweenWaves;

            timeBetweenWaves += 1;
        }

        countdown -= Time.deltaTime;
        timerText.text = countdown.ToString("0");
    }

    IEnumerator SpawnWave() 
    {
        for (int i = 0; i < howMany; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }        
    }

    void SpawnEnemy() 
    {
        int rngLocal = Random.Range(0, 3);
        int rngSpawn = Random.Range(0, 3);

        Instantiate(enemyList[rngSpawn], spawnLocal[rngLocal].position, spawnLocal[rngLocal].rotation);
    }
}

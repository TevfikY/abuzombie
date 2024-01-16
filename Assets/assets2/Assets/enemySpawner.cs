using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


[System.Serializable]
public class Wave
{
    public string waveName;
    public int noOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}
public class enemySpawner : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    public Transform[] spawnPoints;
    private Wave currentWave;
    private int currentWaveNumber;
    public bool canSpawn = true;
    private float nextSpawnTime;

    private void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0 && !canSpawn && currentWaveNumber+1 != waves.Length)
        {
            SpawnNextWave();
        }

    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime <Time.time)
        {
            GameObject randomEnemey = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemey, randomSpawnPoint.position,quaternion.identity);
            currentWave.noOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if (currentWave.noOfEnemies == 0) canSpawn = false;
            // sos
        }
        
       
    }

    void SpawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true; 
    }
}

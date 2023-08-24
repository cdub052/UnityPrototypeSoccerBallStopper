using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnPos = 9.0f;
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    public int enemyCount;
    public int waveNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        
        //start spawn enemy method
        SpawnEnemyWave(waveNum);
        //spawn new power up
        Instantiate(powerUpPrefab, GenerateRandomSpawnPosition(), powerUpPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //get enemy count by finding all enemies in the screen 
        enemyCount = FindObjectsOfType<Enemy>().Length;
        //spawn enemies if spawn count equals 0 and spawn new power up
        if (enemyCount == 0)
        {
            waveNum++;
            SpawnEnemyWave(waveNum);
            Instantiate(powerUpPrefab, GenerateRandomSpawnPosition(), powerUpPrefab.transform.rotation);
        }
    }
    //method for spawning enemy wave
    void SpawnEnemyWave(int enemysToSpawn)
    {
        //for loop to create enemys
        for (int i = 0; i < enemysToSpawn; i++) {
            //instanciate enemy prefab
            Instantiate(enemyPrefab, GenerateRandomSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    //create vector3 method to get random position
    private Vector3 GenerateRandomSpawnPosition()
    {
        //get random x position 
        float spawnPosX = Random.Range(-spawnPos, spawnPos);
        //get random position on z
        float spawnPosZ = Random.Range(-spawnPos, spawnPos);
        //random position for the vector
        Vector3 randomSpawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomSpawnPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // edit the spawn position of the snakes here!

    public GameObject[] randomSpawnPos;
    private float spawnRangeY1 = 18;
    private float spawnRangeY2 = 30;
    private float spawnPosZ = -17;
    private float spawnPosX = 75;
    private float startDelay = 3;
    private float repeatRate = 1.2f;

    // inf spawn of snakes
    void Start()
    {

    }

    public void StartSpawn()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void Update()
    {

    }

    public void SpawnObstacle()
    {
        // Spawning my array of obstacles(5) with a varying height defined in the start of the class
        Vector3 spawnPos = new Vector3(spawnPosX, Random.Range(spawnRangeY1, spawnRangeY2), spawnPosZ);
        int spawnIndex = Random.Range(0, randomSpawnPos.Length);

        // Destroying each clone after 10 seconds
        GameObject deleteClone = (GameObject)Instantiate(randomSpawnPos[spawnIndex], spawnPos, randomSpawnPos[spawnIndex].transform.rotation);
        Destroy(deleteClone, 10.0f);
    
    }


}

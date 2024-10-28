using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;     
    public Transform spawnPosition;     
    public int numberOfObjectsToSpawn = 3;
    public float spawnOffset = 2f;      
    public float spawnInterval = 2f;     
    private bool isSpawning = false;     
    private int spawnCount = 0;          

    void Update()
    {
       
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");

        if (bosses.Length == 0 && !isSpawning && spawnCount < numberOfObjectsToSpawn)
        {
            StartCoroutine(SpawnObjectsOverTime());
        }
    }

    IEnumerator SpawnObjectsOverTime()
    {
        isSpawning = true;  
        for (int i = spawnCount; i < numberOfObjectsToSpawn; i++)
        {
            
            Vector3 spawnPos = spawnPosition.position + new Vector3(i * spawnOffset, 0, 0);

            
            Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
            Debug.Log(objectToSpawn.name + " spawned at: " + spawnPos);

            
            spawnCount++;

           
            yield return new WaitForSeconds(spawnInterval);
        }
        isSpawning = false;  
    }
}

